namespace CovidSimulation
{
    class City
    {
        public int id;
        public string name;
        public int infectedLevel = 0;
        public int connectedCityId;
        public City(int id, string name, int connectedCityId)
        {
            this.id = id;
            this.name = name;
            this.connectedCityId = connectedCityId;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cities: ");
            int numCities = int.Parse(Console.ReadLine());

            City[] cities = new City[numCities];
            for (int i = 0; i < numCities; i++)
            {
                Console.Write("Enter city name: ");
                string name = Console.ReadLine();
                Console.Write("Enter number of cities connected to this city: ");
                int numConnected = int.Parse(Console.ReadLine());

                int connectedCityId = -1;
                do
                {
                    Console.Write("Enter the IDs of connected cities (separated by space): ");
                    string[] connectedCityIds = Console.ReadLine().Split(' ');

                    if (connectedCityIds.Length == numConnected)
                    {
                        bool isValid = true;
                        for (int j = 0; j < connectedCityIds.Length; j++)
                        {
                            int id = int.Parse(connectedCityIds[j]);
                            if (id >= numCities || id == i || id == connectedCityId)
                            {
                                isValid = false;
                                Console.WriteLine("Invalid ID");
                                break;
                            }
                            else
                            {
                                connectedCityId = id;
                            }
                        }
                        if (isValid) break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);

                cities[i] = new City(i, name, connectedCityId);
            }

            while (true)
            {
                Console.Write("Enter an event (Outbreak, Vaccinate, Lockdown): ");
                string eventName = Console.ReadLine();

                if (eventName == "Outbreak" || eventName == "Vaccinate" || eventName == "Lockdown")
                {
                    Console.Write("Enter the ID of the affected city: ");
                    int affectedCityId = int.Parse(Console.ReadLine());

                    City affectedCity = cities[affectedCityId];
                    if (eventName == "Outbreak")
                    {
                        affectedCity.infectedLevel++;
                    }
                    else if (eventName == "Vaccinate")
                    {
                        affectedCity.infectedLevel = Math.Max(0, affectedCity.infectedLevel - 1);
                    }
                    else if (eventName == "Lockdown")
                    {
                        City connectedCity = cities[affectedCity.connectedCityId];
                        connectedCity.infectedLevel = Math.Max(0, connectedCity.infectedLevel - 1);
                    }

                    Console.WriteLine("City {0}: {1}, Infected Level: {2}", affectedCity.id, affectedCity.name, affectedCity.infectedLevel);
                }
                else
                {
                    Console.WriteLine("Invalid event");
                }
            }
        }
    }
}