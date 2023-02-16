using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain.Entities
{
    public class Customer:BaseUser
    {
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Genre> LikedGenres { get; set; }

    }
}
