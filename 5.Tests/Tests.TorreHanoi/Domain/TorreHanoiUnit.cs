using Infrastructure.TorreHanoi.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.TorreHanoi.Domain
{
    [TestClass]
    public class TorreHanoiUnit
    {
        private const string CategoriaTeste = "Domain/TorreHanoi";

        private Mock<ILogger> _mockLogger;

        [TestInitialize]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(s => s.Logar(It.IsAny<string>(), It.IsAny<TipoLog>()));
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Construtor_Deve_Retornar_Sucesso()
        {
            const int qtdDiscosOrigem = 3;
            const int qtdDiscosDemais = 0;

            var torre = new global::Domain.TorreHanoi.TorreHanoi(qtdDiscosOrigem, _mockLogger.Object);

            Assert.IsNotNull(torre);
        
            Assert.AreEqual(torre.Origem.Discos.Count, qtdDiscosOrigem);
            Assert.AreEqual(torre.Intermediario.Discos.Count, qtdDiscosDemais);
            Assert.AreEqual(torre.Destino.Discos.Count, qtdDiscosDemais);
            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.Pendente);
        }

        [TestMethod]
        [TestCategory(CategoriaTeste)]
        public void Processar_Devera_Retornar_Sucesso()
        {
            const int qtdDiscosOrigem = 3;
            const int qtdDiscosDemais = 0;
            const int qtdDiscosEsperadaDestino = 3;
            const int qtdDiscosEsperadaDemais = 0;

            var torre = new global::Domain.TorreHanoi.TorreHanoi(qtdDiscosOrigem, _mockLogger.Object);

            Assert.IsNotNull(torre);
            Assert.AreEqual(torre.Origem.Discos.Count, qtdDiscosOrigem);
            Assert.AreEqual(torre.Intermediario.Discos.Count, qtdDiscosDemais);
            Assert.AreEqual(torre.Destino.Discos.Count, qtdDiscosDemais);
            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.Pendente);

            torre.Processar();

            Assert.AreEqual(torre.Origem.Discos.Count, qtdDiscosEsperadaDemais);
            Assert.AreEqual(torre.Intermediario.Discos.Count, qtdDiscosEsperadaDemais);
            Assert.AreEqual(torre.Destino.Discos.Count, qtdDiscosEsperadaDestino);
            Assert.AreEqual(torre.Status, global::Domain.TorreHanoi.TipoStatus.FinalizadoSucesso);
        }
    }
}
