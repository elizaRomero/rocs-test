using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocs.DTO
{
    public class NewActivity
    {
        public int Id { get; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TypeId { get; set; }

        public IReadOnlyCollection<int> WorkersIds { get; set; }
    }
}
