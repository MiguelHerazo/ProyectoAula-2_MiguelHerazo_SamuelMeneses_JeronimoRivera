using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoEmprendimientos;


namespace PruebasProyecto
{
    [TestClass]
    public class IdeaDeNegocioTests
    {
        [TestMethod]
        public void CalcularRentabilidad_DebeCalcularRentabilidadCorrectamente()
        {
            IdeaDeNegocio idea = new IdeaDeNegocio
            {
                ValorInversion = 1000,
                Ingresos3Anios = 3000
            };
            decimal rentabilidad = idea.CalcularRentabilidad();
            Assert.AreEqual(2000, rentabilidad); 
        }
    }
}
