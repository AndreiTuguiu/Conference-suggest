using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
