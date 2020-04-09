using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace MvcCursus.Models
{
    // De base class DbContext bevat een heleboel code voor EntityFramework

    public class MyDbContext : DbContext
    {
        // Vergeet niet om een constructor te maken met DB options
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Membership> Memberships { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Bouw hier de connection string dynamisch op
        //    string cnstr = "";

        //    // En geef hem dan mee aan de options builder
        //    optionsBuilder.UseSqlServer(cnstr);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var st1 = new Student
            {
                StudentID = 1,
                Firstname = "Peter",
                Lastname = "Teeninga",
                DateOfBirth = new DateTime(1994, 4, 3)
            };

            var st2 = new Student
            {
                StudentID = 2,
                Firstname = "Thang",
                Lastname = "Le",
                DateOfBirth = new DateTime(1981, 3, 29)
            };

            var st3 = new Student
            {
                StudentID = 3,
                Firstname = "Xander",
                Lastname = "Wemmers",
                DateOfBirth = new DateTime(1974, 2, 7)
            };

            // Seeding: voeg na het genereren van de DB de volgende objecten toe:
            // Op deze manier is de tabel Students altijd gevuld met deze drie studenten
            modelBuilder.Entity<Student>().HasData(st1, st2, st3);
        }

    }
}
