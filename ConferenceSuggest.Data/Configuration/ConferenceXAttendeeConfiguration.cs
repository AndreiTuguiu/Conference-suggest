using ConferenceSuggest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceSuggest.Data.Configuration
{
    public class ConferenceXAttendeeConfiguration : IEntityTypeConfiguration<Models.ConferenceXAttendee>
        {
            public void Configure(EntityTypeBuilder<ConferenceXAttendee> builder)
            {
                builder.ToTable("ConferenceXAttendee").HasKey(x => new { x.Id });
                builder.Property(c => c.AttendeeEmail);
                builder.Property(c => c.StatusId);
                builder.HasOne(c => c.Conference)
                    .WithMany()
                    .HasForeignKey(c => c.ConferenceId);
            }
        }
    
}
