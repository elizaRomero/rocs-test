using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Rocs.Application.Services;
using Rocs.Domain.Repository;
using Rocs.Domain.Services;

namespace Rocs.Application.Test.Services.ActivityAppServices
{
    public abstract class ActivityAppServiceTestBase
    {
        protected Mock<IActivityTypeRepository> ActivityTypeRepositoryMock;
        protected Mock<IActivityRepository> ActivityRepositoryMock;
        protected Mock<IWorkerRepository> WorkerRepositoryMock;
        protected Mock<IReviewConflictsService> ReviewConflictsServiceMock;
        protected ActivityAppService ActivityAppService;

        [SetUp]
        public void BaseSetUp()
        {
            ActivityTypeRepositoryMock = new Mock<IActivityTypeRepository>();
            ActivityRepositoryMock = new Mock<IActivityRepository>();
            WorkerRepositoryMock = new Mock<IWorkerRepository>();
            ReviewConflictsServiceMock = new Mock<IReviewConflictsService>();

            ActivityAppService = new ActivityAppService(
                ActivityTypeRepositoryMock.Object,
                ActivityRepositoryMock.Object,
                WorkerRepositoryMock.Object,
                ReviewConflictsServiceMock.Object
            );
        }
    }
}
