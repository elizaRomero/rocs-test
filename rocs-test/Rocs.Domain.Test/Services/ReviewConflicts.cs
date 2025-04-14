using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;
using Rocs.Domain.Services;

namespace Rocs.Domain.Test.Services
{
    public class ReviewConflicts
    {
        protected Activity activityTest { get; set; }
        protected IReadOnlyCollection<string> Result { get; set; }

        public void ReviewingConflicts()
        {
            var reviewService = new ReviewConflictsService();
            Result = reviewService.ReviewConflicts(activityTest).ToArray();
        }
    }
}
