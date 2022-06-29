using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
  public  interface ILoginserviceReposioty
    {
        Users RegisterUser(Users user);
        Users GetuserId(string userId);
    }
}
