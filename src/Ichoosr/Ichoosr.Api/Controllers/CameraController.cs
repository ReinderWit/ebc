using Ichoosr.Domain.Interfaces;
using Ichoosr.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ichoosr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly ILogger<CameraController> _logger;
        private readonly ICameraRepository _cameraRepo;

        public CameraController(ICameraRepository cameraRepository, ILogger<CameraController> logger)
        {
            _cameraRepo = cameraRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Camera>> Get()
        {
            var cameras = await _cameraRepo.GetAllAsync();
            return cameras;
        }
    }
}
