﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class LoginQuery:IRequest<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
