﻿using GoldenHour.Application.BloodGroups;
using Microsoft.AspNetCore.Mvc;

namespace GoldenHour.Controllers
{
    public class BloodGroupsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }
    }
}
