using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCursus.Models
{
    public class Student
    {
        // Primary key:
        [Key]
        public int StudentID { get; set; }
        
        [Required(ErrorMessage = "De voornaam is verplicht")]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";


        [Display(Name = "Geboortedatum")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        // De relatie naar alle Memberships van een Student
        public virtual ICollection<Membership> Memberships { get; set; }


        //[RegularExpression("[0-9]{4} ?[A-Z]{2}")]
        //public string ZipCode { get; set; }


    }
}
