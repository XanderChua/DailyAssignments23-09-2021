using System;
using System.Collections.Generic;

namespace DelegateHospitalMgmtSystem
{
    class Patient
    {
        public string Name { get; private set; }
        public List<string> Services { get; private set; }

        public Patient(string name)
        {
            Name = name;
            Services = new List<string>();
        }
    }
    class PatientPublish //publisher
    {
        private List<Patient> patientList = new List<Patient>();
        public delegate void PatientCollectionUpdated(string patientName);
        public event PatientCollectionUpdated patientAdded;

        //public Patient this[int i]
        //{
        //    get
        //    {
        //        return patientList[i];
        //    }
        //}

        //public List<Patient> PATIENTLIST
        //{
            //get
            //{
                //return patientList;
            //}
            //set
            //{
                //this.patientList = new List<Patient>();
            //}
        //}
        public List<Patient> GetPatients()
        {
            return patientList;
        }

        public void AddPatient(string name)
        {
            Patient p = new Patient(name);
            patientList.Add(p);
            patientAdded?.Invoke(name);
        }
        
    }
    class PatientSubscribe //subscriber
    {
        public void SubscribeToEvent(PatientPublish p)
        {
            p.patientAdded += P_patientAdded; 
        }
        private void P_patientAdded(string name)
        {
            Console.WriteLine("Patient " + name + " is registered.\n");           
        }
    }
    class HospitalServices 
    {
        private const int emergencyServicePrice = 80;
        private const int therapyServicePrice = 100;
        private const int consultationServicePrice = 40;
        public int getEmergencyPrice
        {
            get
            {
                return emergencyServicePrice;
            }
        }
        public int getTherapyPrice
        {
            get
            {
                return therapyServicePrice;
            }
        }
        public int getConsultationPrice
        {
            get
            {
                return consultationServicePrice;
            }
        }
    }
    class DelegateHospitalMgmtSystem
    {
        static void Main(string[] args)
        {
           
            HospitalServices hospitalService = new HospitalServices();

            PatientPublish patientP = new PatientPublish();
            PatientSubscribe patientS = new PatientSubscribe();
            patientS.SubscribeToEvent(patientP);

            Console.WriteLine("--Delegate Hospital Management--");       
            Console.WriteLine("Enter patient name:");
            string patientName = Console.ReadLine();
            patientP.AddPatient(patientName);

            bool loop = true;
            while (loop)
            {           
                Console.WriteLine("1. Select a service");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Enter a new patient name:");
                Console.WriteLine("4. Exit");
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
                                Console.WriteLine("The total bill for " + patientName + " is " + hospitalService.getEmergencyPrice);
                            }
                            else if (selectService == 2)
                            {
                                Console.WriteLine("The total bill for " + patientName + " is " + hospitalService.getTherapyPrice);
                            }
                            else if (selectService == 3)
                            {
                                Console.WriteLine("The total bill for " + patientName + " is " + hospitalService.getConsultationPrice);
                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (var patients in patientP.GetPatients())
                            {
                                Console.WriteLine(patients.Name);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter patient name:");
                            string patientName1 = Console.ReadLine();
                            patientP.AddPatient(patientName1);
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
    }
}
