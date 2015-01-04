using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classroom2.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ClassroomId { get; set; }
    }
}