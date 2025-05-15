using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment5V25
{
    class ControlTower
    {

        public string TowerName { get; set; }

        private List<Airplane> airplanes;

        public ControlTower()
        {
            airplanes = new List<Airplane>();
        }

        public void AddAirplane(Airplane plane)
        {
            airplanes.Add(plane);
        }

        public List<Airplane> GetAllAirplanes()
        {
            return airplanes;
        }
    }
}
