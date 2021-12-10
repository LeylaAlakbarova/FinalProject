using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class TeacherSkill
    {
        public int Id { get; set; }
        public int SelfAssesedLevel { get; set; }
        public Skill Skill { get; set; }
        public Teacher Teacher { get; set; }

    }
}
