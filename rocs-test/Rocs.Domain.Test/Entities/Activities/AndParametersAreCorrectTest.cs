using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities.Activities
{
    public class AndParametersAreCorrectTest : CreateActivity
    {
        [Test]
        public void ShouldCreateAnActivityBuildComponentCorrectly()
        {
            Id = 1;
            Name = "ActivityBuildComponent";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddHours(2);
            Type = ActivityType.Create(1, "Build Component", 2, 1);
            Workers = new[] {
                Worker.Create(1, "A")
            };
            CreatingActivity();

            Assert.IsNotNull(Result);  // Check object is not null
            Assert.That(Result.Id, Is.EqualTo(Id));
            Assert.That(Result.Name, Is.EqualTo(Name));
            Assert.That(Result.StartDate, Is.EqualTo(StartDate));
            Assert.That(Result.StartDate, Is.EqualTo(StartDate));
            Assert.That(Result.Type, Is.EqualTo(Type));
            Assert.That(Result.Workers.Count, Is.EqualTo(1));

        }

        [Test]
        public void ShouldCreateAnActivityBuildMachineCorrectly()
        {
            Id = 2;
            Name = "ActivityBuildMachine";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddHours(10);
            Type = ActivityType.Create(1, "Build Machine", 4, 999);
            Workers = new[] {
                Worker.Create(1, "A"),
                Worker.Create(2, "B"),
                Worker.Create(3, "C")
            };
            CreatingActivity();

            Assert.IsNotNull(Result);  // Check object is not null
            Assert.That(Result.Id, Is.EqualTo(Id));
            Assert.That(Result.Name, Is.EqualTo(Name));
            Assert.That(Result.StartDate, Is.EqualTo(StartDate));
            Assert.That(Result.StartDate, Is.EqualTo(StartDate));
            Assert.That(Result.Type, Is.EqualTo(Type));
            Assert.That(Result.Workers.Count, Is.EqualTo(3));
        }
    }
}
