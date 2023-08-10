using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
