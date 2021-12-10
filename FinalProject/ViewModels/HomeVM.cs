using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }
        public List<Notice> Notices { get; set; }
        public About About { get; set; }

    }
}
