﻿using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Repositories
{
    public interface IGenreRepository:IGenericRepository<Genre>
    {
        Task<Genre> FilterByGenreAsync(string name);

    }
}
