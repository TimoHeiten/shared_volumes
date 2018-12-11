using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using dotnet_shared_volume.Model;

namespace dotnet_shared_volume.Repository
{
    internal class DbRepository : IRepository
    {
        private readonly CounterContext _context;
        public DbRepository(CounterContext context)
        {
            _context = context;
        }
        public async Task AddCounter()
        {
            await _context.Counter.AddAsync(new CounterModel 
                { VisitedAt = DateTimeOffset.UtcNow });
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<CounterModel>> GetCountAsync()
        {
            IEnumerable<CounterModel> models = _context.Counter.ToList();
            return Task.FromResult(models);
        }
    }
}