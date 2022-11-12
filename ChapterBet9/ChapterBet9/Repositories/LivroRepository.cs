using ChapterBet9.Contexts;
using ChapterBet9.Models;
using System.Collections.Generic;
using System.Linq;


namespace ChapterBet9.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;

        public LivroRepository(SqlContext context)
        {
            _context = context;
        }


        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro Livro)
        {
            _context.Livros.Add(Livro);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro LivroBuscado = _context.Livros.Find(id);

            if (LivroBuscado != null)
            {
                LivroBuscado.Titulo = livro.Titulo;
                LivroBuscado.QuantidadedePaginas = livro.QuantidadedePaginas;
                LivroBuscado.Disponivel = livro.Disponivel;
            }
            Return Ok(Livro);
        }
    }
}
