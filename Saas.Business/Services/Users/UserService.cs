using System;
using System.Linq;
using Saas.Business.Entities;
using Saas.Business.Respositories;
using Saas.Business.Services.Bases;

namespace Saas.Business.Services
{
    public class UserService
    {
        private readonly UserRepostory _userRepostory;
        private readonly EsePasswordService _esePasswordService;

        public UserService(UserRepostory studentRepostory, EsePasswordService esePasswordService)
        {
            _userRepostory = studentRepostory;
            _esePasswordService = esePasswordService;
        }

        public User Get(int id)
        {
            return _userRepostory.Get(id);
        }

        public IQueryable<User> GetAll()
        {
            return _userRepostory.GetAll();
        }

        public void Add(User user)
        {
            user.Password = _esePasswordService.DesEncrypt(user.Password, "11111111");
            user.UserName = GetFullName(user.FirstName, user.LastName);
            user.FullName = GetFullName(user.FirstName, user.LastName);
            user.CreatedTime = DateTime.Now;
            _userRepostory.Add(user);
        }

        public void Update(User user)
        {
            _userRepostory.Update(user);
        }

        public void Delete(User user)
        {
            _userRepostory.Delete(user);
        }

        private string GetFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return lastName;
            }
            if (string.IsNullOrEmpty(lastName))
            {
                return firstName;
            }
            return firstName + " " + lastName;
        }
    }
}
