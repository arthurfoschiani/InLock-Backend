using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebAPI.Repositories
{
    public class JogosRepository
    {
        /// <summary>
        /// Listar Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include(x => x.IdNavegationEstudio).ToList();
            }
        }

        /// <summary>
        /// Cadastrar Jogos
        /// </summary>
        /// <param name="jogo"></param>
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar os jogos por id em uma lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Jogo</returns>
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);
            }
        }

        /// <summary>
        /// Atualizar um jogo
        /// </summary>
        /// <param name="jogos"></param>
        public void Atualizar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogos.JogoId);
                JogoBuscado.NomeJogo = jogos.NomeJogo;
                ctx.Jogos.Update(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletar um jogo
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Realiza a busca de um jogo pelo nome na lista de jogos
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>jogo</returns>
        public Jogos BuscarPorNome (string nome)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.NomeJogo == nome);
            }
        }

        public List<Jogos> ListarJogosMaisCaros ()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Take(5).OrderByDescending(x => x.Valor).ToList();
            }
        }

        public List<Jogos> ListarJogosMaisRecentes()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Take(5).OrderByDescending(x => x.DataLancamento).ToList();
            }
        }
    }
}
