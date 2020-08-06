using System;

namespace State
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var ventilator = new Ventilator();

            ventilator.startVentilate();
            ventilator.pauseVentilate();
            ventilator.startVentilate();
            ventilator.stopVentilate();
            ventilator.stopVentilate();

            // OUTPUT
            // Ventilator is ventilating 1
            // Ventilator is ventilating 2
            // Ventilator is ventilating 3
            // Ventilator change state disabled pause
            // Ventilator is paused
            // Ventilator change state enabled start
            // Ventilator is ventilating 1
            // Ventilator is ventilating 2
            // Ventilator is ventilating 3
            // Ventilator change state disabled stop
            // Ventilator is disabled
            // Ventilator is disabled
        }
    }
}
