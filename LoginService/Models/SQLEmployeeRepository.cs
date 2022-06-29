using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class SQLEmployeeRepository:ILoginserviceReposioty
    {
        private readonly FlightBookingDbContext _logincontext;
        public SQLEmployeeRepository(FlightBookingDbContext logincontext)
        {
            _logincontext = logincontext;
        }
        public Users RegisterUser(Users user)
        {
            _logincontext.Users.Add(user);
          
            _logincontext.SaveChanges();
            return user;
        }
        public Users GetuserId(string userId)
        {
            var user = _logincontext.Users.SingleOrDefault(x => x.UserId == userId);
            return user;
        }

    }
}
