using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Assignment5V25
{
    class Airplane
    {
        // Field
        private DispatcherTimer dispatcherTimer;

        // Properties
        public bool CanLand { get; set; }
        public string Destination { get; set; }
        public string FlightID { get; set; }
        public double FlightTime { get; set; }
        public TimeOnly localTime { get; set; }
        public string Name { get; set; }

        // Events
        public event EventHandler<AirplaneEventArgs> Landed;
        public event EventHandler<AirplaneEventArgs> TakeOff;

        // Constructor
        public Airplane()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        // Methods
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            FlightTime += 1.0;
        }

        public void OnLanding()
        {
            Landed?.Invoke(this, new AirplaneEventArgs(Name, "The airplane has landed."));
        }

        public void OnTakeOff()
        {
            TakeOff?.Invoke(this, new AirplaneEventArgs(Name, "The airplane has taken off."));
        }

        public void SetupTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        public void StopTimer()
        {
            dispatcherTimer.Stop();
        }

        public override string ToString()
        {
            return $"{Name} ({FlightID}) → {Destination} | Can Land: {CanLand} | Flight Time: {FlightTime} mins";
        }
    }
}
