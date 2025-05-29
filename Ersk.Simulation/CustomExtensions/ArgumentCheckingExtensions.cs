using Ersk_Simulation.CustomExceptions.ArgumentExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk_Simulation.CustomExtensions
{
    internal static class ArgumentCheckingExtensions
    {
        public static void ThrowIfNullOrWhiteSpace(this string? value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameterName)) { throw new NullOrWhiteSpaceArgumentEx(nameof(parameterName)); }
        }
    }
}
