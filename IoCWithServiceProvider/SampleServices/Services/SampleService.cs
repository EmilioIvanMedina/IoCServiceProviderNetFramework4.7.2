using SampleServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleServices.Services
{
    public class SampleService : ISampleService
    {
        public int GetNumber()
        {
            return 150;
        }
    }
}
