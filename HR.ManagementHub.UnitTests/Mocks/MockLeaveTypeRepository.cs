using Core.Application.Common.Interfaces;
using Core.Domain;
using Moq;

namespace HR.ManagementHub.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Uid = Guid.NewGuid(),
                DefaultDays = 20,
                Name = "Vaction"
            },
            new LeaveType
            {
                Uid = Guid.NewGuid(),
                DefaultDays = 30,
                Name = "Sick"
            },
            new LeaveType
            {
                Uid = Guid.NewGuid(),
                DefaultDays= 40,
                Name = "Maternity"
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
