using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classroom2.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public virtual List<Classroom> classrooms { get; set; }
    }
}