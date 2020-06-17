using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System_MVVM.Model.Common
{
    public class Skills
    {
        public int Development { get; set; }
        public int TeamWork { get; set; }
        public int PercentageSuccessfullyCompletedProjects { get; set; }
        public int ManagerialEffectiveness { get; set; }
        public int Productivity { get; set; }
        public Skills() { }
        public int[] AllSkills()
        {
           return new int[5] { Development, TeamWork, 
                PercentageSuccessfullyCompletedProjects, ManagerialEffectiveness, Productivity };
        }
    }
}
