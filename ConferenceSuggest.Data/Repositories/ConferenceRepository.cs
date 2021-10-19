using Abstractions;
using ConferenceSuggest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSuggest.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceDbContext _dbcontext;
        public ConferenceRepository(ConferenceDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Conference> GetConferenceByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var conference = await _dbcontext.Conferences
               .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            return conference;
        }

        public async Task<Conference> GetConferenceByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var conference = await _dbcontext.Conferences
              .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
            return conference;
        }

        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string attendeeEmail, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbcontext.ConferenceXAttendees
                .Where(c => c.ConferenceId == conferenceId && c.AttendeeEmail != attendeeEmail)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] attendeeEmail, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbcontext.ConferenceXAttendees
                .Where(c => attendeeEmail.Contains(c.AttendeeEmail))
                .Include(x => x.Conference)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<Models.Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbcontext.Conferences
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken);

            return conferences.ToList();
        }
    }
}
