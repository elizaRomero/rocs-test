using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.DTO;

namespace Rocs.Domain.Test.Services
{
    public class AndThereAreConflicts : ReviewConflicts
    {
        [Test]
        public void ShouldContainConflicts()
        {
            var now = DateTime.Now;
            var workerA = Worker.Create(1, "A");
            var actityType = ActivityType.Create(1, "Build Machine", 4, 999);

            var activity1 = Activity.Create(
                1,
                "BuildMachineNow+5Hours",
                now,
                now.AddHours(5),
                actityType,
                new[] { workerA });

            var activity2 = Activity.Create(
                2,
                "BuildMachineTomorrow+5Hours",
                now.AddDays(1),
                now.AddDays(1).AddHours(5),
                actityType,
                new[] { workerA });

            var allActivities = new List<Activity> { activity1, activity2 };
            workerA.Activities = allActivities;

            activityTest = Activity.Create(
               3,
               "BuildMachineNow+3Hours",
               now.AddHours(3),
               now.AddHours(5),
               actityType,
               new[] { workerA });

            ReviewingConflicts();
            Assert.That(Result.Count, Is.EqualTo(1));
            string errorResult = $"Worker {workerA.Id} - {workerA.Name} has a conflict with activity {activity1.Id} - {activity1.Name}";
            Assert.That(Result.FirstOrDefault(), Is.EqualTo(errorResult));
        }

        [Test]
        public void ShouldRestAfterAnotherActivity()
        {
            var now = DateTime.Now;
            var workerA = Worker.Create(1, "A");
            var actityType = ActivityType.Create(1, "Build Machine", 4, 999);

            var activity1 = Activity.Create(
                1,
                "BuildMachineNow+5Hours",
                now,
                now.AddHours(5),
                actityType,
                new[] { workerA });

            var activity2 = Activity.Create(
                2,
                "BuildMachineTomorrow+5Hours",
                now.AddDays(1),
                now.AddDays(1).AddHours(5),
                actityType,
                new[] { workerA });

            var allActivities = new List<Activity> { activity1, activity2 };
            workerA.Activities = allActivities;

            activityTest = Activity.Create(
               3,
               "BuildMachineNow+7Hours",
               now.AddHours(7),
               now.AddHours(12),
               actityType,
               new[] { workerA });

            ReviewingConflicts();
            Assert.That(Result.Count, Is.EqualTo(1));
            string errorResult = $"Worker {workerA.Id} - {workerA.Name} has not completed the required {actityType.RestHours} hours of rest after activity {activity1.Id} - {activity1.Name}.";
            Assert.That(Result.FirstOrDefault(), Is.EqualTo(errorResult));
        }

        [Test]
        public void ShouldRestBeforeAnotherActivity()
        {
            var now = DateTime.Now;
            var workerA = Worker.Create(1, "A");
            var actityType = ActivityType.Create(1, "Build Component", 2, 1);

            var activity1 = Activity.Create(
                1,
                "BuildComponentNow+3Hours",
                now,
                now.AddHours(3),
                actityType,
                new[] { workerA });

            var activity2 = Activity.Create(
                2,
                "BuildComponentTomorrow+3Hours",
                now.AddDays(1),
                now.AddDays(1).AddHours(3),
                actityType,
                new[] { workerA });

            var allActivities = new List<Activity> { activity1, activity2 };
            workerA.Activities = allActivities;

            activityTest = Activity.Create(
               3,
               "BuildMachineNow+7Hours",
               now.AddHours(-4),
               now.AddHours(-1),
               actityType,
               new[] { workerA });

            ReviewingConflicts();
            Assert.That(Result.Count, Is.EqualTo(1));
            string errorResult = $"Worker {workerA.Id} - {workerA.Name}  won't have completed {actityType.RestHours} hours of rest before activity {activity1.Id} - {activity1.Name}.";
            Assert.That(Result.FirstOrDefault(), Is.EqualTo(errorResult));
        }
    }
}
