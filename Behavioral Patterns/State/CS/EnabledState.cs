using System;
namespace State
{
    // VENTILATOR
    public class Ventilator
    {
        public IStateVentilator state { get; private set; }

        public bool CurrentState
        {
            get
            {
                return state.currentState();
            }
        }

        public void SetState(IStateVentilator state)
        {
            this.state = state;
        }

        public Ventilator()
        {
            this.state = new EnabledState(this);
        }

        public void startVentilate()
        {
            state.startVentilate();
        }

        public void stopVentilate()
        {
            state.stopVentilate();
        }

        public void pauseVentilate()
        {
            state.pauseVentilate();
        }

        public bool currentState()
        {
            return state.currentState();
        }
    }

    // STATE INTERFACE
    public interface IStateVentilator
    {
        void startVentilate();
        void stopVentilate();
        void pauseVentilate();
        bool currentState();
    }

    // STATE 1
    public class EnabledState: IStateVentilator
    {
        public Ventilator ventilator { get; private set; }

        public EnabledState(Ventilator ventilator)
        {
            this.ventilator = ventilator;
        }

        public void startVentilate()
        {
            Console.WriteLine($"Ventilator is ventilating 1");
            Console.WriteLine($"Ventilator is ventilating 2");
            Console.WriteLine($"Ventilator is ventilating 3");
        }

        public void stopVentilate()
        {
            Console.WriteLine($"Ventilator change state disabled stop");
            ventilator.SetState(new DisabledState(ventilator));
            ventilator.stopVentilate();
        }

        public void pauseVentilate()
        {
            Console.WriteLine($"Ventilator change state disabled pause");
            ventilator.SetState(new DisabledState(ventilator));
            ventilator.pauseVentilate();
        }

        public bool currentState()
        {
            return true;
        }
    }

    // STATE 2
    public class DisabledState: IStateVentilator
    {
        public Ventilator ventilator { get; private set; }

        public DisabledState(Ventilator ventilator)
        {
            this.ventilator = ventilator;
        }

        public void startVentilate()
        {
            Console.WriteLine($"Ventilator change state enabled start");
            ventilator.SetState(new EnabledState(ventilator));
            ventilator.startVentilate();
        }

        public void stopVentilate()
        {
            Console.WriteLine($"Ventilator is disabled");
        }

        public void pauseVentilate()
        {
            Console.WriteLine($"Ventilator is paused");
        }

        public bool currentState()
        {
            return false;
        }
    }
}
