using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLN
{
    public class RepositorioLogin
    {
        private List<Usuarios> Listar(Expression<Func<Usuarios, bool>> expression)
        {
            Contexto _contexto = new Contexto();
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = _contexto.Set<Usuarios>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        public bool Auntenticar(string usuario, string contraseña)
        {

            Expression<Func<Usuarios, bool>> filtrar = x => true;
            filtrar = t => t.NombreUser.Equals(usuario) && t.Clave.Equals(contraseña);
            bool paso = false;
            if (Listar(filtrar).Count() != 0)
            {
                paso = true;
            }
            return paso;
        }
    }
}
