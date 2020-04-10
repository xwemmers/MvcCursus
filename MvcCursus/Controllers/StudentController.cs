using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCursus.Models;

namespace MvcCursus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // HTTP Verbs
        // GET PUT POST DELETE

        MyDbContext _ctx;

        public StudentController(MyDbContext ctx)
        {
            _ctx = ctx;
            _ctx.ChangeTracker.LazyLoadingEnabled = false;
        }

        //public List<Student> Get()
        //{
        //    return _ctx.Students.ToList();
        //}


        // Dankzij de default waarde mag je search ook weglaten en dan krijg je weer alle studenten terug
        public List<Student> Get([FromQuery]string search = "")
        {
            var query = from s in _ctx.Students
                        where s.Firstname.Contains(search)
                        select s;

            return query.ToList();
        }


        [Route("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var st = _ctx.Students.Find(id);

            if (st == null)
                return NotFound();   //  Status = 404
            else
                return st;       //  Status = 200
        }


    }
}