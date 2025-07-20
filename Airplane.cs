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
        private DispatcherTimer dispatcherTimer;

        private string originalDestination;
        private string destination;

        public bool CanLand { get; set; }
        public string FlightID { get; set; }
        public double FlightTime { get; set; }
        public TimeOnly localTime { get; set; }
        public string Name { get; set; }
        private double remainingFlightTime;
        public bool IsFlying { get; private set; } = false;

        public event EventHandler<AirplaneEventArgs> Landed;
        public event EventHandler<AirplaneEventArgs> TakeOff;

        public Airplane()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                // if this is the first time Destination is set, store it as original
                if (string.IsNullOrEmpty(originalDestination))
                    originalDestination = value;
            }
        }


        /// <summary>
        /// countdown on timer and stops timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            FlightTime -= 1.0;

            if (FlightTime <= 0)
            {
                StopTimer();
                OnLanding();
            }
        }

        public void OnLanding()
        {
            if (!IsFlying)
                return;

            IsFlying = false;
            Landed?.Invoke(this, new AirplaneEventArgs(Name, "The airplane has landed."));

            // swap destination after landing
            if (Destination != "Home")
                Destination = "Home";
            else
                Destination = originalDestination;
        }

        public void OnTakeOff()
        {
            if (IsFlying)
                return;

            IsFlying = true;
            TakeOff?.Invoke(this, new AirplaneEventArgs(Name, "The airplane has taken off."));

            SetupTimer(); 
        }

        /// <summary>
        /// Setup timer
        /// </summary>
        public void SetupTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Stops timer
        /// </summary>
        public void StopTimer()
        {
            dispatcherTimer.Stop();
        }

        public override string ToString()
        {
            return $"{Name} ({FlightID}) heading for {Destination}";
        }
    }
}
