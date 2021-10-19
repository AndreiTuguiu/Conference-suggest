using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceSuggest.Data.Configuration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Models.Conference>
    {
        public void Configure(EntityTypeBuilder<Models.Conference> builder)
        {
            builder.ToTable("Conference").HasKey(x => new { x.Id });
        }
    }
}
