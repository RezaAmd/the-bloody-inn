﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TheBloodyInn.Application.Common.Enums.JwtServices;

namespace TheBloodyInn.Application.Common.Security.JwtBearer;

public class JwtService : IJwtService
{
    #region constructure
    private readonly AppSettingDto _appSetting;

    public JwtService(IOptions<AppSettingDto> appSetting)
    {
        _appSetting = appSetting.Value;
    }
    #endregion

    public async Task<string> GenerateTokenAsync(IEnumerable<Claim> claims, DateTime expiresAt, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await Task.FromResult(Generate(claims, expiresAt));
    }

    public async Task<(IEnumerable<Claim>? Claims, AccessTokenStatus Status)> GetTokenClaimsAsync(string token, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await Task.FromResult(GetTokenClaims(token));
        return result;
    }

    public async Task<(Claim? Claim, AccessTokenStatus Status)> FindInTokenClaimsAsync(string token, string ClaimType,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        // Get all claims.
        var getClaims = await GetTokenClaimsAsync(token, cancellationToken);
        if (getClaims.Claims is null)
            return (null, getClaims.Status);

        // Find in claims.
        return (getClaims.Claims.FirstOrDefault(c => c.Type == ClaimType),
            getClaims.Status);
    }

    #region Private Methods
    private string Generate(IEnumerable<Claim> claims, DateTime? expiresAt = null)
    {
        var secretKey = Encoding.UTF8.GetBytes(_appSetting.JwtSettings.SecretKey); // it must be atleast 16 characters or more
        var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _appSetting.JwtSettings.Issuer,
            Audience = _appSetting.JwtSettings.Audience,
            IssuedAt = DateTime.Now.ToUniversalTime(),
            NotBefore = DateTime.Now.ToUniversalTime(),
            SigningCredentials = signinCredentials,
            Subject = new ClaimsIdentity(claims)
        };

        #region Token expiration
        if (expiresAt.HasValue)
        {
            descriptor.Expires = expiresAt.Value.ToUniversalTime();
        }
        else if (_appSetting.JwtSettings.ExpirationMinutes.HasValue &&
            _appSetting.JwtSettings.ExpirationMinutes.Value > 0)
        {
            descriptor.Expires = DateTime.Now.AddMinutes(_appSetting.JwtSettings.ExpirationMinutes.Value).ToUniversalTime();
        }
        #endregion

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(descriptor);
        string token = tokenHandler.WriteToken(securityToken);
        return token;
    }

    private (IEnumerable<Claim>? Claims, AccessTokenStatus Status) GetTokenClaims(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSetting.JwtSettings.SecretKey);
            //var encryptionkey = Encoding.UTF8.GetBytes(appSettings.EncryptionKey);
            var claimsPrincipal = handler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                },
                out SecurityToken securityToken);
            return (claimsPrincipal.Claims, AccessTokenStatus.Succeeded);
        }
        catch (SecurityTokenExpiredException)
        {
            // Token was expired.
            return (null, AccessTokenStatus.Expired);
        }
        catch (Exception)
        {
            // Another errors.
            return (null, AccessTokenStatus.Conflict);
        }
    }
    #endregion
}