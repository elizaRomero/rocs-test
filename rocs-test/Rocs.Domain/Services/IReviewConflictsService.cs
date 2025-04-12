using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocs.Domain.Entities;

namespace Rocs.Domain.Services
{
    public interface IReviewConflictsService
    {
        IEnumerable<string> ReviewConflicts(Activity activity);
    }
}
