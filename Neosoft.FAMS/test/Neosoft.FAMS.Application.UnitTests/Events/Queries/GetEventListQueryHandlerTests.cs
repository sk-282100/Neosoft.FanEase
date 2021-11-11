using AutoMapper;
using Moq;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Events.Queries.GetEventsList;
using Neosoft.FAMS.Application.Profiles;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Application.UnitTests.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.UnitTests.Event.Queries
{
    public class GetEventListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _mockEventRepository;

        public GetEventListQueryHandlerTests()
        {
            _mockEventRepository = EventRepositoryMocks.GetEventRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        //  [Fact]
        public async Task Handle_GetEventList_FromEventsRepo()
        {
            var handler = new GetEventsListQueryHandler(_mapper, _mockEventRepository.Object);

            var result = await handler.Handle(new GetEventsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<EventListVm>>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
