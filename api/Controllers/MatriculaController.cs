using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using matricula_api.Data;
using matricula_api.Models;
using Microsoft.EntityFrameworkCore;

namespace matricula_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaDbContext _context;

        public MatriculaController(MatriculaDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Matricula>> Get()
            => await _context.Matriculas.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Matricula), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Matricula), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            return matricula == null ? NotFound() : Ok(matricula);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = matricula.Id }, matricula);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Matricula matricula)
        {
            if (id != matricula.Id) return BadRequest();

            _context.Entry(matricula).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id, Matricula matricula)
        {
            var matriculaToDelete = await _context.Matriculas.FindAsync(id);
            if (matriculaToDelete == null) return NotFound();

            _context.Remove(matriculaToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
