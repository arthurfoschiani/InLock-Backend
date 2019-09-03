using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebAPI.Repositories
{
    public class EstudiosRepository
    {
        /// <summary>
        /// Listar os estudios
        /// </summary>
        /// <returns>Uma Lista de estudios</returns>
        public List<Estudios> Listar ()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.IdUsuarioNavegation).ToList();
            }
        }

        /// <summary>
        /// Cadastrar um estudio
        /// </summary>
        /// <param name="estudio"></param>
        public void Cadastrar (Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar por Id em uma lista de estudios
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um estudio</returns>
        public Estudios BuscarPorId (int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }

        /// <summary>
        /// Atualizar estudios
        /// </summary>
        /// <param name="estudio"></param>
        public void Atualizar (Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);
                EstudioBuscado.NomeEstudio = estudio.NomeEstudio;
                ctx.Estudios.Update(EstudioBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletar estudios
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using(InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.Find(id);
                ctx.Remove(EstudioBuscado);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorNome(string nome)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.IdUsuarioNavegation).FirstOrDefault(x => x.NomeEstudio == nome);
            }
        }

        public List<Estudios> BuscarPeloPais (string pais)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Where(x => x.PaisOrigem == pais).ToList();
            }
        }
    }
}
