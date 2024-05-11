using AutoMapper;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.MappingProfiles;
using Core.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.ManagementHub.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.ManagementHub.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypesQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<ILogger<GetAllLeaveTypesQueryHandler>> _mockLogger;

    public GetLeaveTypesQueryHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(x =>
        {
            x.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockLogger = new Mock<ILogger<GetAllLeaveTypesQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypesTest()
    {
        //var handler = new GetAllLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockLogger.Object);

        //var results = await handler.Handle(new GetAllLeaveTypesQuery(), CancellationToken.None);

        //var result = results.ShouldBeOfType<GetAllLeaveTypesQueryResult>();
        //result.LeaveTypeDto.Count.ShouldBe(3);
    }
}
