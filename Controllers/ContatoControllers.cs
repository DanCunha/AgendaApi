using AgendaAPI.Context;
using AgendaAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly AgendaContext _context;

        public ContatoController(ILogger<ContatoController> logger, AgendaContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            _logger.LogInformation("Hello World");
            return Ok(contato);
        }

        [HttpGet]
        public IActionResult Find()
        {
            _logger.LogInformation("Hello World");
            return Ok("contato");
        }

    }
}