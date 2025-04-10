using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocs.Domain.Entities
{
    public class Worker
    {
        public int Id { get; }

        public string Name { get; set; }

        private Worker(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The creation of a Worker is handled by the Create method, applying the following rule:
        /// 1. The Worker's name must not be null, empty, or contain spaces.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Worker Create(int id, string name) 
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(' ')) { 
                throw new ArgumentNullException("The name cannot be null or contain spaces");
            }
            return new Worker(
                id,
                name
            );
        }
    }
}
