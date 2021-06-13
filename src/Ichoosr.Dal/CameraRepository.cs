using Ichoosr.Domain.Interfaces;
using Ichoosr.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ichoosr.Dal
{
    public class CameraRepository : ICameraRepository
    {
        private readonly List<Camera> _cameras = new List<Camera>();

        public CameraRepository()
        {
            ReadCsv();
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await Task.FromResult<List<Camera>>(_cameras);
        }

        private void ReadCsv()
        {
            var lines = File.ReadAllLines(@"C:\Users\reind\Documents\ebc\src\Ichoosr.Dal\bin\Debug\net5.0\Data\cameras.csv");
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    var matches = Regex.Match(parts[0], "[A-Z]{3}-[A-Z]{2}-([0-9]{3}) ");
                    if (matches.Success && matches.Groups.Count == 2)
                    {
                        var id = Int32.Parse(matches.Groups[1].Value);

                        _cameras.Add(new Camera
                        {
                            Number = id,
                            Name = parts[0],
                            Latitude = Double.Parse(parts[1]),
                            Longitude = Double.Parse(parts[2])
                        });
                    }
                }
            }
        }
    }
}
