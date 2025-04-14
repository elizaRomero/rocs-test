using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Services
{
    public class AndThereAreNoConflicts : ReviewConflicts
    {
        [Test]
        public void ShouldNotContainAnyConflicts()
        {
            var now = DateTime.Now;
            var workerA = Worker.Create(1, "A");
            var workerB = Worker.Create(1, "B");
            var actityType = ActivityType.Create(1, "Build Machine", 4, 999);

            var activity1 = Activity.Create(
                1,
                "BuildMachineNow+5Hours",
                now,
                now.AddHours(5),
                actityType,
                new[] { workerA, workerB });

            var activity2 = Activity.Create(
                2,
                "BuildMachineTomorrow+5Hours",
                now.AddDays(1),
                now.AddDays(1).AddHours(5),
                actityType,
                new[] { workerA, workerB });

            var allActivities = new List<Activity> { activity1, activity2 };
            workerA.Activities = allActivities;
            workerB.Activities = allActivities;

            activityTest = Activity.Create(
                3,
                "BuildMachineDayAfterTomorrow+5Hours",
                now.AddDays(2),
                now.AddDays(2).AddHours(5),
                actityType,
                new[] { workerA, workerB });

            ReviewingConflicts();
            Assert.That(Result.Count, Is.EqualTo(0));
        }
    }
}
