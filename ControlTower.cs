using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Assignment5V25
{
    class ControlTower
    {
        // Fields
        private ListManager<Airplane> flights;
        private ListBox listB;

        // Property
        public List<Airplane> Flights => flights.Items;

        // Constructor
        public ControlTower(ListBox lst)
        {
            flights = new ListManager<Airplane>();
            listB = lst;
        }

        // Methods
        public void AddPlane(Airplane plane)
        {
            // Register event handler for display
            plane.Landed += OnDisplayInfo;
            plane.TakeOff += OnDisplayInfo;

            // Add to manager and ListBox
            flights.Add(plane);
        }

        public void AddTestValues()
        {
            // Example test values
            var samplePlanes = new List<Airplane>
            {
                new Airplane { Name = "Boing 747 XL", FlightID = "BA100", Destination = "Bangkok", CanLand = true },
                new Airplane { Name = "SAAS Caroline", FlightID = "AA200", Destination = "New York", CanLand = false },
                new Airplane { Name = "Cessna 172", FlightID = "CC300", Destination = "Paris", CanLand = true }
            };

            foreach (var plane in samplePlanes)
                AddPlane(plane);
        }

        public void OnDisplayInfo(object sender, AirplaneEventArgs e)
        {
            // Display event info in the ListBox
            listB.Items.Add($"{e.name}: {e.Message}");
        }

        public void OrderLanding(int index)
        {
            if (index < 0 || index >= flights.Items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var plane = flights.Items[index];
            plane.OnLanding();
        }

        public void OrderTakeOff(int index)
        {
            if (index < 0 || index >= flights.Items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var plane = flights.Items[index];
            plane.OnTakeOff();
        }
    }
}
