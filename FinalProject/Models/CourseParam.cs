using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CourseParam
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
