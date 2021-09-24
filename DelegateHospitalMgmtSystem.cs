using System;
using System.Collections.Generic;

namespace DelegateHospitalMgmtSystem
{
    class PatientPublish //publisher
    {
        List<string> list = new List<string>();
        public event EventHandler patientAdded;

        public string this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list.Add(value);
                if (patientAdded != null)
                {
                    patientAdded(this, null);
                }
            }
        }
        public void showListOfPatients()
        {
            foreach (var patient in list)
            {
                Console.WriteLine("Patient name: " + patient);
            }
        }
    }
    class PatientSubscribe //subscriber
    {
        public delegate void EventHandlerPatient(string name);
        public event EventHandlerPatient send;
        private PatientPublish p;
        public string name;
        public void GetInputPatient(string name)
        {
            this.name = name;
            Notify();
        }
        public void SubscribeToEvent(PatientPublish patient)
        {
            p = patient;
            p.patientAdded += P_patientAdded; 
        }
        private void P_patientAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Patient " + sender + " is registered.");
        }
        public void Notify()
        {
            if(send != null)
            {
                send(name);
            }
        }
    }
    class PatientServices //subscriber
    {
        public delegate void EventHandlerServices(int emergency, int therapy, int consultation);
        public event EventHandlerServices serviceAdded;
        int emergency;
        int therapy;
        int consultation;
        public void GetInputServices(int emergency, int therapy, int consultation)
        {
            this.emergency = emergency;
            this.therapy = therapy;
            this.consultation = consultation;
            serviceEmergency();
            serviceTherapy();
            serviceConsultation();
            sendBack();
        }
        public void serviceEmergency()
        {
            emergency = 50;
        }
        public void serviceTherapy()
        {
            emergency = 80;
        }
        public void serviceConsultation()
        {
            emergency = 10;
        }
        public void sendBack()
        {
            if (serviceAdded != null)
            {
                serviceAdded(emergency, therapy, consultation);
            }
        }
    }
    class DelegateHospitalMgmtSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Delegate Hospital Management--");       
            Console.WriteLine("Enter patient name:");
            string patientName = Console.ReadLine();

            PatientPublish patientP = new PatientPublish();
            PatientSubscribe patientS = new PatientSubscribe();
            PatientServices patientSvc = new PatientServices();

            patientS.GetInputPatient(patientName);

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Select a service");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Exit");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Please choose your services:");
                            Console.WriteLine("1. Emergency");
                            Console.WriteLine("2. Therapy");
                            Console.WriteLine("3. Consultation");
                            int selectService = Int32.Parse(Console.ReadLine());
                            if (selectService == 1)
                            {
                                patientS.send += PatientS_sendEmergency;
                                patientSvc.GetInputServices(selectService, selectService, selectService);
                            }
                            else if (selectService == 2)
                            {
                                patientS.send += PatientS_sendTherapy;
                                patientSvc.GetInputServices(selectService, selectService, selectService);
                            }
                            else if (selectService == 3)
                            {
                                patientS.send += PatientS_sendConsultation;
                                patientSvc.GetInputServices(selectService, selectService, selectService);
                            }
                            break;
                        }
                    case 2:
                        {
                            patientP.showListOfPatients();
                            break;
                        }
                    case 3:
                        {
                            loop = false;
                            break;
                        }
                }
            }

        }
        private static void PatientS_sendEmergency(string name)
        {
            Console.WriteLine("The bill for " + name + "is I WAN THE PRICE HERE!!!!!!");
        }
        private static void PatientS_sendTherapy(string name)
        {
            throw new NotImplementedException();
        }
        private static void PatientS_sendConsultation(string name)
        {
            throw new NotImplementedException();
        }//TMR ASK!
    }
}
