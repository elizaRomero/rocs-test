using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities.ActivityTypes
{
    [TestFixture]
    public class ActivityTypeTests
    {
        [Test]
        public void CreateWithValidParametersShouldReturnActivityType()
        {
            int id = 1;
            string name = "Build Component";
            int restHours = 2;
            int limitWorkers = 1;

            var activityType = ActivityType.Create(id, name, restHours, limitWorkers);

            Assert.IsNotNull(activityType);
            Assert.That(activityType.Id, Is.EqualTo(id));
            Assert.That(activityType.Name, Is.EqualTo(name));
            Assert.That(activityType.RestHours, Is.EqualTo(restHours));
            Assert.That(activityType.LimitWorkers, Is.EqualTo(limitWorkers));
        }

        [Test]
        public void CreateWithNullNameShouldThrowArgumentNullException()
        {
            int id = 1;
            string name = null;
            int restHours = 2;
            int limitWorkers = 1;

            var exception = Assert.Throws<ArgumentNullException>(() => ActivityType.Create(id, name, restHours, limitWorkers));
            Assert.That(exception.Message, Does.Contain("The name cannot be null or empty"));
        }

        [Test]
        public void CreateWithEmptyNameShouldThrowArgumentNullException()
        {
            int id = 1;
            string name = string.Empty;
            int restHours = 2;
            int limitWorkers = 1;

            var exception = Assert.Throws<ArgumentNullException>(() => ActivityType.Create(id, name, restHours, limitWorkers));
            Assert.That(exception.Message, Does.Contain("The name cannot be null or empty"));
        }

        [Test]
        public void CreateWithNegativeRestHoursShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            int id = 1;
            string name = "Build Component";
            int restHours = -1;
            int limitWorkers = 1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ActivityType.Create(id, name, restHours, limitWorkers));
            Assert.That(exception.Message, Does.Contain("Rest hours cannot be negative"));
        }

        [Test]
        public void CreateWithZeroLimitWorkersShouldThrowArgumentOutOfRangeException()
        {
            int id = 1;
            string name = "Build omponent";
            int restHours = 2;
            int limitWorkers = 0;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ActivityType.Create(id, name, restHours, limitWorkers));
            Assert.That(exception.Message, Does.Contain("Limit workers must be greater than zero"));
        }
    }
}
