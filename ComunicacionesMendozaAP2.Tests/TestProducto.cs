using DLN;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesMendozaAP2.Tests
{
    [TestClass]
    public class TestProducto
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos.ProductoId = 2;
            productos.Descripcion = "Iphone 6";
            productos.Costo = 13000;
            productos.Ganancia = 2000;
            productos.Precio = 15000;
            productos.Inventario = 0;
            paso = repositorio.Guardar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos.ProductoId = 2;
            productos.Descripcion = "Iphone 6s plus";
            productos.Costo = 15000;
            productos.Ganancia = 2000;
            productos.Precio = 17000;
            productos.Inventario = 5;
            paso = repositorio.Modificar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos = repositorio.Buscar(id);
            Assert.IsNotNull(productos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            int id = 2;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}
