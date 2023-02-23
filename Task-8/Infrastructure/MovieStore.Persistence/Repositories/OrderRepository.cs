using MovieStore.Persistence.Repositories;
using MovieStore.Application.Repositories;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(MovieStoreAPIDbContext context) : base(context)
        {
        }

        
    }
}
