using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk_Simulation.CustomExceptions.ArgumentExceptions
{
    internal class NullOrWhiteSpaceArgumentEx : ArgumentException
    {
        public NullOrWhiteSpaceArgumentEx(string parameterName)
            : base(GetMessage(parameterName), parameterName) { }

        private static string GetMessage(string parameterName)
        {
            return $"Argument for parameter '{parameterName}' was null or white-space.";
        }
    }
}
