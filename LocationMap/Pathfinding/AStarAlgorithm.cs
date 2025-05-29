

namespace LocationMap.Pathfinding   
{
    internal class AStarAlgorithm<TAStarNode> where TAStarNode : IAStarNode<TAStarNode>
    {
        public TAStarNode startNode { get; }
        public TAStarNode targetNode { get; }

        private Dictionary<string, IAStarNode<TAStarNode>> openNodes;
        private Dictionary<string, IAStarNode<TAStarNode>> closedNodes;

        public AStarAlgorithm(TAStarNode startNode, TAStarNode targetNode)
        {
            this.startNode = startNode;
            this.targetNode = targetNode;


            openNodes = new Dictionary<string, IAStarNode<TAStarNode>>();
            openNodes.Add(startNode.Key, startNode);

            closedNodes = new Dictionary<string, IAStarNode<TAStarNode>>();
        }

        public IAStarNode<TAStarNode>? FindPath()
        {
            while (true)
            {
                if(openNodes.Any() == false)
                {
                    return null;
                }

                IAStarNode<TAStarNode> lowestEstTotalNode = GetLowestEstTotalNode();

                openNodes.Remove(lowestEstTotalNode.Key);

                lowestEstTotalNode.AddNeighborNodesToOpenDictionary(openNodes, closedNodes);

                closedNodes.Add(lowestEstTotalNode.Key, lowestEstTotalNode);

                if (TargetHasBeenReached)
                {
                    IAStarNode<TAStarNode> targetNodeFound = openNodes[targetNode.Key];
                    return targetNodeFound;
                }
            }
        }

        public IAStarNode<TAStarNode> GetLowestEstTotalNode()
        {
            IAStarNode<TAStarNode> lowestEstTotalNode = openNodes.First().Value;


            foreach (string key in openNodes.Keys)
            {
                IAStarNode<TAStarNode> node = openNodes[key];

                if (lowestEstTotalNode.EstimatedTotal > node.EstimatedTotal)
                {
                    lowestEstTotalNode = node;
                }
            }

            return lowestEstTotalNode;
        }

        public bool TargetHasBeenReached => openNodes.ContainsKey(targetNode.Key);
    }



}
