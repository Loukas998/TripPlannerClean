﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Domain.Entities.Service_Entities.Car_Rental;
using TripPlanner.Domain.Entities.Service_Entities.Hotel;
using TripPlanner.Domain.Entities.Service_Entities.Tourism_Office;

namespace TripPlanner.Domain.Entities.Service_Entities
{
	public class Service
	{
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public string Address { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string ContactNumber { get; set; } = default!;
		public string? ContactEmail { get; set; }

		public int GovernorateId { get; set; }

		public int ServiceTypeId { get; set; }

		public List<Room>? Rooms { get; set; }
		public List<Car>? Cars { get; set; }
		public List<Trip>? Trips { get; set; }
		public List<Reservation>? Reservations { get; set; }
	}
}