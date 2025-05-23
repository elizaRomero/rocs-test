﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rocs.Domain.Entities
{
    public class Worker
    {
        public int Id { get; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual IReadOnlyCollection<Activity> Activities { get; set; } = new List<Activity>();

        private Worker(int id, string name)
        {
            Id = id;
            Name = name;
        }

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
