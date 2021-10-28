using Neosoft.FAMS.Application.Features.Users.Queries;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
  public  interface ILogin
    {
        public int CheckUsernameAndPassword(string userName, string password);

        
    }
}
