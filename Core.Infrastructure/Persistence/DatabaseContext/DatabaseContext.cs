﻿using Core.Domain;
using Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.DatabaseContext;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveDistribution> LeaveDistributions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    SoftDelete();
                    entry.State = EntityState.Modified;
                    break;
            }
        } 

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SoftDelete()
    {
        ChangeTracker.DetectChanges();

        var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

        foreach (var item in markedAsDeleted)
        {
            if (item.Entity is IAffectedDateTimes entity)
            {
                entity.DeletedDate = DateTime.UtcNow;
            }
        }
    }
}
