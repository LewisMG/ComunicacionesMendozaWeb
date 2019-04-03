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
    public class TestEntradaProducto
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            EntradaProductos entradaProductos = new EntradaProductos();
            EntradaProductosBLL productosBLL = new EntradaProductosBLL();
            entradaProductos.EntradapId = 1;
            entradaProductos.Fecha = DateTime.Now;
            entradaProductos.ProductoId = 1;
            entradaProductos.Cantidad = 5;
            paso = productosBLL.Guardar(entradaProductos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            EntradaProductos entradaProductos = new EntradaProductos();
            EntradaProductosBLL productosBLL = new EntradaProductosBLL();
            entradaProductos.EntradapId = 1;
            entradaProductos.Fecha = DateTime.Now;
            entradaProductos.ProductoId = 1;
            entradaProductos.Cantidad = 2;
            paso = productosBLL.Modificar(entradaProductos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            EntradaProductos entradaProductos = new EntradaProductos();
            EntradaProductosBLL productosBLL = new EntradaProductosBLL();
            entradaProductos = productosBLL.Buscar(id);
            Assert.IsNotNull(entradaProductos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            EntradaProductosBLL productosBLL = new EntradaProductosBLL();
            var Listar = productosBLL.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 1;
            EntradaProductosBLL productosBLL = new EntradaProductosBLL();
            paso = productosBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}

