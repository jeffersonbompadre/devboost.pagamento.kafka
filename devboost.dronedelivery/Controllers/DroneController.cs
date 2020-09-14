﻿using devboost.Domain.Handles.Queries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DroneController : ControllerBase
    {
        readonly IDroneHandler _droneService;

        public DroneController(IDroneHandler droneService)
        {
            _droneService = droneService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _droneService.BuscarDrone();
            return Ok(result);
        }
    }
}
