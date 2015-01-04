using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classroom2.Models
{
    public class ReservationViewModel
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public int SelectedClassroomId { get; set; }
        public List<SelectListItem> Classrooms { get; set; }
    }
}