using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository ProjetoRepository;
        private ProjetoRepository _ProjetoRepository;

        public ProjetosController(ProjetoRepository ProjetoRepository)
        {
            _ProjetoRepository = ProjetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ProjetoRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Projeto Projeto = _ProjetoRepository.BuscarPorId(id);

                if (Projeto == null)
                {
                    return NotFound();
                }
                return Ok(Projeto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Projeto Projeto)
        {
            try
            {
                _ProjetoRepository.Cadastrar(Projeto);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto Projeto)
        {
            try
            {
                _ProjetoRepository.Atualizar(id, Projeto);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _ProjetoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
