﻿using MediatR;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetAllCountryListQuery : IRequest<Response<IEnumerable<Country>>>
    {

    }
}
