using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classroom2.Models
{
    public class ClassroomViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Places { get; set; }

        public int SelectedBuildingId { get; set; }
        public List<SelectListItem> Buildings { get; set; }
    }
}
