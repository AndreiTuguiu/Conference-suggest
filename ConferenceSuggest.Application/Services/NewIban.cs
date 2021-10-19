//using ConferenceSuggest.Data;
//using ConferenceSuggest.Data;
//using System.Collections.Generic;
//using System.Linq;

//namespace ConferenceSuggest.Application.Services
//{
//    public class NewIban
//    {
//        private readonly ConferenceDbContext _dbContext;

//        public NewIban(ConferenceDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public string GetNewIban()
//        {
//            List<string> ibans = _dbContext.BankAccounts.Select(x => x.Iban).ToList();
           
//            if (ibans.Count == 0)
//                return "1";

//            return (long.Parse(ibans.Last()) + 1).ToString();
//        }
//    }
//}
