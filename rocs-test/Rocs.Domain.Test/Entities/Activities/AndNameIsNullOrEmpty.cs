using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities.Activities
{
    public class AndNameIsNullOrEmpty : CreateActivity
    {
        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectErrorMessageForNull()
        {
            {
                Id = 1;
                Name = null;
                StartDate = DateTime.Now;
                EndDate = DateTime.Now.AddHours(2);
                Type = ActivityType.Create(1, "Build Component", 2, 1);
                Workers = new[] {
                    Worker.Create(1, "A")
            };
                var exception = Assert.Throws<ArgumentNullException>(() => CreatingActivity());
                string errorMessage = "The name cannot be null or empty";
                Assert.That(exception.Message, Does.Contain(errorMessage));
            }
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectErrorMessageForEmpty()
        {
            {
                Id = 1;
                Name = string.Empty;
                StartDate = DateTime.Now;
                EndDate = DateTime.Now.AddHours(2);
                Type = ActivityType.Create(1, "Build Component", 2, 1);
                Workers = new[] {
                    Worker.Create(1, "A")
            };
                var exception = Assert.Throws<ArgumentNullException>(() => CreatingActivity());
                string errorMessage = "The name cannot be null or empty";
                Assert.That(exception.Message, Does.Contain(errorMessage));
            }
        }
    }
}
