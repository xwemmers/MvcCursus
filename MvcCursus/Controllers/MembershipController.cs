using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCursus.Models;
using MvcCursus.ViewModels;

namespace MvcCursus.Controllers
{
    public class MembershipController : Controller
    {
        MyDbContext _ctx;

        public MembershipController(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            Student st = _ctx.Students.First();
            



            ViewBag.Students = new SelectList(_ctx.Students.ToList(), "StudentID", "Fullname");
            ViewBag.Teams = new SelectList(_ctx.Teams.ToList(), "TeamID", "Name");

            var query = from m in _ctx.Memberships
                        select new JoinedMembership
                        {
                            MembershipID = m.MembershipID,
                            Name = m.Team.Name,
                            Description = m.Team.Description,
                            Firstname = m.Student.Firstname,
                            Lastname = m.Student.Lastname
                        };

            var list = query.ToList();

            return View(list);
        }


        [HttpPost]
        public IActionResult Index(int StudentID, int TeamID)
        {
            var m = new Membership();
            m.StudentID = StudentID;
            m.TeamID = TeamID;
            m.When = DateTime.Now;

            _ctx.Memberships.Add(m);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var mem = new Membership { MembershipID = id };
            
            _ctx.Memberships.Remove(mem);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}