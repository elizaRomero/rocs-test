using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Rocs.Domain.Entities;
using Rocs.DTO;

namespace Rocs.Application.Test.Services.ActivityAppServices
{
    [TestFixture]
    public class AddActivityWithValidParametersTests : ActivityAppServiceTestBase
    {
        [Test]
        public async Task AddActivityWithValidDataReturnsActivityId()
        {
            var now = DateTime.Now;
            var newActivity = new NewActivity
            {
                Name = "BuildMachineNow+5Hours",
                StartDate = now,
                EndDate = now.AddHours(5),
                TypeId = 2,
                WorkersIds = new List<int> { 1, 2 }
            };

            var activityType = ActivityType.Create(2, "Build Machine", 2, 9999);
            var workers = new List<Worker>
            {
                Worker.Create(1, "A"),
                Worker.Create(2, "B")
            };

            ActivityTypeRepositoryMock
                .Setup(repo => repo.GetActivityTypeById(2))
                .ReturnsAsync(activityType);

            WorkerRepositoryMock
                .Setup(repo => repo.GetWorkersByIds(It.IsAny<IReadOnlyCollection<int>>()))
                .ReturnsAsync(workers);

            ReviewConflictsServiceMock
                .Setup(service => service.ReviewConflicts(It.IsAny<Activity>()))
                .Returns(new List<string>());

            ActivityRepositoryMock
                .Setup(repo => repo.AddActivity(It.IsAny<Activity>()))
                .Returns(Task.CompletedTask);

            var result = await ActivityAppService.AddActivity(newActivity);
            Assert.That(result, Is.EqualTo(0));
        }

    }
}
