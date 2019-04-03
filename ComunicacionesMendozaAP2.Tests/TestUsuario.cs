using System;
using DLN;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComunicacionesMendozaAP2.Tests
{
    [TestClass]
    public class TestUsuario
    {
        [TestMethod]
        public void GuardarTest()
        {
            bool paso;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 5;
            usuarios.Fecha = DateTime.Now;
            usuarios.Nombres = "Katherine Maria Taveras";
            usuarios.NombreUser = "KTM";
            usuarios.Cedula = "05900006857";
            usuarios.Telefono = "8296857858";
            usuarios.Correo = "Kath@gmail.com";
            usuarios.Clave = "061098";
            usuarios.TotalVendido = 0;
            paso = repositorio.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 5;
            usuarios.Fecha = DateTime.Now;
            usuarios.Nombres = "Katherine Taveraz Maria";
            usuarios.NombreUser = "KTM";
            usuarios.Cedula = "05900006857";
            usuarios.Telefono = "8296857858";
            usuarios.Correo = "Kath06@gmail.com";
            usuarios.Clave = "061098";
            usuarios.TotalVendido = 0;
            paso = repositorio.Modificar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 5;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();   
            Usuarios usuarios = new Usuarios();
            usuarios = repositorio.Buscar(id);
            Assert.IsNotNull(usuarios);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            var Listar = repositorio.GetList(x => true);
            Assert.IsNotNull(Listar);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 5;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }
    }
}
