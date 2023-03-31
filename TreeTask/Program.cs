namespace TreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();

            tree.Insert(8);

            tree.Insert(3);

            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(7);

            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(13);

            tree.Remove(8);

            tree.Insert(14);


            tree.WalkInDepthRecursive(PrintIntValue);
            Console.WriteLine();

            tree.WalkInDepth(PrintIntValue);
            Console.WriteLine();

            tree.WalkInBreadth(PrintIntValue);
            Console.WriteLine();

            tree.Remove(10);

            Console.WriteLine(tree.Search(20));

            Console.WriteLine(tree.Count.ToString());

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
