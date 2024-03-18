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
            _logger.LogInformation("Contato Created");
            return CreatedAtAction(nameof(FindById), new { id = contato.Id }, contato);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato is null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("FindByName")]
        public IActionResult FindByName(string nome)
        {
            var contato = _context.Contatos.Where(x => x.Nome.Contains(nome));
            if (contato is null)
                return NotFound();

            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contato contato) {
            var contatoDb = _context.Contatos.Find(id);
            if (contatoDb is null)
                return NotFound();

            contatoDb.Nome = contato.Nome;
            contatoDb.Telefone = contato.Telefone;
            contatoDb.Ativo = contato.Ativo;

            _context.Update(contatoDb);
            _context.SaveChanges();

            return Ok(contatoDb);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var contatoDb = _context.Contatos.Find(id);
            if (contatoDb is null)
                return NotFound();

            _context.Remove(contatoDb);
            _context.SaveChanges();
            return NoContent();
        }

    }
}