using System.Text.Json;

namespace TheBloodyInn.Domain.Models.Settings;

public class InnSetting
{
    public bool IsShortMode { get; set; }
    public List<Guid>? RemovedGuests { get; set; }
    
    #region Methods
    public override string ToString() => JsonSerializer.Serialize(this);
    public static InnSetting? MapToObject(string setting) => JsonSerializer.Deserialize<InnSetting>(setting);
    #endregion
}