using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreTestWebApp.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace CoreTestWebApp.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly CoreTestDbContext _db;

        public CustomersController(CoreTestDbContext context)
        {
            _db = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Customers);
        }
        /*
        public IActionResult Get(ODataQueryOptions<Customer> queryOptions)
        {
            var q = queryOptions.ApplyTo(_db.Customers);
            return Ok(q);
        }
        */
        [EnableQuery]
        public IActionResult Get(int key)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == key);
            return Ok(customer);
        }

        [EnableQuery]
        public IActionResult Post([FromBody]Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return Created(customer);
        }
    }
}
