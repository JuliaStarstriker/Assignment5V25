using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5V25
{
    class AirplaneEventArgs : EventArgs
    {
        // Fields
        private string message;
        public string name;

        // Properties
        public string Flight { get; set; }
        public string Message { get; set; }

        // Constructor
        public AirplaneEventArgs(string name, string message)
        {
            this.name = name;
            this.message = message;

            Flight = name;
            Message = message;
        }
    }
}
