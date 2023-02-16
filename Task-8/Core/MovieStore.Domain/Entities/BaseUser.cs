using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain.Entities
{
    public class BaseUser:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
