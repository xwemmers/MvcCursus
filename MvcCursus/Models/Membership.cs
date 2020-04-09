using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCursus.Models
{
    public class Membership
    {
        public int MembershipID { get; set; }

        public DateTime When { get; set; }


        // Lazy loading werkt alleen voor virtual properties!

        public virtual Student Student { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public virtual Team Team { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }


        // EF maakt de ID velden voor foreign key relaties
    }
}
