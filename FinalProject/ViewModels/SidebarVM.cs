using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class SidebarVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
    }
}
