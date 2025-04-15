using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Test.Entities.Workers
{
    [TestFixture]
    public class WorkerTests
    {
        [Test]
        public void CreateWithValidNameShouldReturnWorker()
        {
            int id = 1;
            string name = "A";

            var worker = Worker.Create(id, name);

            Assert.IsNotNull(worker);
            Assert.That(worker.Id, Is.EqualTo(id));
            Assert.That(worker.Name, Is.EqualTo(name));
        }

        [Test]
        public void CreateWithNullNameShouldThrowArgumentNullException()
        {
            int id = 1;
            string name = null;

            var exception = Assert.Throws<ArgumentNullException>(() => Worker.Create(id, name));
            Assert.That(exception.Message, Does.Contain("The name cannot be null or contain spaces"));
        }

        [Test]
        public void CreateWithEmptyNameShouldThrowArgumentNullException()
        {
            int id = 1;
            string name = string.Empty;

            var exception = Assert.Throws<ArgumentNullException>(() => Worker.Create(id, name));
            Assert.That(exception.Message, Does.Contain("The name cannot be null or contain spaces"));
        }


        [Test]
        public void CreateWithSpacesOnNameShouldThrowArgumentNullException()
        {
            int id = 1;
            string name = "A B";

            var exception = Assert.Throws<ArgumentNullException>(() => Worker.Create(id, name));
            Assert.That(exception.Message, Does.Contain("The name cannot be null or contain spaces"));
        }
    }
}
