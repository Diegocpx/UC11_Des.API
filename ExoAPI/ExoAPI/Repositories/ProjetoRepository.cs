using ExoAPI.Contexts;
using ExoAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace ExoAPI.Repositories
{
    public class ProjetoRepository
    {
        private readonly SqlContext _context;

        public ProjetoRepository(SqlContext context)
        {
            _context = context;
        }


        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto Projeto)
        {
            _context.Projetos.Add(Projeto);

            _context.SaveChanges();
        }

        public void Atualizar(int id, Projeto Projeto)
        {
            Projeto ProjetoBuscado = _context.Projetos.Find(id);

            if (ProjetoBuscado != null)
            {
                ProjetoBuscado.Titulo = Projeto.Titulo;
                ProjetoBuscado.QuantidadePaginas = Projeto.QuantidadePaginas;
                ProjetoBuscado.Disponivel = Projeto.Disponivel;
            }
            _context.Projetos.Update(ProjetoBuscado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto Projetobuscado = _context.Projetos.Find(id);

            _context.Projetos.Remove(Projetobuscado);
            _context.SaveChanges();
        }
    }
}
