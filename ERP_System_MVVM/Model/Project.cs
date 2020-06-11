using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ERP_System_MVVM.Model
{
    public class Project 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public double PercentageCompletion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> WorkersId { get; set; }
        public Project() { WorkersId = new List<int>(); }
        public Project(string name, string client)
        {
            this.Name = name;
            this.Client = client;
        }
    }
}
