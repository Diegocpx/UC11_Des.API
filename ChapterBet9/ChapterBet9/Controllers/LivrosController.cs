using ChapterBet9.Models;
using ChapterBet9.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterBet9.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository livroRepository;
        private LivroRepository _LivroRepository;

        public LivrosController(LivroRepository livroRepository)
        {
            _LivroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_LivroRepository.Listar());
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
                Livro livro = _LivroRepository.BuscarPorId(id);

                if (Livro == Null)
                {
                    Return NotFound();
                }
                Return Ok(Livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _LivroRepository.Cadastrar(livro);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
