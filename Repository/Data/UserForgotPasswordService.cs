using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class UserForgotPasswordService : Repository<UserForgotPassword>
    {
        private IDbSet<UserForgotPassword> _userForgotPassword;

        public UserForgotPasswordService(IDataSession dataSession)
        {
            _db = dataSession;
            _userForgotPassword = _db.Set<UserForgotPassword>();
        }
    }
}
