# Lab09
# LINQ Manhattan

This program performs analysis on neighborhood data extracted from a JSON file. It uses the Newtonsoft.Json library to deserialize the JSON data into a RootObject and extracts the neighborhoods from the features. It then performs various queries on the neighborhoods and displays the results in an attractive table format.

## Prerequisites

- Newtonsoft.Json library

## Getting Started

1. Clone the repository or download the project files.
2. Ensure that you have the Newtonsoft.Json library installed. If not, you can install it using NuGet or by adding the reference to the library manually.
3. Place your JSON data file in the `Data` directory with the name `data.json`.
4. Open the project in your preferred IDE or editor.
5. Build and run the project.

## Usage

The program performs the following neighborhood queries:

1. All neighborhoods: Outputs all neighborhoods.
2. Named neighborhoods: Filters out neighborhoods without names.
3. Distinct neighborhoods: Removes duplicate neighborhoods.
4. Consolidated neighborhoods: Combines all the previous queries into a single query.

## Console Image:
![Screenshot 2023-07-15 204233](https://github.com/bashar-27/Lab09-LINQ-Manhattan/assets/83985765/af3647c4-3560-44d8-8811-cdd691dc4ea5)
