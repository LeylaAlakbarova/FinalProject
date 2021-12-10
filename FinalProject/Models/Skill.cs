﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherSkill> Skills { get; set; }

    }
}
