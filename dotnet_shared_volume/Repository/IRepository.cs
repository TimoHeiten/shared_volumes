using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using dotnet_shared_volume.Model;

namespace dotnet_shared_volume.Repository
{
    public interface IRepository
    {
        Task AddCounter();
        Task<IEnumerable<CounterModel>> GetCountAsync();
    }
}