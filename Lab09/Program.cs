﻿using Newtonsoft.Json;
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

            // Extract the neighborhoods from the features
            var neighborhoods = rootObject.features.Select(f => f.properties.neighborhood);

            // Query 1: Output all neighborhoods
            Console.WriteLine("All neighborhoods:");
            Console.WriteLine(string.Join(", ", neighborhoods));
            Console.WriteLine("Final Total: " + neighborhoods.Count() + " neighborhoods");

            // Query 2: Filter out neighborhoods without names
            var namedNeighborhoods = neighborhoods.Where(n => !string.IsNullOrEmpty(n));
            Console.WriteLine("\nNamed neighborhoods:");
            Console.WriteLine(string.Join(", ", namedNeighborhoods));
            Console.WriteLine("Final Total: " + namedNeighborhoods.Count() + " neighborhoods");

            // Query 3: Remove duplicates
            var distinctNeighborhoods = namedNeighborhoods.Distinct();
            Console.WriteLine("\nDistinct neighborhoods:");
            Console.WriteLine(string.Join(", ", distinctNeighborhoods));
            Console.WriteLine("Final Total: " + distinctNeighborhoods.Count() + " neighborhoods");

            // Query 4: Consolidated single query
            var consolidatedNeighborhoods = rootObject.features
                .Select(f => f.properties.neighborhood)
                .Where(n => !string.IsNullOrEmpty(n))
                .Distinct();
            Console.WriteLine("\nConsolidated neighborhoods:");
            Console.WriteLine(string.Join(", ", consolidatedNeighborhoods));
            Console.WriteLine("Final Total: " + consolidatedNeighborhoods.Count() + " neighborhoods");

            // Example of using LINQ query syntax instead of method calls
            var consolidatedNeighborhoodsQuerySyntax = (from f in rootObject.features
                                                        let n = f.properties.neighborhood
                                                        where !string.IsNullOrEmpty(n)
                                                        select n).Distinct();
            Console.WriteLine("\nConsolidated neighborhoods (using query syntax):");
            Console.WriteLine(string.Join(", ", consolidatedNeighborhoodsQuerySyntax));
            Console.WriteLine("Final Total: " + consolidatedNeighborhoodsQuerySyntax.Count() + " neighborhoods");
        }
    }
}