using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class CountryFactsController : EntitySetController<CountryFact,string>
    {
        public override IQueryable<CountryFact> Get()
        {
            var mockList = new List<CountryFact>();
            mockList.Add(new CountryFact() { CountryName = "United States", Population = 317996000 });
            mockList.Add(new CountryFact() { CountryName = "Mexico", Population = 118395054 });

            return mockList.AsQueryable();
        }
    }
}
