using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnet_shared_volume.Model
{
    public class CounterContext : DbContext
    {
        public CounterContext(DbContextOptions<CounterContext> contextoptions) 
            :base (contextoptions)
        {
            
        }

        public DbSet<CounterModel> Counter {get; set;}
    }
}