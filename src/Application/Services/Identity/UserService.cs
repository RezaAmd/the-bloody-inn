using TheBloodyInn.Infrastructure.Repositories;

namespace TheBloodyInn.Application.Services.Identity;

public class UserService
{
    #region Constructors
    public IUnitOfWork _uow { get; set; }
    public UserService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    #endregion

}