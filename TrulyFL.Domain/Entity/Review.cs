﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrulyFL.Domain.Entity
{
    public class Review : BaseEntity
    {
        public Guid BookingId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        // Khóa ngoại
        public Booking Booking { get; set; }
    }

}
