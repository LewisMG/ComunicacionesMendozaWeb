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
    public class RepositorioVentas : RepositorioBase<Ventas>
    {
        public override bool Guardar(Ventas venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();

            try
            {
                if (contexto.Venta.Add(venta) != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }

                    contexto.Usuarios.Find(venta.UsuarioId).TotalVendido += venta.Total;
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Usuarios> usu = new RepositorioBase<Usuarios>();

            try
            {
                var Ventas = Buscar(venta.VentaId);
                var Usuario = contexto.Usuarios.Find(venta.UsuarioId);
                var UsuarioAnt = contexto.Usuarios.Find(Ventas.UsuarioId);

                if (venta.UsuarioId != Ventas.UsuarioId)
                {
                    Usuario.TotalVendido += venta.Total;
                    UsuarioAnt.TotalVendido -= Ventas.Total;
                    usu.Modificar(Usuario);
                    usu.Modificar(UsuarioAnt);
                }

                if (Ventas != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;

                        if (!venta.Detalle.ToList().Exists(si => si.VDetalleId == item.VDetalleId))
                        {
                            item.Producto = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in venta.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;

                        var estado = item.VDetalleId > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }

                    Ventas EntradaAnterior = Buscar(venta.VentaId);

                    decimal diferencia;
                    diferencia = venta.Total - EntradaAnterior.Total;

                    Usuarios usuarios = usu.Buscar(venta.UsuarioId);
                    usuarios.TotalVendido += diferencia;
                    usu.Modificar(usuarios);

                    contexto.Entry(venta).State = EntityState.Modified;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Ventas venta = contexto.Venta.Find(id);

                if (venta != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;
                    }

                    contexto.Usuarios.Find(venta.UsuarioId).TotalVendido -= venta.Total;
                    venta.Detalle.Count();
                    contexto.Venta.Remove(venta);
                }

                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public override Ventas Buscar(int id)
        {
            Ventas venta = new Ventas();
            Contexto contexto = new Contexto();

            try
            {
                venta = contexto.Venta.Find(id);
                if (venta != null)
                {
                    venta.Detalle.Count();

                    foreach (var item in venta.Detalle)
                    {
                        string s = item.Productos.Descripcion;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return venta;
        }

        public override List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            List<Ventas> ventas = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                ventas = contexto.Venta.Where(expression).ToList();
                foreach (var item in ventas)
                {
                    item.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return ventas;
        }

        public static List<VentasDetalle> GetListDetalle(Expression<Func<VentasDetalle, bool>> expression)
        {
            List<VentasDetalle> ventas = new List<VentasDetalle>();
            Contexto contexto = new Contexto();

            try
            {
                ventas = contexto.Ventas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return ventas;
        }

        public static int CalcularImporte(int precio, int cantidad)
        {
            return precio * cantidad;
        }

        public static decimal CalcularItbis(decimal subtotal)
        {
            return Convert.ToDecimal(subtotal) * Convert.ToDecimal(0.18);
        }

        public static decimal CalcularTotal(decimal subtotal, decimal itbis)
        {
            return Convert.ToDecimal(subtotal) + Convert.ToDecimal(itbis);
        }
    }
}
