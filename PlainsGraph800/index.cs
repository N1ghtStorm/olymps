using System;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine().Split(' ').First());
            var fArray = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            var matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, fArray[i] - 1] = 1;
            }

            var isHavingTriangles = false;

            for (var a = 0; a < n; a++)
            {
                if (isHavingTriangles)
                {
                    break;
                }

                for (var b = 0; b < n; b++)
                {
                    if (isHavingTriangles)
                    {
                        break;
                    }

                    if (matrix[a,b] != 1)
                    {
                        continue;
                    }

                    for (var c = 0; c < n; c++)
                    {
                        if ((matrix[b,c] == 1) && (matrix[c, a] == 1))
                        {
                            Console.WriteLine("YES");
                            isHavingTriangles = true;
                            break;
                        }
                    }
                }


            }

            if (!isHavingTriangles)
                Console.WriteLine("NO");
        }
    }
}
