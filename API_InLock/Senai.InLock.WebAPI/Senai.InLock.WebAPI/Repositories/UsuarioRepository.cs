using Senai.InLock.WebAPI.Domains;
using Senai.InLock.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebAPI.Repositories
{
    public class UsuarioRepository
    {
        /// <summary>
        /// Buscar um Usuario através do email e da senha
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuario</returns>
        public Usuarios BuscarPorEmailSenha (LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
    }
}
