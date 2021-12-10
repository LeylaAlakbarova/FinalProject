using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public List<CourseParam> CourseParam { get; set; }
        public List<CourseTag> CourseTag { get; set; }

    }
}
