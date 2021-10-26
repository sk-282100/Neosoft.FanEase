using AutoMapper;
using Neosoft.FAMS.Application.Features.Categories.Commands.CreateCateogry;
using Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesList;
using Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Neosoft.FAMS.Application.Features.Events.Commands.CreateEvent;
using Neosoft.FAMS.Application.Features.Events.Commands.UpdateEvent;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventDetail;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsExport;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsList;
using Neosoft.FAMS.Application.Features.Orders.Queries.GetOrdersForMonth;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Users.Queries;
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
        }
    }
}
