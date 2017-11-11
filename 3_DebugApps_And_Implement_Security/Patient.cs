using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DebugApps_And_Implement_Security
{
    class Patient : IPatient
    {
        public long NHSNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Patient(long NHSNumber, string name, int age)
        {
            this.NHSNumber = NHSNumber;
            this.Name = name;
            this.Age = age;
        }

        Task<Guid> IPatient.DoBulkLoad(string callbackURL)
        {
            throw new NotImplementedException();
        }
    }

    class PatientLoad : IPatient
    {
        // Since these methods are explicity implemented they are private by default and not visible in PatientLoad.
        long IPatient.NHSNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IPatient.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IPatient.Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        event EventHandler OnBulkLoadCompletedEvent = delegate { };

        public async Task<Guid> DoBulkLoad(string callbackURL)
        {
            // Schedule a mass resync process of patient data.
            // Do a callback to the specified URL when done.
            MyEventArgs args = new MyEventArgs(callbackURL);
            this.OnBulkLoadCompletedEvent += (sender, e) => PatientLoad_OnBulkLoadCompletedEvent(this, args);
            var result = await TriggerBulkLoad();
            return Guid.NewGuid();
        }

        private void PatientLoad_OnBulkLoadCompletedEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine("On bulk load completed event has fired - do a callback to URL {0}", e.arg);
        }

        private async Task<string> TriggerBulkLoad()
        {
            Task.Delay(10000);
            NewMethod();
            return "Done";
        }

        private void NewMethod()
        {
            Raise();
        }

        private void Raise()
        {
            OnBulkLoadCompletedEvent(this, MyEventArgs.Empty);
        }
    }

    class MyEventArgs : EventArgs
    {
        public string arg { get; set; }
        public MyEventArgs(string arg)
        {
            this.arg = arg;
        }
    }
}
