﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Domain.Entities.Service_Entities.Tourism_Office;

namespace TripPlanner.Domain.Repositories
{
	public interface ITripRepository
	{
		public Task<int> Add(Trip entity);
		public Task Delete(Trip entity);
	}
}