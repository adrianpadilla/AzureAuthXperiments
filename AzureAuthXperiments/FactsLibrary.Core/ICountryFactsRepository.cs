using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactsLibrary.Core
{
    public interface ICountryFactsRepository
    {
        IQueryable<CountryFact> GetCountryFacts();
    }
}
