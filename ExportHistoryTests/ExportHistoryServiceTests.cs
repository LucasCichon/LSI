using ExportHistoryLib.Application.Services;
using ExportHistoryLib.Common;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Models;
using Moq;
using TddXt.AnyRoot.Collections;
using static TddXt.AnyRoot.Root;

namespace ExportHistoryTests
{
    public class ExportHistoryServiceTests
    {
        private Mock<IExportHistoryRepository> _mockExportRepository;

        private ExportHistoryService _exportHistoryService;


        [SetUp]
        public void Setup()
        {
            _mockExportRepository = new Mock<IExportHistoryRepository>();

            _exportHistoryService = new ExportHistoryService(_mockExportRepository.Object);
        }

        [Test]
        public async Task GetExportHistoriesSuccessfully()
        {
            var repositoryResult = Either<IError, ExportHistoryList>.Success(new ExportHistoryList()
            {
                Items = Any.List<ExportHistory>(3),
                TotalCount = 3
            });

            _mockExportRepository.Setup(s =>  s.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>())).Returns(Task.FromResult(repositoryResult));

            var serviceResult = await _exportHistoryService.GetExportHistoriesAsync(Any.Instance<DateTime>(), Any.Instance<DateTime>(), Any.Instance<string>(), Any.Instance<Pagination>());


            _mockExportRepository.Verify(c => c.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>()), Times.Once);
            _mockExportRepository.Verify(c => c.GetLocationsAsync(), Times.Never);
            Assert.That(repositoryResult, Is.EqualTo(serviceResult));
        }

        [Test]
        public async Task FailToGetExportHistories()
        {
            var repositoryResult = Either<IError, ExportHistoryList>.Error(Any.Instance<IError>());

            _mockExportRepository.Setup(s => s.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>())).Returns(Task.FromResult(repositoryResult));

            var serviceResult = await _exportHistoryService.GetExportHistoriesAsync(Any.Instance<DateTime>(), Any.Instance<DateTime>(), Any.Instance<string>(), Any.Instance<Pagination>());


            _mockExportRepository.Verify(c => c.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>()), Times.Once);
            Assert.That(serviceResult.IsLeft, Is.True);
        }

        [Test]
        public async Task GetLocationsSuccessfully()
        {
            var repositoryResult = Either<IError, List<string>>.Success(Any.Instance<List<string>>());

            _mockExportRepository.Setup(s => s.GetLocationsAsync()).Returns(Task.FromResult(repositoryResult));

            var serviceResult = await _exportHistoryService.GetLocationsAsync();


            _mockExportRepository.Verify(c => c.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>()), Times.Never);
            _mockExportRepository.Verify(c => c.GetLocationsAsync(), Times.Once);
            Assert.That(repositoryResult, Is.EqualTo(serviceResult));
        }

        [Test]
        public async Task FailToGetLocations()
        {
            var repositoryResult = Either<IError, List<string>>.Error(Any.Instance<IError>());

            _mockExportRepository.Setup(s => s.GetLocationsAsync()).Returns(Task.FromResult(repositoryResult));

            var serviceResult = await _exportHistoryService.GetLocationsAsync();

            _mockExportRepository.Verify(c => c.GetExportHistoriesAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<Pagination>()), Times.Never);
            _mockExportRepository.Verify(c => c.GetLocationsAsync(), Times.Once);
            Assert.That(serviceResult.IsLeft, Is.True);
        }
    }
}