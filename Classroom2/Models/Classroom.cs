using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classroom2.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Places { get; set; }

        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
    }
}
