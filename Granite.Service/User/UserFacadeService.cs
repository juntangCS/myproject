using System.Linq;
using Saas.Business.Services;

namespace Granite.Service.User
{
    public class UserFacadeService
    {
        private readonly UserService _userService;

        public UserFacadeService(UserService userService)
        {
            _userService = userService;
        }

        public Saas.Business.Entities.User Get(int id)
        {
            return _userService.Get(id);
        }

        public IQueryable<Saas.Business.Entities.User> GetAll()
        {
            return _userService.GetAll();
        }

        public void Add(Saas.Business.Entities.User user)
        {
            _userService.Add(user);
        }

        public void Update(Saas.Business.Entities.User user)
        {
            _userService.Update(user);
        }

        public void Delete(Saas.Business.Entities.User user)
        {
            _userService.Delete(user);
        }

    }
}
