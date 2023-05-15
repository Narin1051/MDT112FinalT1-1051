using System;
using System.Collections.Generic;

class City
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<int> Neighbors { get; set; }

    public City(string name, int id)
    {
        Name = name;
        Id = id;
        Neighbors = new List<int>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // รับจำนวนเมือง
        Console.Write("Enter the number of cities: ");
        int numCities = int.Parse(Console.ReadLine());

        // สร้าง List เก็บเมืองทั้งหมด
        List<City> cities = new List<City>();

        // รับข้อมูลของแต่ละเมือง
        for (int i = 0; i < numCities; i++)
        {
            Console.WriteLine("Enter data for city {0}:", i);

            // รับชื่อเมือง
            Console.Write("Name: ");
            string name = Console.ReadLine();

            // สร้างเมือง
            City city = new City(name, i);

            // รับจำนวนเมืองที่ติดต่อกับเมืองนี้
            Console.Write("Number of neighbors: ");
            int numNeighbors = int.Parse(Console.ReadLine());

            // รับเมืองที่ติดต่อกับเมืองนี้
            Console.Write("IDs of neighbors: ");
            for (int j = 0; j < numNeighbors; j++)
            {
                int neighborId = int.Parse(Console.ReadLine());
                if (neighborId < 0 || neighborId >= numCities || neighborId == i || city.Neighbors.Contains(neighborId))
                {
                    Console.WriteLine("Invalid ID");
                    j--;
                }
                else
                {
                    city.Neighbors.Add(neighborId);
                }
            }

            // เพิ่มเมืองลงใน List
            cities.Add(city);
        }

        // แสดงข้อมูลของเมืองทั้งหมด
        Console.WriteLine("\nCity data:");
        foreach (City city in cities)
        {
            Console.WriteLine("ID: {0}, Name: {1}, Neighbors: {2}", city.Id, city.Name, string.Join(",", city.Neighbors));
        }
    }
}