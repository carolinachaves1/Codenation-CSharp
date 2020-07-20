using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
           var quote = _context.Quotes.Count();

            if(quote == 0)
            {
                return null;
            }

            var random = _randomService.RandomInteger(quote);

            return _context.Quotes.ElementAt(random);
        }

        public Quote GetAnyQuote(string actor)
        {
            var quoteByActor = _context.Quotes.Count(x => x.Actor == actor);

            if (quoteByActor == 0)
            {
                return null;
            }

            var random = _randomService.RandomInteger(quoteByActor);

            return _context.Quotes.Where(x => x.Actor == actor).ElementAt(random);
        }
    }
}