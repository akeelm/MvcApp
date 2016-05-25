using System.Linq;
using Repository.Models;
using System.Data.Entity;

namespace Repository.Data
{
    public class UsersService : Repository<User>
    {
        private IDbSet<User> _users;

        public UsersService(IDataSession dataSession)
        {
            base._db = dataSession;
            _users = _db.Set<User>();
        }

        public User GetUserByUsername(string username)
        {
            var user = (from x in _users where x.Username == username select x).FirstOrDefault();
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = (from x in _users where x.Email == email select x).FirstOrDefault();
            return user;
        }

    }
}
