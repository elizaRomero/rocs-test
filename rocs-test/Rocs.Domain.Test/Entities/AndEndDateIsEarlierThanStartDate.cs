using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities
{
    public class AndEndDateIsEarlierThanStartDate : CreateActivity
    {
        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectErrorMessage()
        {
            {
                Id = 1;
                Name = "ActivityBuildComponent";
                StartDate = DateTime.Now;
                EndDate = DateTime.Now.AddHours(-2);
                Type = ActivityType.Create(1, "Build Component", 2, 1);
                Workers = new[] {
                Worker.Create(1, "A")
            };
                var exception = Assert.Throws<ArgumentException>(() => CreatingActivity());
                Assert.That(exception.Message, Is.EqualTo("End date must be after the start date"));
            }
        }
    }
}
