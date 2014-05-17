using FactsLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactsLibrary.Repository
{
    public class CountryFactsRepository : ICountryFactsRepository
    {
        public IQueryable<CountryFact> GetCountryFacts()
        {
            var mockList = new List<CountryFact>();
            mockList.Add(new CountryFact() { CountryName = "United States", Population = 317996000 });
            mockList.Add(new CountryFact() { CountryName = "Mexico", Population = 118395054 });

            return mockList.AsQueryable();
        }
    }
}
