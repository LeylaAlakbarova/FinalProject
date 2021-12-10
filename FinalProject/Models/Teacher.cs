using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public List<TeacherSkill> Skills { get; set; }
        public TeacherDetail TeacherDetail { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
