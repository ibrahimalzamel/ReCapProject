using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rentals : IEntity
    {
        public int RentalsID { get; set; }
        public int CarId { get; set; }
        public int CustomersID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
