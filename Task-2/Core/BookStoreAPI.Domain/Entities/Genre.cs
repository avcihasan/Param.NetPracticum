﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Domain.Entities
{
    public class Genre:BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
