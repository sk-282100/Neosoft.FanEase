using AutoMapper;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Profiles
{
    public class Mappers : Profile
    {
        public Mappers()
        {

            CreateMap<UpdateCreatorByIdCommand, CreatorRegisteration>().ReverseMap();

        }
    }
}
