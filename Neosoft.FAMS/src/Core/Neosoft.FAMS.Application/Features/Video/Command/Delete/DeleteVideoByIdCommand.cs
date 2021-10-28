﻿using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Video.Commands.Delete
{
    public class DeleteVideoByIdCommand : IRequest<Response<bool>>
    {
        public long VideoId { get; set; }
    }
}
