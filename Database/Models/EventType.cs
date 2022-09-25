﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Event> Events { get; set; }

        public EventType()
        {
            Events = new HashSet<Event>();
        }
    }
}
