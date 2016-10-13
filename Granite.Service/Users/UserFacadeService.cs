using System.Linq;
using Saas.Business.Services;
using Saas.Business.Entities;

namespace Granite.Service.Users
{
    public class UserFacadeService
    {
        private readonly UserService _userService;

        public UserFacadeService(UserService userService)
        {
            _userService = userService;
        }

        public User Get(int id)
        {
            return _userService.Get(id);
        }

        public IQueryable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public void Add(User user)
        {
            _userService.Add(user);
        }

        public void Update(User user)
        {
            _userService.Update(user);
        }

        public void Delete(User user)
        {
            _userService.Delete(user);
        }

    }
}
