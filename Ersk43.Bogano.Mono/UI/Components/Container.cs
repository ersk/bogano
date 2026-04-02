using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Components
{
    internal class Container
    {
        public List<int> ChildEntities { get; private set; }
        public Container()
        {
            ChildEntities = new();
        }
        public Container(List<int> childEntities)
        {
            ChildEntities = childEntities;
        }
    }
}
