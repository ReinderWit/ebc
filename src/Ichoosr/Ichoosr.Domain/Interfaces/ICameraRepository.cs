using Ichoosr.Domain.Models;
using System.Collections.Generic;

namespace Ichoosr.Domain.Interfaces
{
    public interface ICameraRepository
    {
        public List<Camera> GetAllAsync();
    }
}
