using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain.Entities
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int Price{ get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
