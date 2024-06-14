//using Core.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Core.Infrastructure.Persistence.Configurations;

//public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
//{
//    public void Configure(EntityTypeBuilder<LeaveType> builder)
//    {
//        builder.HasData(
//          new LeaveType
//          {
//              Id = 1,
//              Uid = Guid.NewGuid(),
//              Name = "Vacation",
//              DefaultDays = 20,
//              CreatedDate = DateTime.Now
//          });

//        builder.Property(x => x.Name)
//            .IsRequired()
//            .HasMaxLength(30);

//        builder.Property(x => x.DefaultDays)
//            .IsRequired();

//        builder.Property(x => x.Uid) 
//            .IsRequired();            
//    }
//}
