﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDBDotNet.Models;

namespace MongoDBDotNet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");
            var col = db.GetCollection<Person>("people");

            var person = await col.Find(x => x.Name.StartsWith("Lincoln")).FirstOrDefaultAsync();
            return View(person);
        }
    }

  
}