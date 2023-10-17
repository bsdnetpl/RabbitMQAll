using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQAll.Models;
using RabbitMQAll.Service;
using System.Runtime.CompilerServices;

namespace RabbitMQAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueSupportController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IInvoceService _invoceService;

        public QueueSupportController(IRabbitMqService rabbitMqService, IInvoceService invoceService)
        {
            _rabbitMqService = rabbitMqService;
            _invoceService = invoceService;
        }
        [HttpPost("AddInvoce")]
        public async Task<ActionResult<Invoce>>AddInvoce()
        {
            FieldInvoce fieldInvoce = new FieldInvoce()
            {
                brutto = 123,
                netto = 100,
                id = Guid.NewGuid(),
                nameValue = "Przegląd kasy fisklanej",
                vat = 23,
               
            };
            Invoce invoce1 = new Invoce()
            {
                dateTimeCreate = DateTime.Now,
                nipBayer = "5771876968",
                Number = "1/10/2023",
                fieldInvoce = fieldInvoce
            };
           await _invoceService.AddInvoce(invoce1);
           _rabbitMqService.SendProductMessage(invoce1);
            return Ok(invoce1);
        }
    }
}
