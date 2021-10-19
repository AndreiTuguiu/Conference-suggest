
using Abstractions;
using ConferenceSuggest.Data;
using ConferenceSuggest.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferenceSuggest.Application
{
    public class GetSuggestions
    {
        public class Query : IRequest<List<Conference>>
        {
            
        }

        public class QueryHandler : IRequestHandler<Query, List<Conference>>
        {
            public readonly IConfiguration _configuration;
            //public readonly IConferenceRepository _repository;
            public readonly ConferenceDbContext _dbContext;

            public QueryHandler(IConfiguration configuration, ConferenceDbContext dbContext)
            {
                _configuration = configuration;
                //_repository = repository;
                _dbContext = dbContext;

            }
            public Task<List<Conference>> Handle(Query request, CancellationToken cancellationToken)
            {
                Random r = new Random();
                int toSkip = r.Next(0, _dbContext.Conferences.Count());
                var db = _dbContext.Conferences;
                var result = db.Select(c => new Conference
                {
                    Id = c.Id,
                    Name = c.Name,
                    OrganizerEmail = c.OrganizerEmail,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    LocationId = c.LocationId
                }).Skip(toSkip)
                .Take(3)
                .ToList();

                return Task.FromResult(result);

            }
        }
    }
}
