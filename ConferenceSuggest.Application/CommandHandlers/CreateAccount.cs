//using ConferenceSuggest.Data;
//using MediatR;
//using ConferenceSuggest.Application.Services;
//using ConferenceSuggest.Data;
//using ConferenceSuggest.Models;
//using ConferenceSuggest.PublishedLanguage.Commands;
//using ConferenceSuggest.PublishedLanguage.Events;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConferenceSuggest.Application.WriteOperations
//{
//    public class CreateAccount : IRequestHandler<MakeNewAccount>
//    {
//        private readonly IMediator _mediator;
//        private readonly AccountOptions _accountOptions;
//        private readonly ConferenceDbContext _dbContext;
//        //private readonly NewIban _ibanService;

//        public CreateAccount(IMediator mediator, AccountOptions accountOptions, ConferenceDbContext dbContext)
//        {
//            _mediator = mediator;
//            _accountOptions = accountOptions;
//            _dbContext = dbContext;
            
//        }

//        public async Task<Unit> Handle(MakeNewAccount request, CancellationToken cancellationToken)
//        {
//            // TODO: implement logic
//            return Unit.Value;
//        }        
//    }
//}