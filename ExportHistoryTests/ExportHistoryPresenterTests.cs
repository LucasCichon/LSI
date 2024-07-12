using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryTests
{
    public class ExportHistoryPresenterTests
    {
        [Fact]
        public void LoadExportHistories_CallsSetExportHistories()
        {
            var viewMock = new Mock<IExportHistoryView>();
            var serviceMock = new Mock<IExportHistoryService>();

            var presenter = new ExportHistoryPresenter(viewMock.Object, serviceMock.Object);

            serviceMock.Setup(s => s.GetExportHistories(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>()))
                .Returns(new List<ExportHistory> { new ExportHistory { ExportName = "Test" } });

            presenter.LoadExportHistories();

            viewMock.Verify(v => v.SetExportHistories(It.IsAny<List<ExportHistory>>()), Times.Once);
        }
    }
}
