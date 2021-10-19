
using Abstractions;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSuggest.Application
{
    public class GetSuggestions
    {
        public class Query : IRequest<List<Models.Conference>>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }  
        }

        public class QueryHandler : IRequestHandler<Query, List<Models.Conference>>
        {
            public readonly IConfiguration _configuration;
            public readonly IConferenceRepository _repository;
            
            public QueryHandler(IConfiguration configuration,IConferenceRepository repository)
            {
                _configuration = configuration;
                _repository = repository;
                
            }
            public async Task<List<Models.Conference>> Handle(Query request, CancellationToken cancellationToken)
            {
                var conferences = await _repository.GetConferencesAsync(request.ConferenceId, request.AttendeeEmail, cancellationToken);
                var attendeeEmail = conferences.Select(x => x.AttendeeEmail).ToArray();

                var aConference = await _repository.GetConferencesAsync(attendeeEmail, cancellationToken);

                var listOfRecommended = aConference
                    .Where(c => c.ConferenceId != request.ConferenceId)
                    .ToList();

                var ids = listOfRecommended.GroupBy(o => o.ConferenceId)
                    .ToDictionary(x => x.Key, y => y.Count())
                    .Take(_configuration.GetValue("SuggestionsCount", 3))
                    .Select(k => k.Key)
                    .ToArray();

                return await _repository.GetConferencesAsync(ids, cancellationToken);
            }
        }
    }
}
