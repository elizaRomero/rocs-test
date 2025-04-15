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
    public class UpdateActivityTests : ActivityAppServiceTestBase
    {
        [Test]
        public async Task UpdateActivityWithValidParametersUpdatesActivity()
        {
            var now = DateTime.Now;
            var existingActivity = Activity.Create(1, "BuildMachineNow+5Hours", now, now.AddHours(5),
                ActivityType.Create(2, "Build Component", 4, 999), new Worker[] { });

            ActivityRepositoryMock
                .Setup(repo => repo.GetActivityById(existingActivity.Id))
                .ReturnsAsync(existingActivity);

            ReviewConflictsServiceMock
                .Setup(service => service.ReviewConflicts(It.IsAny<Activity>()))
                .Returns(new List<string>());

            var updateActivity = new UpdateActivity
            {
                Id = existingActivity.Id,
                StartDate = now.AddHours(1),
                EndDate = now.AddHours(3)
            };

            await ActivityAppService.UpdateActivity(updateActivity);

            ActivityRepositoryMock.Verify(repo => repo.UpdateActivity(It.Is<Activity>(a =>
                a.StartDate == updateActivity.StartDate &&
                a.EndDate == updateActivity.EndDate)), Times.Once);
        }

    }
}
