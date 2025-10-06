using System;
using System.Collections.Generic;

namespace EventManagment.Models
{
	public class Ticket
	{
		public Guid Id { get; set; }
		public List<string>? Notes { get; set; } = new();
	}
}