using Ichoosr.Domain.Interfaces;
using Ichoosr.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ichoosr.Business
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraService(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public async Task<IEnumerable<Camera>> FindAllAsync()
        {
            return await _cameraRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Camera>> FindByNameAsync(string name)
        {
            var cameras = await _cameraRepository.GetAllAsync();
            return cameras.Where(c => c.Name.Contains(name));
        }
    }
}
