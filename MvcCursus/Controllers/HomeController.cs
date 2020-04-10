using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcCursus.Models;

using Microsoft.AspNetCore.Http;

namespace MvcCursus.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        //[AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // Class level variabele om in deze controller de DB te benaderen
        MyDbContext _ctx;

        public HomeController(MyDbContext ctx)
        {
            // De DB context ctx wordt via Dependency Injection door het MVC framework geinjecteerd in de constructor
            // Sla de ctx op in de class level variabele _ctx
            _ctx = ctx;
        }

        // In de controller worden al je pagina's aangemaakt

        public IActionResult Index()
        {
            int teller = HttpContext.Session.GetInt32("Counter") ?? 0;
            HttpContext.Session.SetInt32("Counter", teller + 1);

            HttpContext.Session.SetString("TEST", "Test sessie geslaagd!");


            // De controller geeft data aan de view mee.

            // Nu is de array hard coded. Later gaan we werken met een echte DB.
            var namen = new[] { "Peter", "Thang", "Xander" };

            return View(namen);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        // De variabelen op de querystring kun je als parameter aan de Students Action meegeven

        public IActionResult Students(string search, int p = 0, int s = 20)      // p is voor paging    s is page size
        {
            ViewBag.SearchText = search;


            // De ViewData en ViewBag zijn hetzelfde object. Ze hebben een andere syntax
            // ViewData["Author"] = "Xander";
            //ViewBag.Author = "Xander";
            //ViewBag.Message = "Het is vandaag " + DateTime.Now.ToString("dddd");

            // Haal de tabel Students uit de DB
            //var list = _ctx.Students.ToList();

            // Gebruik LINQ om te zoeken in de DB
            var query = from st in _ctx.Students
                        where st.Firstname.Contains(search ?? "")       // Als search == null zoek dan op ""
                        select st;

            // Voer de query uit:
            // p is het paginanummer
            // s is de page size
            var list = query.Skip(p * s).Take(s).ToList();

            ViewBag.PageNumber = p;
            ViewBag.PageSize = s;

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Maak nog een Create voor het POSTen van de gegevens

        [HttpPost]
        public IActionResult Create(Student st)        // Model Binding!
        {
            if (ModelState.IsValid)
            {
                // Voeg de student toe aan de DB:
                _ctx.Students.Add(st);
                _ctx.SaveChanges();

                return RedirectToAction("Students");
            }
            else
            {
                return View();
            }

        }


        public IActionResult Edit(int id)
        {
            // Include neemt de gerelateerde data uit de tabel Membership mee
            // ThenInclude laadt de stap daarna: de data uit tabel Team
            var query = from st in _ctx.Students.Include(s => s.Memberships).ThenInclude(x => x.Team)
                        where st.StudentID == id
                        select st;

            return View(query.First());
        }


        [HttpPost]
        public IActionResult Edit(Student st)
        {
            if (ModelState.IsValid)
            {
                _ctx.Students.Add(st);

                // Geen "INSERT" op de DB maar een UPDATE
                // Dit is het enige verschil met de Create functie!
                _ctx.Entry(st).State = EntityState.Modified;

                _ctx.SaveChanges();

                return RedirectToAction("Students");
            }
            else
            {
                return View(st);
            }

        }

        public IActionResult Delete(int id)
        {
            var st = _ctx.Students.Find(id);

            return View(st);
        }

        [HttpPost]
        public IActionResult Delete(int id, Student st)
        {
            try
            {
                st.StudentID = id;
                _ctx.Students.Remove(st);
                _ctx.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //ViewBag.ErrorMessage = ex.Message;

                // Gebruik hier niet ViewBag, want die is alleen voor de eigen View (met de naam Delete)
                // Maar we doen een redirect en dat is een nieuwe request
                // Geef de message daarom mee aan TempData

                TempData["ErrorMessage"] = "Niet gelukt, er is gerelateerde data!";
                TempData["TechnicalMessage"] = ex.InnerException.Message;
            }

            return RedirectToAction("Students");
        }


        public IActionResult Countries()
        {
            return View();
        }

        public IActionResult Cities()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        public IActionResult _Copyright()
        {
            return PartialView();
        }

        public IActionResult Tekst()
        {
            return Content("Hello World");
        }

        public IActionResult PdfFile()
        {
            return File("", "");
        }

        public IActionResult FirstStudent(int id)
        {
            // Gevonden! 
            // Tijdelijk de lazy loading uitschakelen voor deze ene request:
            _ctx.ChangeTracker.LazyLoadingEnabled = false;

            var st = _ctx.Students.Find(id);

            return Json(st);
        }

        public IActionResult AllMemberships(int id)
        {
            var all = from m in _ctx.Memberships
                          //where m.Team.TeamID == id
                      select new
                      {
                          m.Student.Firstname,
                          m.Student.Lastname,
                          m.Team.Name,
                          m.Team.Description,
                          m.When
                      };

            return Json(all.ToList());
        }

        public IActionResult ChatBox()
        {
            return View();
        }

        public IActionResult StudentsVue()
        {
            return View();
        }


    }
}
