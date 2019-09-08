using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAndCollections
{
    class Program
    {
       static Random rnd = new Random();
        static void Main(string[] args)
        {
        
            var collection = new List<Product>();
            for(var i=0;i<10;i++)
            {
                var product = new Product()
                {
                    Name = "Product" + i,
                    Energy = rnd.Next(10, 100)
                };
                collection.Add(product);
            }
            var result = from item in collection
                         where item.Energy < 200
                         orderby item.Energy
                         select item;
           var result2 = collection.Where(item => item.Energy < 200);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            var selectCollection = collection.Select(collections => collections.Energy);
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }
            var orderbyCollection = collection.OrderBy(collections => collections.Energy)
                                              .ThenByDescending(collections=>collections.Name);
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }

            var groupByCollection = collection.GroupBy(collections => collections.Energy);
            foreach(var group in groupByCollection)
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach(var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }
            collection.Reverse();
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(collection.All(item=>item.Energy==10));
            Console.WriteLine(collection.Any(item => item.Energy == 10));

            var prod = new Product();
            Console.WriteLine(collection.Contains(prod));

            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] {2,4,1,3,6 };
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            var union = array.Union(array2);
            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            var intersect = array.Intersect(array2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var except = array2.Except(array);
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var sum = array.Sum();
            var min = collection.Min(p=>p.Energy);
            var max = collection.Max(p => p.Energy);
            var aggregate = array.Aggregate((x, y) => x * y);

            var sum2 = array2.Skip(2).Take(2).Sum();
            Console.WriteLine(sum);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(aggregate);
            Console.WriteLine(sum2);

            var first = array.FirstOrDefault();
            var last = array.LastOrDefault();
           // var single = collection.Single(collections => collections.Energy == 10);
            var elementAt = collection.ElementAt(5);

            Console.ReadKey();
        }
    }
}
