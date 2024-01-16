using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIwithCodeFirst.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string City { get; set; }
    }
}