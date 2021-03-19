using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalsDetailDto : IDto
    {
        public int RentalsID { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
