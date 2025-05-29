using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Pathfinding
{
    internal interface IAStarNode<T>
    {
        float EstimatedTotal { get; }
        float MovementCostToHere { get; }
        float Heuristic { get; }
        string Key { get; }
        public IAStarNode<T>? NavigatedFrom { get; }

        void AddNeighborNodesToOpenDictionary(
            Dictionary<string, IAStarNode<T>> openNodes,
            Dictionary<string, IAStarNode<T>> closedNodes);
    }

}
