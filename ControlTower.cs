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
        private ListManager<Airplane> flights;
        private ListBox listB;

        public List<Airplane> Flights => flights.Items;

        public ControlTower(ListBox lst)
        {
            flights = new ListManager<Airplane>();
            listB = lst;
        }

        /// <summary>
        /// Add Plane
        /// </summary>
        /// <param name="plane"></param>
        public void AddPlane(Airplane plane)
        {
            // Register event handler for display
            plane.Landed += OnDisplayInfo;
            plane.TakeOff += OnDisplayInfo;

            // Add to manager and ListBox
            flights.Add(plane);
        }

        /// <summary>
        /// Add Test Values to program
        /// </summary>
        public void AddTestValues()
        {
            // Example test values
            List<Airplane> samplePlanes = new List<Airplane>
            {
                new Airplane { Name = "Boing 747 XL", FlightID = "BA100", Destination = "Bangkok", CanLand = true },
                new Airplane { Name = "SAAS Caroline", FlightID = "AA200", Destination = "New York", CanLand = false },
                new Airplane { Name = "Cessna 172", FlightID = "CC300", Destination = "Paris", CanLand = true }
            };

            foreach (var plane in samplePlanes)
                AddPlane(plane);
        }

        /// <summary>
        /// Displays info depending on the state of the plane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDisplayInfo(object sender, AirplaneEventArgs e)
        {
            if (sender is Airplane plane)
            {
                string time = DateTime.Now.ToString("HH:mm:ss");

                if (e.Message.Contains("taken off"))
                {
                    listB.Items.Add($"{plane.Name} ({plane.FlightID}) is taking off, destination {plane.Destination}, at {time}!");
                }
                else if (e.Message.Contains("landed"))
                {
                    listB.Items.Add($"{plane.Name} ({plane.FlightID}) has landed in {plane.Destination} {time}");
                }
            }
        }

        /// <summary>
        /// Button for oder to land the plane
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void OrderLanding(int index)
        {
            if (index < 0 || index >= flights.Items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var plane = flights.Items[index];
            plane.OnLanding();
        }

        /// <summary>
        /// Button foroder plane to take off
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void OrderTakeOff(int index)
        {
            if (index < 0 || index >= flights.Items.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var plane = flights.Items[index];
            plane.OnTakeOff();
        }
    }
}
