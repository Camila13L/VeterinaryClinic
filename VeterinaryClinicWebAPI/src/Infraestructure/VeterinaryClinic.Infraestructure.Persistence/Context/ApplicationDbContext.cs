using System;
using System.Reflection;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Domain.Common;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Infraestructure.Persistence.Context
{
	public class ApplicationDbContext : DbContext
	{
		private readonly IDateTimeService _dateTime;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
		{
			// keeps information about information of instance
			// change keeps into the DB
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			_dateTime = dateTime;
		}

		public DbSet<Owner> Pets { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.Created = _dateTime.NowUtc;
						break;
					case EntityState.Modified:
						entry.Entity.LastModified = _dateTime.NowUtc;
						break;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
	}
}

