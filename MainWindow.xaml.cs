using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Numerics;
using System.Reflection.Metadata;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace Assignment5V25
{
    //Assignment 6 

    //////////////////////////////////////////////////
    // The main objectives of this assignment are //
    ////////////////////////////////////////////////

    //• To use records to define immutable data structures.

    //• To use tuples to return multiple values from methods.

    //• To practice working with collections (e.g., Lists, Dictionaries, and HashSets) to manage and organize data.

    //////////////////
    // Description //
    ////////////////

    // We are going to simulate a simple use case of flight departures in an airport.
    // The airport has a control tower.A controller registers a plane to get ready on the runway and
    // to take off using a software with a UI that may be designed as illustrated in the figure below.
    // The top ListBox lists the planes added in a list of airplanes handled by the Control Tower while
    // the lower ListBox is used to display the flight status and other information.The user selects
    // an airplane in the top ListBox before clicking the Take.

    public partial class MainWindow : Window
    {
        private ControlTower tower;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Airport Simulator";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Create an object of ControlTower
            tower = new ControlTower(listBoxPlaneTrafic); 
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            //tower.AddTestValues();  // (Optional)
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            lstPlanes.Items.Clear();

            foreach (var plane in tower.Flights)
            {
                lstPlanes.Items.Add($"{plane.Name} ({plane.FlightID}) heading for {plane.Destination}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbFlightID.Text) ||
                string.IsNullOrWhiteSpace(btDescription.Text) ||
                !double.TryParse(btFlightTime.Text, out double flightTime))
            {
                MessageBox.Show("Please enter valid values for all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var plane = new Airplane
            {
                Name = tbName.Text,
                FlightID = tbFlightID.Text,
                Destination = btDescription.Text,
                FlightTime = flightTime,
                CanLand = true,
                localTime = TimeOnly.FromDateTime(DateTime.Now)
            };

            // Add the plane to the control tower
            tower.AddPlane(plane);

            // Log status message to traffic box only
            listBoxPlaneTrafic.Items.Add($"{plane.Name} ({plane.FlightID}) heading for {plane.Destination} sent to runway!");

            // Update summary view of all planes
            UpdateGUI();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Take Off button

            int index = lstPlanes.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a plane to take off.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            tower.OrderTakeOff(index);

        }
    }
}