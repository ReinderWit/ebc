using Ichoosr.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ichoosr.Domain.Interfaces
{
    public interface ICameraRepository
    {
        public Task<IEnumerable<Camera>> GetAllAsync();
    }
}
