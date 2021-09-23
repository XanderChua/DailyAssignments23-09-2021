using System;
using System.Threading;

namespace DelegateCounterPrintEvent
{
    public delegate void EventHandler(int count);   
    class Counter
    {
        public event EventHandler send;
        int count;
        public void GetInput(int count)
        {
            this.count = count;
            Notify();
            checkCounter();
        }
        public void checkCounter()
        {
            if (count == 20)
            {
                Console.WriteLine("Event Received");
            }
        }
        private void Notify()
        {
            if (send != null)
            {
                send(count);
            }
        }
    }
    class DelegateCounterPrintEvent
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Delegate Counter--");
            Counter counter = new Counter();
            counter.send += Counter_send;         
            for (int i = 1; i < 21; i++)
            {

                counter.GetInput(i);         
            }
           
            Console.ReadLine();
        }
        private static void Counter_send(int count)
        {
            Console.WriteLine("Counter: " + count);
            Thread.Sleep(500);
        }
    }
}
