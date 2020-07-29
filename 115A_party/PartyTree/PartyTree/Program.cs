using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine().Split(' ').First());

            var main_array = new int[n];
            var boss_list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var num = Convert.ToInt32(Console.ReadLine().Split(' ').First());
                main_array[i] = num;

                if (num == -1)
                {
                    boss_list.Add(i + 1);
                }
            }

            var depth = 1;
            var depth_list = new List<int>();
            IterateTreeDepth(boss_list, main_array, depth, depth_list);

            if (depth > 4)
            {
                Console.WriteLine(depth/2);
                return;
            }

            Console.WriteLine(depth_list.Max());
        }

        static void IterateTreeDepth(List<int> boss_list, int[] main_list, int depth, List<int> depth_list)
        {
            var is_last_tree_branch = true;

            foreach (var boss in boss_list)
            {
                var new_boss_list = main_list.Where(x => x == boss).Select(x => Array.IndexOf(main_list, x) + 1).ToList();

                if (new_boss_list.Count > 0)
                {
                    is_last_tree_branch = false;

                    
                    IterateTreeDepth(new_boss_list, main_list, depth, depth_list);
                }
            }

            if (!is_last_tree_branch)
            {
                depth += 1;
                depth_list.Add(depth);
            }
        }
    }
}
