using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLN
{
    public class EntradaProductosBLL : RepositorioBase<EntradaProductos>
    {
        public bool Guardar(EntradaProductos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.EntradaProductos.Add(entity) != null)
                {
                    var producto = contexto.Productos.Find(entity.ProductoId);
                    //Incrementar la cantidad
                    producto.Inventario += entity.Cantidad;

                    contexto.SaveChanges();
                    paso = true;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                EntradaProductos entradaProducto = contexto.EntradaProductos.Find(id);

                if (entradaProducto != null)
                {
                    var Producto = contexto.Productos.Find(entradaProducto.ProductoId);
                    //Reduce la cantidad
                    Producto.Inventario -= entradaProducto.Cantidad;

                    contexto.Entry(entradaProducto).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(EntradaProductos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<EntradaProductos> repositorio = new RepositorioBase<EntradaProductos>();
            try
            {

                //Buscar

                var EntradaAnterior = repositorio.Buscar(entity.EntradapId);

                int diferencia;
                diferencia = entity.Cantidad - EntradaAnterior.Cantidad;

                var Producto = contexto.Productos.Find(EntradaAnterior.ProductoId);

                Producto.Inventario += diferencia;

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }   
    }
}
