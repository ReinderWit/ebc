using Ichoosr.Domain.Models;
using System.Collections.Generic;

namespace Ichoosr.Web.Models
{
    public class HomepageModel
    {
        public IEnumerable<Camera> Cameras { get; set; }

        public string CamerasJson { get; set; }
    }
}
