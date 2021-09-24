using System;
using System.Collections.Generic;

namespace DelegateHotelMgmtSystem
{
    public delegate void EventHandler(int a, int b, int c);
    class Services //publisher
    {
        public event EventHandler serviceAdded;
        int a;
        int b;
        int c;
        public void GetServiceInput(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            serviceA();
            serviceB();
            serviceC();
            sendBack();
        }
        public void serviceA()
        {
            a = 50;
        }
        public void serviceB()
        {
            b = 100;
        }
        public void serviceC()
        {
            c = 150;
        }

        private void sendBack()
        {
            if (serviceAdded != null)
            {
                serviceAdded(a, b, c);
                //serviceAdded.Invoke(a, b, c);
                //serviceAdded.BeginInvoke(a, b, c, null,null);
            }
        }
    }
    class DelegateHotelMgmtSystem //subscriber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Delegate Hotel Management--");
            Services services = new Services();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please book a room: ");
                Console.WriteLine("1. Regular");
                Console.WriteLine("2. Deluxe");
                Console.WriteLine("3. Suite");
                Console.WriteLine("4. Exit program");
                int input = Int32.Parse(Console.ReadLine());              
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("You have chosen the Regular room. ");
                            Console.WriteLine("Please choose your services:");
                            Console.WriteLine("1. Service A");
                            Console.WriteLine("2. Service B");
                            Console.WriteLine("3. Service C");
                            int selectService = Int32.Parse(Console.ReadLine());
                            if (selectService == 1)
                            {
                                services.serviceAdded += Services_serviceAddedRegular1;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            else if (selectService == 2)
                            {
                                services.serviceAdded += Services_serviceAddedRegular2;
                                services.GetServiceInput(selectService, selectService, selectService);//subscribe
                            }
                            else if (selectService == 3)
                            {
                                services.serviceAdded += Services_serviceAddedRegular3;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("You have chosen the Deluxe room. ");
                            Console.WriteLine("Please choose your services:");
                            Console.WriteLine("1. Service A");
                            Console.WriteLine("2. Service B");
                            Console.WriteLine("3. Service C");
                            int selectService = Int32.Parse(Console.ReadLine());
                            if (selectService == 1)
                            {
                                services.serviceAdded += Services_serviceAddedDeluxe1;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            else if (selectService == 2)
                            {
                                services.serviceAdded += Services_serviceAddedDeluxe2;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            else if (selectService == 3)
                            {
                                services.serviceAdded += Services_serviceAddedDeluxe3;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("You have chosen the Suite room. ");
                            Console.WriteLine("Please choose your services:");
                            Console.WriteLine("1. Service A");
                            Console.WriteLine("2. Service B");
                            Console.WriteLine("3. Service C");
                            int selectService = Int32.Parse(Console.ReadLine());
                            if (selectService == 1)
                            {
                                services.serviceAdded += Services_serviceAddedSuite1;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            else if (selectService == 2)
                            {
                                services.serviceAdded += Services_serviceAddedSuite2;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            else if (selectService == 3)
                            {
                                services.serviceAdded += Services_serviceAddedSuite3;
                                services.GetServiceInput(selectService, selectService, selectService);
                            }
                            break;
                        }
                        case 4:
                        {
                            loop = false;
                            break;
                        }
                }
            }
        }
        private static void Services_serviceAddedRegular1(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (a + 500) + "\n");
        }
        private static void Services_serviceAddedRegular2(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (b + 500) + "\n");
        }
        private static void Services_serviceAddedRegular3(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (c + 500) + "\n");
        }
        private static void Services_serviceAddedDeluxe1(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (a + 1000) + "\n");
        }
        private static void Services_serviceAddedDeluxe2(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (b + 1000) + "\n");
        }
        private static void Services_serviceAddedDeluxe3(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (c + 1000) + "\n");
        }
        private static void Services_serviceAddedSuite1(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (a + 1500) + "\n");
        }
        private static void Services_serviceAddedSuite2(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (b + 1500) + "\n");
        }
        private static void Services_serviceAddedSuite3(int a, int b, int c)
        {
            Console.WriteLine("Your total bill is: " + (c + 1500) + "\n");
        }
    }
}

