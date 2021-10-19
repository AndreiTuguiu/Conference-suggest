using ConferenceSuggest.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ConferenceSuggest.Data
{
    public class ConferenceDbContext : DbContext
    {
        public DbSet<Models.Conference> Conferences { get; set; }
        public DbSet<Models.ConferenceXAttendee> ConferenceXAttendees { get; set; }

        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConferenceXAttendeeConfiguration());
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
        }
    }
}
