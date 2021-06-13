using Ichoosr.Domain.Models;
using System.Collections.Generic;

namespace Ichoosr.Web.Models.ViewModels
{
    public class HomepageViewModel
    {
        public IEnumerable<Camera> Cameras { get; set; }

        public IEnumerable<Camera> CamerasThree { get; set; }

        public IEnumerable<Camera> CamerasFive { get; set; }

        public IEnumerable<Camera> CamerasThreeAndFive { get; set; }

        public IEnumerable<Camera> CamerasOther { get; set; }
    }
}
