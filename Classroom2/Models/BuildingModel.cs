using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Classroom2.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Coords { get; set; }
        public IEnumerable<ClassroomModel> Classrooms { get; set; }
    }

    /*public class BuildingContext
    : DbContext
    {
        public IDbSet<BuildingModel> Buildings { get; set; }

    }*/
}
