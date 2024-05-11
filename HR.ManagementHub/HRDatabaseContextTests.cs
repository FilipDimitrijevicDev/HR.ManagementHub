using Core.Domain;
using Core.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.ManagementHub
{
    public class HRDatabaseContextTests
    {
        private readonly DatabaseContext _databseContext;

        public HRDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _databseContext = new DatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreate()
        {
            var leaveType = new LeaveType
            {
                Uid = Guid.NewGuid(),
                DefaultDays = 20,
                Name = "Vaction"
            };

            await _databseContext.LeaveTypes.AddAsync(leaveType);
            await _databseContext.SaveChangesAsync();

            DateTime? dateCreated = leaveType.CreatedDate;

            dateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async Task Save_SetDateUpdateAsync()
        {
            var leaveType = new LeaveType
            {
                Uid = Guid.NewGuid(),
                DefaultDays = 20,
                Name = "Vaction"
            };

            await _databseContext.LeaveTypes.AddAsync(leaveType);
            await _databseContext.SaveChangesAsync();

            leaveType.DefaultDays = 21;

            _databseContext.LeaveTypes.Update(leaveType);
            await _databseContext.SaveChangesAsync();

            DateTime? dateUpdated = leaveType.UpdatedDate;

            dateUpdated.ShouldNotBeNull();
        }
    }
}