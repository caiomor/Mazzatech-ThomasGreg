using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.API.Inputs;
using ThomasGreg.Application.ExceptionsHandler;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email, [FromServices] ClienteModel clienteHandler)
        {
            try
            {
                Cliente cliente = await clienteHandler.Buscar(email);
                return Ok(cliente);
            }
            catch (ClienteNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteInput clienteInput, [FromServices] ClienteModel clienteHandler)
        {
            try
            {
                await clienteHandler.Inserir(clienteInput.Nome, clienteInput.Email, clienteInput.Logotipo);

                return RedirectToAction(nameof(Get), new { email = clienteInput.Email });
            }
            catch (ClienteExistenteException exception)
            {
                return BadRequest(new { exception.Message });
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteInput clienteInput, [FromServices] ClienteModel clienteHandler)
        {
            try
            {
                await clienteHandler.Atualizar(clienteInput.Nome, clienteInput.Email, clienteInput.Logotipo);

                return Ok(new { Message = $"O cliente com o email {clienteInput.Email} foi atualizado com sucesso." });
            }
            catch (ClienteNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }

        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email, [FromServices] ClienteModel clienteHandler)
        {
            try
            {
                await clienteHandler.Remover(email);

                return Ok(new { Message = $"O cliente com o email {email} foi deletado com sucesso." });
            }
            catch (ClienteNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }

        }
    }
}
