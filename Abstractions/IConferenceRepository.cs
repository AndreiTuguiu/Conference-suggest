
using ConferenceSuggest.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IConferenceRepository
    {
        Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string attendeeEmail, CancellationToken cancellationToken = default);
        Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] attendeeEmail, CancellationToken cancellationToken = default);
        Task<List<Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default);
        Task<Conference> GetConferenceByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Conference> GetConferenceByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
