using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Abstractions;
using Mediatr.Samples.Application;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr.Samples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IHandler handler;
        private readonly IDomainNotificationService domainNotificationService;

        public CarrinhoController(IHandler handler, IDomainNotificationService domainNotificationService)
        {
            this.handler = handler;
            this.domainNotificationService = domainNotificationService;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdicionarProdutoAoCarrinhoCommand command)
        {
            var result = await handler.Send(command);

            if (!result.Success)
                return BadRequest(new
                {
                    error = true,
                    notifications = await domainNotificationService.GetNotificationsAsync()
                });

            return Ok(result);
        }

    }
}
