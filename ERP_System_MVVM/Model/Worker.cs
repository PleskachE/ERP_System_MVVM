using ERP_System_MVVM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ERP_System_MVVM.Model
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Image Photo { get; set; }
        public decimal Salary { get; set; }
        public int Rating { get; set; }
        public PositionEnum Position { get; set; }
        public Skills GetSkills { get; set; }
        public Worker()
        {
            GetSkills = new Skills();
        }
        public Worker(string _name, string _surname)
        {
            this.Name = _name;
            this.Surname = _surname;
        }
        public void CalculationRating()
        {
            if (GetSkills == null)
                Rating = 0;
            else
            {
                Rating = (GetSkills.Development + GetSkills.ManagerialEffectiveness + 
                    GetSkills.PercentageSuccessfullyCompletedProjects + GetSkills.Productivity + GetSkills.TeamWork) / 5;
            }
        }
    }
}
