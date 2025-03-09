using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }

        // Khóa ngoại
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }

}
