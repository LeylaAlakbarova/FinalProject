using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class EventSpeaker
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public Speaker Speaker { get; set; }
    }
}
