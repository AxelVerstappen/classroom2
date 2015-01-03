using Classroom2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Classroom2.Context
{
    public class ClassroomContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
