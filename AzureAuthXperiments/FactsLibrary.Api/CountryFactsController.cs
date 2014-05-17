using FactsLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace FactsLibrary.Api
{
    public class CountryFactsController: EntitySetController<string,CountryFact>
    {


        public ICountryFactsRepository Repository { get; private set; }
        public CountryFactsController(ICountryFactsRepository repository)
        {
            this.Repository = repository;
        }
    }
}
