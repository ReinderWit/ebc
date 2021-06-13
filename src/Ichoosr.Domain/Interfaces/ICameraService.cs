using Ichoosr.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ichoosr.Domain.Interfaces
{
    public interface ICameraService
    {
        public Task<IEnumerable<Camera>> FindAllAsync();

        public Task<IEnumerable<Camera>> FindByNameAsync(string name);
    }
}
