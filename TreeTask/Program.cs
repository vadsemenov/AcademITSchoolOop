namespace TreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new BinarySearchTree<int>();

            tree1.Insert(8);

            tree1.Insert(3);

            tree1.Insert(1);
            tree1.Insert(6);
            tree1.Insert(4);
            tree1.Insert(7);

            tree1.Insert(10);
            tree1.Insert(9);
            tree1.Insert(15);
            tree1.Insert(13);

            tree1.Remove(3);

            tree1.Insert(14);

            tree1.WalkInDepthRecursive(PrintIntValue);
            Console.WriteLine();

            tree1.WalkInDepth(PrintIntValue);
            Console.WriteLine();

            tree1.WalkInBreadth(PrintIntValue);
            Console.WriteLine();

            Console.WriteLine(tree1.Search(20));

            Console.WriteLine(tree1.Count);

            Console.WriteLine();

            var distanceComparer = new DistanceComparer();
            var tree2 = new BinarySearchTree<Distance>(distanceComparer);

            tree2.Insert(new Distance { Length = 8 });

            tree2.Insert(new Distance { Length = 3 });
            tree2.Insert(new Distance { Length = 1 });
            tree2.Insert(new Distance { Length = 6 });
            tree2.Insert(new Distance { Length = 4 });
            tree2.Insert(new Distance { Length = 7 });

            tree2.Insert(new Distance { Length = 10 });
            tree2.Insert(new Distance { Length = 15 });
            tree2.Insert(new Distance { Length = 13 });
            tree2.Insert(new Distance { Length = 14 });

            tree2.WalkInDepthRecursive(PrintDistanceLength);
            Console.WriteLine();

            tree2.WalkInDepth(PrintDistanceLength);
            Console.WriteLine();

            tree2.WalkInBreadth(PrintDistanceLength);
            Console.WriteLine();

            tree2.Remove(new Distance { Length = 10 });

            Console.WriteLine(tree2.Search(new Distance { Length = 15 }));

            Console.WriteLine(tree2.Count.ToString());

            Console.Read();
        }

        private static void PrintIntValue(int value)
        {
            Console.Write(value + " ");
        }

        private static void PrintDistanceLength(Distance distance)
        {
            Console.Write(distance.Length + " ");
        }
    }
}
