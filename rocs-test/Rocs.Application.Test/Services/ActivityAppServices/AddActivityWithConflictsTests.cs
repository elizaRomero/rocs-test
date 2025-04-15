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
    public class AddActivityWithConflictsTests : ActivityAppServiceTestBase
    {
        [Test]
        public void AddActivityWithConflictsThrowsInvalidOperationException()
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
                .Setup(repo => repo.GetActivityTypeById(newActivity.TypeId))
                .ReturnsAsync(activityType);

            WorkerRepositoryMock
                 .Setup(repo => repo.GetWorkersByIds(newActivity.WorkersIds))
                 .ReturnsAsync(workers);

            ReviewConflictsServiceMock
                .Setup(service => service.ReviewConflicts(It.IsAny<Activity>()))
                .Returns(new List<string> { "Worker 1 - A has a conflict with activity 2 - BuildComponentNow+2Hours" });

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => ActivityAppService.AddActivity(newActivity));
            Assert.That(exception.Message, Is.EqualTo("Worker 1 - A has a conflict with activity 2 - BuildComponentNow+2Hours"));
        }
    }
}
