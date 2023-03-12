using System;

namespace TreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>(8);

            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(7);

            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(13);
            tree.Insert(14);


            tree.WalkInDepthRecursive();
            Console.WriteLine();

            tree.WalkInDepth();
            Console.WriteLine();

            tree.WalkInBreadth();
            Console.WriteLine();

            tree.Remove(10);

            Console.WriteLine(tree.Search(20));

            Console.WriteLine(tree.Count.ToString());

            Console.WriteLine();

            var tree2 = new BinarySearchTree<Distance>(new Distance() { Length = 8 });

            tree2.Insert(new Distance { Length = 3 });
            tree2.Insert(new Distance { Length = 1 });
            tree2.Insert(new Distance { Length = 6 });
            tree2.Insert(new Distance { Length = 4 });
            tree2.Insert(new Distance { Length = 7 });

            tree2.Insert(new Distance { Length = 10 });
            tree2.Insert(new Distance { Length = 15 });
            tree2.Insert(new Distance { Length = 13 });
            tree2.Insert(new Distance { Length = 14 });


            tree2.WalkInDepthRecursive();
            Console.WriteLine();

            tree2.WalkInDepth();
            Console.WriteLine();

            tree2.WalkInBreadth();
            Console.WriteLine();

            tree2.Remove(new Distance { Length = 10 });

            Console.WriteLine(tree2.Search(new Distance { Length = 15 }));

            Console.Read();
        }
    }
}
