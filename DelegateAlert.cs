using System;

namespace DelegateAlert
{
    public delegate void EventHandler(string place, double intensity, double probability);
    class Tsunami //publisher
    {
        public event EventHandler send;
        public string place;
        public double intensity;
        double probability;
        public void GetInputTsunami(string place, double intensity)
        {
            this.place = place;
            this.intensity = intensity; 
            CalculateTsunamiProbability();
            Notify();
        }
        public void CalculateTsunamiProbability()
        {
            probability = intensity * 0.7 + 0.3;
        }
        private void Notify()
        {
            if(send != null)
            {
                send(place, intensity, probability);
            }
        }
    }
    class Earthquake //subscriber
    {
        private Tsunami tsunami;
        public void SubscribeTsunami(Tsunami tsunami)
        {
            this.tsunami = tsunami;
            tsunami.send += Tsunami_send;
        }
        public void Tsunami_send(string place, double intensity, double probability)
        {
            Console.WriteLine("The earthquake intensity of " + place + " is Magnitude: " + intensity + ".");
            Console.WriteLine("The probability of " + place + " having a tsunami is: " + probability + "%.");
        }
    }
    class DelegateAlert
    {
        static void Main(string[] args)
        {
            Earthquake earthquake = new Earthquake();
            Tsunami tsunami = new Tsunami();

            Console.WriteLine("--Delegate Earthquake Tsunami Alert--");      
            Console.WriteLine("Enter location of earthquake:");
            string place = Console.ReadLine();
            Console.WriteLine("Enter intensity of earthquake:");
            double intensity = double.Parse(Console.ReadLine());

            earthquake.SubscribeTsunami(tsunami);
            tsunami.GetInputTsunami(place, intensity);
        }
    }
}













