using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Data;
using AnimeAratoBackend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeAratoBackend.Controllers
{
    //for admin use only in editing the database
    [Route("NewEntry")]
    public class DatabaseEntryController : Controller
    {
        IRepository repository { get; set; }
        public DatabaseEntryController(IRepository repository)
        {
            this.repository = repository;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin"), Route("Dbeditor")]
        public IActionResult IndexDB()
        {
            return View("Dbeditor");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, Route("post")]
        public async Task<IActionResult> Post([FromBody]MovieData[] data)
        {
            var msg = await repository.AddBulkMovies(data);
            return Ok(msg);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("{id}"), Route("delete")]
        public string[] Delete(string[] id)
        {
            var count = repository.Delete(id);
            return (id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}"), Route("deleteMovies")]
        public async Task<string> DeleteMovies(string[] id)
        {
            var msg = await repository.deleteBulkMovies(id);
            return (msg);
        }
    }
}
