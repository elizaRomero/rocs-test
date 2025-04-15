using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Rocs.Domain.Entities;
using Rocs.DTO;
using Moq;


namespace Rocs.Application.Test.Services.ActivityAppServices
{
    [TestFixture]
    public class AddActivityWithNonExistentWorkersTests : ActivityAppServiceTestBase
    {
        [Test]
        public void AddActivityWithNonExistentWorkersThrowsInvalidOperationException()
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

            ActivityTypeRepositoryMock
                .Setup(repo => repo.GetActivityTypeById(newActivity.TypeId))
                .ReturnsAsync(activityType);

            //Pretends that worker with id 2 does not exist
            WorkerRepositoryMock
                .Setup(repo => repo.GetWorkersByIds(newActivity.WorkersIds))
                .ReturnsAsync(new List<Worker> { Worker.Create(1, "A") });

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => ActivityAppService.AddActivity(newActivity));
            Assert.That(exception.Message, Is.EqualTo("Not all sent workers exist"));
        }
    }
}
