using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieActor> Actors { get; set; }

    }
}
