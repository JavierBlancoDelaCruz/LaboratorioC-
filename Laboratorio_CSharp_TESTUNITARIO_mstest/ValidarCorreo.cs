using Laboratorio_CSharp_TESTUNITARIO_programa;
using Moq;
using System.Text.RegularExpressions;

namespace Laboratorio_CSharp_TESTUNITARIO_mstest
{
    [TestClass]
    public class ValidarCorreo
    {
        [TestMethod]
        public void Devuelve_True_en_Validar1()
        {
            // Arrange
            var correo = new Correo();
            var correo_test = "ejemplo@email.abc";

            //var ListaCorreosMock = new Mock<List<string>>();
            //ListaCorreosMock.Setup(l => l.Contains("ejemplo@email.abc")).Returns(true);

            // Act
            var valido = correo.Validar1(correo_test);
            //bool valido = Correo.Validar2("correo@ejemplo.com", ListaCorreosMock.Object);

            // Assert
            Assert.IsTrue(valido);
        }

        [TestMethod]
        public void Devuelve_False_en_Validar1()
        {
            // Arrange
            var correo = new Correo();
            var correo_test = "ejemplo-mal@email0.abc";
            // var mockCorreosValidados = new Mock<List<string>>();
            // mockCorreosValidados.Setup(m => m.Contains("correo@ejemplo.com")).Returns(false);

            // Act
            var valido = correo.Validar1(correo_test);
            // var resultado = CorreoElectronico.ValidarCorreoElectronico("correo@ejemplo.com", mockCorreosValidados.Object);

            // Assert
            Assert.IsFalse(valido);
            // Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Devuelve_True_en_Validar2_por_correo_valido_sin_haber_aun_correos_validos_en_la_lista()
        {
            //Arrange
            var c = new Correo();
            var correo = "ejemplo@email.abc";
            var listaCorreos = new List<string>();

            //Act
            var valido = c.Validar2(correo, listaCorreos);

            //Assert
            Assert.IsTrue(valido);
            Assert.AreEqual(1, listaCorreos.Count); //1 Porque al validarlo lo añade a la lista
        }

        [TestMethod]
        public void Devuelve_True_en_Validar2_por_correo_valido_añadido_ya_en_la_lista()
        {
            //Arrange
            var c = new Correo();
            var correo = "ejemplo@email.abc";
            var listaCorreos = new List<string>() { "correo1@email.abc", correo , "correo3@email.abc"};

            //Act
            var valido = c.Validar2(correo, listaCorreos);

            //Assert
            Assert.IsTrue(valido);
            Assert.AreEqual(3, listaCorreos.Count); //3 Porque ya habían tres correos en la lista
        }

        [TestMethod]
        public void Devuelve_False_en_Validar2_por_correo_invalido_no_añadido_en_la_lista()
        {
            //Arrange
            var c = new Correo();
            var correo = "ejemplo-mal@email0.abc";
            var listaCorreos = new List<string>();

            //Act
            var valido = c.Validar2(correo, listaCorreos);

            //Assert
            Assert.IsFalse(valido);
            Assert.AreEqual(0, listaCorreos.Count); //0 Porque al ser el correo inválido NO se agrega a la lista
        }

        [TestMethod]
        public void Devuelve_False_en_Validar2_por_correo_invalido_habiendo_ya_correos_validos_en_la_lista()
        {
            //Arrange
            var c = new Correo();
            var correo = "ejemplo-mal@email0.abc";
            var listaCorreos = new List<string>() { "ejemplo@email.abc" };

            //Act
            var valido = c.Validar2(correo, listaCorreos);

            //Assert
            Assert.IsFalse(valido);
            Assert.AreEqual(1, listaCorreos.Count);
        }
    }
}