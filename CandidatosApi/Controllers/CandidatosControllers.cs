using CandidatosBusiness;
using CandidatosModel;
using Microsoft.AspNetCore.Mvc;
 
namespace CandidatosApi.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class CandidatosController
(
    CandidatoService candidatoService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var candidatos = candidatoService.ListarTodos();
        return candidatos.Count == 0 ? NoContent() : Ok(candidatos);
    }
 
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var candidato = candidatoService.ObterPorId(id);
        return candidato == null ? NotFound() : Ok(candidato);
    }
 
    [HttpPost]
    public IActionResult Post([FromBody] CandidatoModel candidato)
    {
        if (string.IsNullOrWhiteSpace(candidato.Nome))
            return BadRequest("Nome é obrigatório.");
        var criado = candidatoService.Criar(candidato);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }
 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CandidatoModel candidato)
    {
        if (candidato == null || candidato.Id != id)
            return BadRequest("Dados inconsistentes.");
        return candidatoService.Atualizar(candidato) ? NoContent() : NotFound();
    }
 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return candidatoService.Remover(id) ? NoContent() : NotFound();
    }
}