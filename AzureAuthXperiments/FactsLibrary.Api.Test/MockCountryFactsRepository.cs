using FactsLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactsLibrary.Api.Test
{
    public class MockCountryFactsRepository : ICountryFactsRepository
    {

        public IQueryable<CountryFact> GetCountryFacts()
        {
            var mocklist = new List<CountryFact>();
            mocklist.Add(new CountryFact() { CountryName = "United States", Population = 318059000 });
            mocklist.Add(new CountryFact() { CountryName = "Mexico", Population = 119713203 });
            return mocklist.AsQueryable();
        }
    }
}
