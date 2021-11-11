using AutoMapper;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Categories.Commands.CreateCateogry;
using Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesList;
using Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Events.Commands.CreateEvent;
using Neosoft.FAMS.Application.Features.Events.Commands.UpdateEvent;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventDetail;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsExport;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsList;
using Neosoft.FAMS.Application.Features.Orders.Queries.GetOrdersForMonth;
using Neosoft.FAMS.Application.Features.Template.Queries;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Users.Queries;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Update;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
            CreateMap<UserDemo, UserListVm>().ConvertUsing<UserVmCustomMapper>();

            CreateMap<UserDemo, CreateUserCommand>().ReverseMap();
            CreateMap<ContentCreaterCommand, ContentCreatorDetail>().ReverseMap();
            CreateMap<ContentCreatorDto, ContentCreatorDetail>().ReverseMap();


            CreateMap<ViewerCreateCommand, ViewerDetail>().ReverseMap();
            CreateMap<ViewerDto, ViewerDetail>().ReverseMap();
            CreateMap<UpdateCreatorByIdCommand, ContentCreatorDetail>().ReverseMap();
            CreateMap<UpdateViewerCommand, ViewerDetail>().ReverseMap();

            CreateMap<CampaignCreateCommand, CampaignDetail>().ReverseMap();
            CreateMap<CampaignGetAllDto, CampaignDetail>().ReverseMap();
            CreateMap<UpdateCampaignCommand, CampaignDetail>().ReverseMap();

            CreateMap<CreateAdvertisementCommand, AdvertisementDetail>().ReverseMap();
            CreateMap<AdvertisementListQueryDto, AdvertisementDetail>().ReverseMap();
            CreateMap<UpdateAdvertisementCommand, AdvertisementDetail>().ReverseMap();
            CreateMap<CampaignAdvertiseMapping, AddCampaignAdvertisementCommand>().ReverseMap();

            CreateMap<VideoCreateCommand, VideoDetail>().ReverseMap();

            CreateMap<VideoGetAllDto, VideoDetail>().ReverseMap();

            CreateMap<VideoCreateCommand, VideoDetail>().ReverseMap();
            CreateMap<UpdateVideoByIdCommand, VideoDetail>().ReverseMap();
            CreateMap<ResetPasswordCommand, Login>().ReverseMap();

            CreateMap<TemplateListDto,TemplateDetail>().ReverseMap();


        }
    }
}
