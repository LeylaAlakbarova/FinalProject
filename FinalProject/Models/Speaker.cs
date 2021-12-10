﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EventSpeaker> EventSpeakers  { get; set; }
    }
}
