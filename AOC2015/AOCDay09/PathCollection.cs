using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{


    public class PathCollection<T> : IPathCollection        
    {
        /// <summary>
        /// Used to find the Shortest and Longest distances visiting all ends of a set of paths.  
        /// Uses brute force to calculate the distances.
        /// NOTE: Assumes there is a path between all ends!
        /// </summary>
        /// 
        private List<T> _ends = new List<T>();
        private List<IPath<T>> _paths = new List<IPath<T>>();

        public PathCollection(List<IPath<T>> paths)
        {
            _paths = paths;
            FillEnds();
        }

        private void FillEnds()
        {
            foreach (IPath<T> path in _paths)
            {
                if (_ends.Contains(path.Ends[0]) == false)
                    _ends.Add(path.Ends[0]);

                if (_ends.Contains(path.Ends[1]) == false)
                    _ends.Add(path.Ends[1]);
            }
        }

        public Int32 ShortestDistance()
        {
            List<T[]> permutations = Permute<T>.PermuteToList(_ends.ToArray());
            Int32 shortestRoute = Int32.MaxValue;
            T[] shortestRoutePermutation = new T[_ends.Count()];

            foreach (T[] permutation in permutations)
            {
                Int32 currentDistance = 0;
                bool exitedEarly = false;

                for (int i = 0; i < permutation.Length - 1; i++)
                {
                    IPath<T> path = _paths.Where(x => x.Ends.Contains(permutation[i]))
                                          .Where(y => y.Ends.Contains(permutation[i + 1])).First();

                    currentDistance = currentDistance + path.Distance;

                    if (currentDistance >= shortestRoute)
                    {
                        exitedEarly = true;
                        break;
                    }
                }

                if (exitedEarly == false)
                {
                    if (currentDistance < shortestRoute)
                    {
                        shortestRoute = currentDistance;
                        permutation.CopyTo(shortestRoutePermutation, 0);
                    }
                }
            }

            return shortestRoute;
        }

        public Int32 LongestDistance()
        {
            List<T[]> permutations = Permute<T>.PermuteToList(_ends.ToArray());
            Int32 longestRoute = 0;
            T[] longestRoutePermutation = new T[_ends.Count()];

            foreach (T[] permutation in permutations)
            {
                Int32 currentDistance = 0;

                for (int i = 0; i < permutation.Length - 1; i++)
                {
                    IPath<T> path = _paths.Where(x => x.Ends.Contains(permutation[i]))
                                          .Where(y => y.Ends.Contains(permutation[i + 1])).First();

                    currentDistance = currentDistance + path.Distance;
                }

                if (currentDistance > longestRoute)
                {
                    longestRoute = currentDistance;
                    permutation.CopyTo(longestRoutePermutation, 0);
                }

            }

            return longestRoute;
        }
    }
}
