using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment5V25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            //tower.AddTestValues(); // Optional
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