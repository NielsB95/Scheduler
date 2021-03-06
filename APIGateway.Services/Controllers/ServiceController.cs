﻿using System.Collections.Generic;
using APIGateway.Services.Entities;
using APIGateway.Services.ServiceRegistration;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Services.Controllers
{
    [ApiController]
    [Route("Services")]
    public class ServiceController : ControllerBase
    {
        private IMicroserviceManager serviceManager;

        public ServiceController(IMicroserviceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost]
        public ActionResult<IList<Microservice>> Add(Microservice service)
        {
            var result = this.serviceManager.Register(service);
            if (result)
                return Ok(service);
            else
                return BadRequest();
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public ActionResult<IList<Microservice>> GetRegisteredServices()
        {
            var services = this.serviceManager.RegisteredServices();
            return Ok(services);
        }
    }
}
