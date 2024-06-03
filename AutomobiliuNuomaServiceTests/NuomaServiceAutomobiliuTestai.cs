using Moq;
using AutomobiliuNuoma.Contracts;
using AutomobiliuNuoma.Models;
using AutomobiliuNuoma.Repositories;
using AutomobiliuNuoma.Services;


namespace AutomobiliuNuomaServiceTests
{
    public class NuomaServiceAutomobiliuTestai
    {
        private  Mock<IDatabaseRepository> _repositoryMock;
        private  INuomaService _nuomaService;

        public NuomaServiceAutomobiliuTestai()
        {
            _repositoryMock = new Mock<IDatabaseRepository>();
            _nuomaService = new NuomaService(_repositoryMock.Object);
        }

        [Fact]
        public void GautiVisusAutomobilius_Test()
        {
            // Arrange
            List<Automobilis> cars =
            [
                new Elektromobilis (1, "Audi", "Etron", 2020, "123asd", 100, 50),
                new NaftosKuroAutomobilis (2, "BMW", "X5", 2005, "12234asda", 80, 80),
            ];
            
            _repositoryMock.Setup(repo => repo.GautiVisusAutomobilius()).Returns(cars);

            // Act
            List<Automobilis> result = _nuomaService.GautiVisusAutomobilius().ToList();

            // Assert
            Assert.Equal(cars.Count, result.Count());
            Assert.Equal(cars, result);
        }

        [Fact]
        public void GautiAutomobiliPagalId_Test()
        {
            // Arrange
            Automobilis automobilis = new NaftosKuroAutomobilis(1, "Audi", "C5", 2002, "12234asda", 60, 20);
            _repositoryMock.Setup(repo => repo.GautiAutomobiliPagalId(1)).Returns(automobilis);

            // Act
            var result = _nuomaService.GautiAutomobiliPagalId(1);

            // Assert
            Assert.Equal(automobilis, result);
        }

        [Fact]
        public void RegistruotiAutomobili_Test()
        {
            // Arrange
            Automobilis automobilis = new Elektromobilis(1, "Audi", "Etron", 2020, "123asd", 100, 50);

            // Act
            _nuomaService.RegistruotiAutomobili(automobilis);

            // Assert
            _repositoryMock.Verify(repo => repo.PridetiAutomobili(automobilis), Times.Once);
        }


        [Fact]
        public void AtnaujintiAutomobilioInformacija_Test()
        {
            // Arrange
            Automobilis automobilis = new NaftosKuroAutomobilis(1, "BMW", "X5", 2005, "12234asda", 80, 80);

            // Act
            _nuomaService.AtnaujintiAutomobilioInformacija(automobilis, 1);

            // Assert
            _repositoryMock.Verify(repo => repo.AtnaujintiAutomobili(automobilis, 1), Times.Once);
        }

    }
}