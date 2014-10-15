using FactsLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace FactsLibrary.Api
{
    public class CountryFactsController: EntitySetController<CountryFact,string>
    {

        public override IQueryable<CountryFact> Get()
        {
            return (new[] { new CountryFact() { CountryName = "Mexico", Population = 1020 } }).AsQueryable();
        }

    }
}
