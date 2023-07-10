using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFilePath = "../../../Data/data.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON data into a RootObject
            var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);

            Console.WriteLine("========== Neighborhood Analysis ==========\n");

            // Extract the neighborhoods from the features
            var neighborhoods = rootObject.features.Select(f => f.properties.neighborhood).ToList();

            Console.WriteLine("Query 1: All neighborhoods\n");
            PrintMultiColumnTable(neighborhoods);
            Console.WriteLine($"Total: {neighborhoods.Count} neighborhoods\n");

            Console.WriteLine("Query 2: Named neighborhoods\n");
            var namedNeighborhoods = neighborhoods.Where(n => !string.IsNullOrEmpty(n)).ToList();
            PrintMultiColumnTable(namedNeighborhoods);
            Console.WriteLine($"Total: {namedNeighborhoods.Count} neighborhoods\n");

            Console.WriteLine("Query 3: Distinct neighborhoods\n");
            var distinctNeighborhoods = namedNeighborhoods.Distinct().ToList();
            PrintMultiColumnTable(distinctNeighborhoods);
            Console.WriteLine($"Total: {distinctNeighborhoods.Count} neighborhoods\n");

            Console.WriteLine("Query 4: Consolidated neighborhoods\n");
            var consolidatedNeighborhoods = rootObject.features
                .Select(f => f.properties.neighborhood)
                .Where(n => !string.IsNullOrEmpty(n))
                .Distinct()
                .ToList();
            PrintMultiColumnTable(consolidatedNeighborhoods);
            Console.WriteLine($"Total: {consolidatedNeighborhoods.Count} neighborhoods\n");

            Console.WriteLine("Query 4 (using query syntax): Consolidated neighborhoods\n");
            var consolidatedNeighborhoodsQuerySyntax = (from f in rootObject.features
                                                        let n = f.properties.neighborhood
                                                        where !string.IsNullOrEmpty(n)
                                                        select n).Distinct().ToList();
            PrintMultiColumnTable(consolidatedNeighborhoodsQuerySyntax);
            Console.WriteLine($"Total: {consolidatedNeighborhoodsQuerySyntax.Count} neighborhoods\n");
        }

        static void PrintMultiColumnTable(IEnumerable<string> neighborhoods, int columns = 3)
        {
            var neighborhoodList = neighborhoods.ToList();
            int rows = (int)Math.Ceiling((double)neighborhoodList.Count / columns);

            var columnWidth = (Console.WindowWidth - 4) / columns;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = i + j * rows;
                    if (index < neighborhoodList.Count)
                    {
                        Console.Write($"| {neighborhoodList[index],-18}");
                    }
                    else
                    {
                        Console.Write("|".PadRight(columnWidth + 2));
                    }
                }
                Console.WriteLine("|");
            }

            Console.WriteLine(new string('-', Console.WindowWidth - 1));
        }
    }
}
