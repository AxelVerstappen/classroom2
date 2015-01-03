using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Classroom2.Models
{
    public class ClassroomModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, 500)]
        public int Places { get; set; }

        public BuildingModel Building { get; set; }
        [Required]
        public int BuildingId { get; set; }
    }

    public class ClassroomContext
        : DbContext
    {
        public IDbSet<BuildingModel> Buildings { get; set; }
        public IDbSet<ClassroomModel> Classrooms { get; set; }

    }
}
