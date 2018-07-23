using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTestWebApp.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestWebApp.Controllers
{
    public class UsersController : ODataController
    {
        private readonly CoreTestDbContext _db;

        public UsersController(CoreTestDbContext context)
        {
            _db = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Users);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Users.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody]User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return Created(user);
        }
    }
}
