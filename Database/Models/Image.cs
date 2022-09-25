using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Path { get; set; } = "";
        
        public int? UserId { get; set; }
        public User? User { get; set; }

        public Event? Event { get; set; }
    }
}
