using System;
using System.Linq;
using PropertyMatcher.DataContracts;
using PropertyMatcher.Persister;


namespace PropertyMatcher.Console
{
    class Program
    {
        private static readonly Random Random = new Random();
        private static readonly string[] AgencyCodes = new[] { "OTBRE", "LRE", "CRE" };

        static void Main()
        {

            var propertyPersister = new PropertyPersister();

            //put some test data
            for (var i = 0; i < 5; i++)
            {
                var property = new Property
                {
                    Name = $"{Random.Next(1, 500)} Sydney Tower",
                    Address = $"{Random.Next(1, 1000)} Bourke St, Canterbury NSW 2140",
                    Latitude = Convert.ToDecimal(Random.Next(-90, +90)),
                    Longitude = Convert.ToDecimal(Random.Next(-180, +180)),
                    AgencyCode = GetAgencyCode()
                };

                propertyPersister.Add(property);
            }

            //to validate OTBRE Agency Property
            var otbreProperty = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW.",
                AgencyCode = "OTBRE",
                Latitude = Convert.ToDecimal(-33.859845),
                Longitude = Convert.ToDecimal(151.071256)
            };

            //Add property to validate OTBRE Agency property
            propertyPersister.Add(new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "OTBRE",
                Latitude = Convert.ToDecimal(-33.865646),
                Longitude = Convert.ToDecimal(151.067043)
            });

            //to validate LRE Agency Property
            var sydneyMarkets = new Property()
            {
                Name = "Sydney Markets",
                Address = "500 Bourke St, Canterbury NSW 2140",
                AgencyCode = "LRE",
                Latitude = Convert.ToDecimal(-33.859845),
                Longitude = Convert.ToDecimal(151.071256)
            };

            //to validate LRE Agency Property
            var nearbyProperty = new Property()
            {
                Name = "NearBy Property",
                Address = "6-8 eastborne rd, Homebush West, NSW 2140",
                AgencyCode = "LRE",
                Latitude = Convert.ToDecimal(-33.865646),
                Longitude = Convert.ToDecimal(151.067043)
            };

            //Add property to validate LRE Agency property
            propertyPersister.Add(new Property()
            {
                Name = "1, Sydney Tower",
                Address = "29-31 eastborne rd, Homebush West, NSW 2140",
                AgencyCode = "LRE",
                Latitude = Convert.ToDecimal(-33.866572),
                Longitude = Convert.ToDecimal(151.065584)
            });

            //to validate CRE Agency Property
            var creAgencyProperty = new Property()
            {
                Name = "Sydney Tower Palace",
                Address = "500 Bourke St, Canterbury NSW 2140",
                AgencyCode = "CRE",
                Latitude = 100,
                Longitude = 200
            };


            //Add property to validate CRE Agency
            propertyPersister.Add(new Property()
            {
                Name = "Palace Tower Sydney",
                Address = "500 Bourke St, Canterbury NSW 2140",
                AgencyCode = "CRE",
                Latitude = 100,
                Longitude = 400
            });

            var matcher = new PropertyMatchRules();
            var databaseProperties = propertyPersister.GetProperties();
            foreach (var databaseProperty in databaseProperties)
            {
                //Test for Only The Best Real Estate! property
                if (matcher.IsMatch(otbreProperty, databaseProperty))
                {
                    System.Console.WriteLine($"The {otbreProperty.AgencyCode} Agency Property \"{otbreProperty.Name}\" matches with the property in the database!");
                }

                //Test for Location Real Estate property
                if (matcher.IsMatch(sydneyMarkets, databaseProperty))
                {
                    System.Console.WriteLine($"The {sydneyMarkets.AgencyCode} Agency Property \"{sydneyMarkets.Name}\" matches with the property in the database!");
                }

                //Test 2 for Location Real Estate property
                if (matcher.IsMatch(nearbyProperty, databaseProperty))
                {
                    System.Console.WriteLine($"The {nearbyProperty.AgencyCode} Agency Property \"{nearbyProperty.Name}\" matches with the property in the database!");
                }
                //Test for Contrary Real Estate property
                if (matcher.IsMatch(creAgencyProperty, databaseProperty))
                {
                    System.Console.WriteLine($"The {creAgencyProperty.AgencyCode} Agency Property \"{creAgencyProperty.Name}\" matches with the property in the database!");
                }
            }

            System.Console.Read();

        }

        public static string GetAgencyCode()
        {
            return AgencyCodes[Random.Next(0, 3)];
        }
    }
}
