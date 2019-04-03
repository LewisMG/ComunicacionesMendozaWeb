using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLN
{
    public class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static decimal CalcularGanancia(decimal precioventa, decimal preciocompra)
        {
            return preciocompra - precioventa;
        }

        public static List<EntradaProductos> FiltrarEntradaProductos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<EntradaProductos, bool>> filtro = p => true;
            RepositorioBase<EntradaProductos> repositorio = new RepositorioBase<EntradaProductos>();
            List<EntradaProductos> list = new List<EntradaProductos>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ProductoId
                    filtro = p => p.ProductoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Cantidad
                    filtro = p => p.Cantidad == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Productos> FiltrarProductos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Productos, bool>> filtro = p => true;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> list = new List<Productos>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ProductoId
                    filtro = p => p.ProductoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Costo
                    filtro = p => p.Costo == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 5://Ganancia
                    filtro = p => p.Ganancia == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 6://Precio
                    filtro = p => p.Precio == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 7://Inventario
                    filtro = p => p.Inventario == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Ventas> FiltrarVentas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Ventas, bool>> filtro = p => true;
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> list = new List<Ventas>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://VentaId
                    filtro = p => p.VentaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Descripcion
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 5://NombreCliente
                    filtro = p => p.NombreCliente.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 6://TelefonoCliente
                    filtro = p => p.Descripcion.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 7://SubTotal
                    filtro = p => p.SubTotal == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 8://Itbis
                    filtro = p => p.Itbis == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 9://Total
                    filtro = p => p.Total == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuarios> FiltrarUsuarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuarios, bool>> filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://NombreUser
                    filtro = p => p.NombreUser.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 5://Cedula
                    filtro = p => p.Cedula.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 6://Telefono
                    filtro = p => p.Telefono.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 7://Correo
                    filtro = p => p.Correo.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 8://Clave
                    filtro = p => p.Clave.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 9://TotalVendido
                    filtro = p => p.TotalVendido == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        //public static List<VentasDetalle> FiltrarVentasDetalle(int index, string criterio, DateTime desde, DateTime hasta)
        //{
        //    Expression<Func<VentasDetalle, bool>> filtro = p => true;
        //    RepositorioBase<VentasDetalle> repositorio = new RepositorioBase<VentasDetalle>();
        //    List<VentasDetalle> list = new List<VentasDetalle>();

        //    int id = ToInt(criterio);
        //    switch (index)
        //    {
        //        case 0://Todo
        //            break;

        //        case 1://Todo por fecha
        //            filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 2://VDetalleId
        //            filtro = p => p.VDetalleId == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 3://VentaId
        //            filtro = p => p.VentaId == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 4://ProductoId
        //            filtro = p => p.ProductoId == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 5://Producto
        //            filtro = p => p.Producto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 6://Cantidad
        //            filtro = p => p.Cantidad == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 7://Precio
        //            filtro = p => p.Precio == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;

        //        case 8://Importe
        //            filtro = p => p.Importe == id && p.Fecha >= desde && p.Fecha <= hasta;
        //            break;
        //    }

        //    list = repositorio.GetList(filtro);

        //    return list;
        //}
    }
}

