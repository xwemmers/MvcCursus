using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCursus.Controllers;
using MvcCursus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcCursusTest
{

    [TestClass]
    class HomeControllerTest
    {
        [TestMethod]
        public void StudentsTest()
        {
            // De HomeController zou eigenlijk nog een DB component moeten krijgen
            // Daarvoor moet de DB gemocked worden met een fake repository
            var home = new HomeController(null);

            ViewResult result = home.Students(null) as ViewResult;


            var studenten = result.Model as List<Student>;

            Assert.AreEqual("Students", result.ViewName);
            Assert.AreEqual(4, studenten.Count);

        }

    }
}
