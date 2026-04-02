using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Components
{
    internal class Size
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Size(int x, int y)
        {
            X = x; Y = y;
        }
        public Size()
        {
            X = 0; Y = 0;
        }
    }
}
