
using Ardalis.SharedKernel;

using Microsoft.EntityFrameworkCore;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Person> Persons => Set<Person>();
  public DbSet<TimeOff> TimeOffs => Set<TimeOff>();
  public DbSet<Appointment> Appointment => Set<Appointment>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Person>()
      .HasMany(e=>e.TimeOff)
      .WithOne(e=>e.Person)
      .HasForeignKey(e=>e.PersonId);
    modelBuilder.Entity<Appointment>()
      .HasOne(p => p.Person)
      .WithOne(a => a.Appointment)
      .HasForeignKey<Person>(p=>p.AppointmentId);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
