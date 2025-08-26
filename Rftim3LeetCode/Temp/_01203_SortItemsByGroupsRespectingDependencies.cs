using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01203_SortItemsByGroupsRespectingDependencies
    {
        /// <summary>
        /// There are n items each belonging to zero or one of m groups where group[i] is the group that 
        /// the i-th item belongs to and it's equal to -1 if the i-th item belongs to no group. 
        /// The items and the groups are zero indexed. A group can have no item belonging to it.
        /// Return a sorted list of the items such that:
        /// The items that belong to the same group are next to each other in the sorted list.
        /// There are some relations between these items where beforeItems[i] is a list containing all the items 
        /// that should come before the i-th item in the sorted array(to the left of the i-th item).
        /// Return any solution if there is more than one solution and return an empty list if there is no solution.
        /// </summary>
        public _01203_SortItemsByGroupsRespectingDependencies()
        {
            int[]? x = SortItems(
                8,
                2,
                [-1, -1, 1, 0, 0, 1, 0, -1],
                [
                    new List<int>(),
                    new List<int>() { 6 },
                    new List<int>() { 5 },
                    new List<int>() { 6 },
                    new List<int>() { 3, 6 },
                    new List<int>(),
                    new List<int>(),
                    new List<int>()
                ]
            );

            int[]? x0 = SortItems(
                8,
                2,
                [-1, -1, 1, 0, 0, 1, 0, -1],
                [
                    new List<int>(),
                    new List<int>() { 6 },
                    new List<int>() { 5 },
                    new List<int>() { 6 },
                    new List<int>() { 3 },
                    new List<int>(),
                    new List<int>() { 4 },
                    new List<int>()
                ]
            );

            int[]? x1 = SortItems(
                5,
                5,
                [2, 0, -1, 3, 0],
                [
                    new List<int>() { 2, 1, 3 },
                    new List<int>() { 2, 4 },
                    new List<int>(),
                    new List<int>(),
                    new List<int>()
                ]
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            int groupId = m;
            for (int i = 0; i < n; i++)
            {
                if (group[i] == -1)
                {
                    group[i] = groupId;
                    groupId++;
                }
            }

            Dictionary<int, List<int>> itemGraph = [];
            int[] itemIndegree = new int[n];
            for (int i = 0; i < n; ++i)
            {
                itemGraph.Add(i, []);
            }

            Dictionary<int, List<int>> groupGraph = [];
            int[] groupIndegree = new int[groupId];
            for (int i = 0; i < groupId; ++i)
            {
                groupGraph.Add(i, []);
            }

            for (int curr = 0; curr < n; curr++)
            {
                foreach (int prev in beforeItems[curr])
                {
                    itemGraph[prev].Add(curr);
                    itemIndegree[curr]++;

                    if (group[curr] != group[prev])
                    {
                        groupGraph[group[prev]].Add(group[curr]);
                        groupIndegree[group[curr]]++;
                    }
                }
            }

            List<int> itemOrder = TopologicalSort(itemGraph, itemIndegree);
            List<int> groupOrder = TopologicalSort(groupGraph, groupIndegree);

            if (itemOrder.Count == 0 || groupOrder.Count == 0) return [];

            Dictionary<int, List<int>> orderedGroups = [];
            foreach (int item in itemOrder)
            {
                if (orderedGroups.TryGetValue(group[item], out List<int>? value)) value.Add(item);
                else orderedGroups[group[item]] = [item];
            }

            List<int> answerList = [];
            foreach (int groupIndex in groupOrder)
            {
                if (orderedGroups.TryGetValue(groupIndex, out List<int>? value)) answerList.AddRange(value);
            }

            return [.. answerList];
        }

        private static List<int> TopologicalSort(Dictionary<int, List<int>> graph, int[] indegree)
        {
            List<int> visited = [];
            Stack<int> stack = new();
            foreach (int key in graph.Keys)
            {
                if (indegree[key] == 0) stack.Push(key);
            }

            while (stack.Count != 0)
            {
                int curr = stack.Pop();
                visited.Add(curr);

                foreach (int prev in graph[curr])
                {
                    indegree[prev]--;
                    if (indegree[prev] == 0) stack.Push(prev);
                }
            }

            return visited.Count == graph.Count ? visited : [];
        }
    }
}