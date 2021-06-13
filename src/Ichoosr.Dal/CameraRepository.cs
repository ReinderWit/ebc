using Ichoosr.Domain.Interfaces;
using Ichoosr.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            using var reader = new StreamReader(@"C:\Users\reind\Documents\ebc\src\Ichoosr.Dal\bin\Debug\net5.0\Data\cameras.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var matches = Regex.Match(line, "[A-Z]{3}-[A-Z]{2}-([0-9]{3})([^;]+);([^;]+);(.+)");

                if (matches.Success && matches.Groups.Count == 5)
                {
                    var id = Int32.Parse(matches.Groups[1].Value);

                    _cameras.Add(new Camera
                    {
                        Number = id,
                        Name = matches.Groups[2].Value.Trim(),
                        Latitude = Double.Parse(matches.Groups[3].Value),
                        Longitude = Double.Parse(matches.Groups[4].Value)
                    });
                }
            }
        }
    }
}
