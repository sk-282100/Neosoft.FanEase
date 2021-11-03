using AutoMapper;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.WebApp.Models.AdvertisementModel;
using Neosoft.FAMS.WebApp.Models.CampaignModel;
using Neosoft.FAMS.WebApp.Models.VideoModel;
using Neosoft.FAMS.WebApp.Models.ViewerModel;

namespace Neosoft.FAMS.WebApp.Profiles
{
    public class Mappers : Profile
    {
        public Mappers()
        {

            CreateMap<UpdateCreatorByIdCommand, CreatorRegisteration>().ReverseMap();
            CreateMap<CreateAdvertisementCommand, AddAsset>().ReverseMap();

            CreateMap<VideoCreateCommand, AddVideo>().ReverseMap();
            CreateMap<CampaignCreateCommand, CreateCampaign>().ReverseMap();
            CreateMap<ViewerCreateCommand, ViewerRegisteration>().ReverseMap();
        }
    }
}
