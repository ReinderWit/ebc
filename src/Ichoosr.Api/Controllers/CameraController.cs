using Ichoosr.Domain.Interfaces;
using Ichoosr.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ichoosr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraRepository cameraRepository, ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        public async Task<IEnumerable<Camera>> Get()
        {
            var cameras = await _cameraService.FindAllAsync();
            return cameras;
        }
    }
}
