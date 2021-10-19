using MediatR;
using RatingSystem.Application.Services;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class CreateAccount : IRequestHandler<MakeNewAccount>
    {
        private readonly IMediator _mediator;
        private readonly AccountOptions _accountOptions;
        private readonly ConferenceDbContext _dbContext;
        private readonly NewIban _ibanService;

        public CreateAccount(IMediator mediator, AccountOptions accountOptions, ConferenceDbContext dbContext, NewIban ibanService)
        {
            _mediator = mediator;
            _accountOptions = accountOptions;
            _dbContext = dbContext;
            _ibanService = ibanService;
        }

        public async Task<Unit> Handle(MakeNewAccount request, CancellationToken cancellationToken)
        {
            // TODO: implement logic
            return Unit.Value;
        }        
    }
}