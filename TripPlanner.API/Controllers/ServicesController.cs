﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripPlanner.Application.Services.Commands.CreateService;
using TripPlanner.Application.Services.Commands.DeleteService;
using TripPlanner.Application.Services.Dtos;
using TripPlanner.Application.Services.Queries.GetAllServices;
using TripPlanner.Application.Services.Queries.GetServiceById;
using TripPlanner.Application.Services.Queries.GetUserServices;

namespace TripPlanner.API.Controllers
{
    [ApiController]
	[Route("api/services")]
	public class ServicesController(IMediator mediator) : ControllerBase
	{
		//private static List<string> AllowedRoles = ["User","HotelOwner", "CarRental", "TourismOffice", "Restaurant"];
		[HttpPost]
		[Route("/governorates/{govId}/servicetype/{stId}")]
		[Authorize(Roles = "Administrator")]
		[Authorize(Roles ="HotelOwner")]
		[Authorize(Roles ="CarRental")]
		
		public async Task<IActionResult> AddService(int govId, int stId, [FromBody] CreateServiceCommand command)
		{
			command.GovernorateId = govId;
			command.ServiceTypeId = stId;
			int serId = await mediator.Send(command);
			return CreatedAtAction(nameof(GetServiceById), new { govId, serId }, null);
			//I shouldn't forget to add rate to services table
		}

		[HttpGet]
		[Route("/governorates/{govId}/")]
		public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServicesFromGovernorate(int govId)
		{
			var services = await mediator.Send(new GetAllServicesQuery(govId));
			return Ok(services);
		}
		[HttpGet]
		[Authorize(Roles ="HotelOwner")]
        [Authorize(Roles = "CarRental")]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServicesOfUser(GetUserServicesQuery request)
		{
			var services = await mediator.Send(request);
			return Ok(services);
		}

		[HttpDelete]
		[Route("/governorates/{govId}/service/{serId}")]
		public async Task<IActionResult> DeleteService(int govId, int serId)
		{
			await mediator.Send(new DeleteServiceCommand(govId, serId));
			return NoContent();
		}

		[HttpGet]
		[Route("/governorates/{govId}/service/{serId}")]
		public async Task<ActionResult<ServiceDto>> GetServiceById(int govId, int serId)
		{
			var service = await mediator.Send(new GetServiceByIdQuery(govId, serId));
			return Ok(service);
		}
	}
}
