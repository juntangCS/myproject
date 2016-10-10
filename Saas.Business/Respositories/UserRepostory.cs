using System.Linq;
using Saas.Business.Entities;

namespace Saas.Business.Respositories
{
    public class UserRepostory
    {
        private readonly PhotoSqlDbContext _photoSqlDbContext;
        
        public UserRepostory(PhotoSqlDbContext photoSqlDbContext)
        {
            _photoSqlDbContext = photoSqlDbContext;
        }

        public User Get(int id)
        {
            return _photoSqlDbContext.Users.Find(id);
        }

        public IQueryable<User> GetAll()
        {
            return _photoSqlDbContext.Users;
        }

        public void Add(User user)
        {
            _photoSqlDbContext.Users.Add(user);
            _photoSqlDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _photoSqlDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _photoSqlDbContext.Users.Remove(user);
            _photoSqlDbContext.SaveChanges();
        }
    }
}
