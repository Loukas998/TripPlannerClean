﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Domain.Entities.Service_Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Infrastructure.Persistence;

namespace TripPlanner.Infrastructure.Repositories
{
	public class ServiceRepository(TripPlannerDbContext dbContext) : IServiceRepository
	{
		public async Task<int> Add(Service entity)
		{
			dbContext.Services.Add(entity);
			await dbContext.SaveChangesAsync();
			return entity.Id;
		}

		public async Task Delete(Service entity)
		{
			dbContext.Services.Remove(entity);
			await dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Service>> Get()
		{
			var services = await dbContext.Services.ToListAsync();
			return services;
		}

		public async Task<Service?> GetById(int id)
		{
			var service = await dbContext.Services
			.Include(s => s.Rooms == null ? null : s.Rooms)
			.Include(s => s.Trips == null ? null : s.Trips)
			.Include(s => s.Cars == null ? null : s.Cars)
			.FirstOrDefaultAsync(x => x.Id == id);
			return service;
		}

		public async Task SaveChanges() => await dbContext.SaveChangesAsync();
	}
}