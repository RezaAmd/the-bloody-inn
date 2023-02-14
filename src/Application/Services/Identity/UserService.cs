using TheBloodyInn.Infrastructure.Repositories;

namespace Application.Services.Identity;

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