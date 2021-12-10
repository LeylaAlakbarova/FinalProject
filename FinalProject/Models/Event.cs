using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Event
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImageUrl { get; set; }
		public string Venue { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<EventSpeaker> EventSpeakers { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
