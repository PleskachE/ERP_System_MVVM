using ERP_System_MVVM.Model.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ERP_System_MVVM.Model.Repositoryes
{
    public static class WorkerRepository
    {
        private static ObservableCollection<Worker> _workers;
        public static ObservableCollection<Worker> AllWorkers
        {
            get
            {
                if (_workers == null)
                    _workers = GenerateWorkerRepository();
                CalculationRatingWorkers();
                return _workers;
            }
        }
        private static ObservableCollection<Worker> GenerateWorkerRepository()
        {
            ObservableCollection<Worker> workers = new ObservableCollection<Worker>
            {
                new Worker("Ivan", "Ivanov")
                {
                    Id=1, Photo = null, DateOfBirth =new DateTime(1996,12,12), Position=PositionEnum.Junior, Salary=500,
                     GetSkills = new Skills()
                     {
                         Development=54, ManagerialEffectiveness=20, PercentageSuccessfullyCompletedProjects=70, 
                         Productivity=65, TeamWork=82
                     }
                },
                new Worker("Petr", "Petrov")
                {
                    Id=2, Photo=null, DateOfBirth=new DateTime(1995,1,1), Position=PositionEnum.Junior, Salary=550,
                     GetSkills = new Skills()
                     {
                         Development=60, ManagerialEffectiveness=25, PercentageSuccessfullyCompletedProjects=75,
                         Productivity=75, TeamWork=85
                     }
                },
                new Worker("Nikolay", "Sidorov")
                {
                    Id=3, Photo=null, DateOfBirth=new DateTime(1997,1,1), Position=PositionEnum.Junior, Salary=500,
                     GetSkills = new Skills()
                     {
                         Development=45, ManagerialEffectiveness=15, PercentageSuccessfullyCompletedProjects=60,
                         Productivity=50, TeamWork=60
                     }
                },
                new Worker("Andrey", "Andreev")
                {
                    Id=4, Photo=null, DateOfBirth=new DateTime(1994,10,1), Position=PositionEnum.Middle, Salary=950,
                     GetSkills = new Skills()
                     {
                         Development=72, ManagerialEffectiveness=40, PercentageSuccessfullyCompletedProjects=75,
                         Productivity=75, TeamWork=85
                     }
                },
                new Worker("Alex", "Vinogradov")
                {
                    Id=5, Photo=null, DateOfBirth=new DateTime(1994,2,12), Position=PositionEnum.Middle, Salary=900,
                     GetSkills = new Skills()
                     {
                         Development=70, ManagerialEffectiveness=37, PercentageSuccessfullyCompletedProjects=70,
                         Productivity=60, TeamWork=80
                     }
                },
                new Worker("Bob", "Marley")
                {
                    Id=6, Photo=null, DateOfBirth=new DateTime(1993,3,11), Position=PositionEnum.Middle, Salary=1000,
                     GetSkills = new Skills()
                     {
                         Development=75, ManagerialEffectiveness=45, PercentageSuccessfullyCompletedProjects=80,
                         Productivity=80, TeamWork=90
                     }
                },
                new Worker("Michael", "Scofield")
                {
                    Id=7, Photo=null, DateOfBirth=new DateTime(1992,11,9), Position=PositionEnum.Senior, Salary=1500,
                     GetSkills = new Skills()
                     {
                         Development=85, ManagerialEffectiveness=60, PercentageSuccessfullyCompletedProjects=80,
                         Productivity=62, TeamWork=90
                     }
                },
                new Worker("Walter", "White")
                {
                    Id=8, Photo=null, DateOfBirth=new DateTime(1992,4,12), Position=PositionEnum.Senior, Salary=1600,
                     GetSkills = new Skills()
                     {
                         Development=88, ManagerialEffectiveness=55, PercentageSuccessfullyCompletedProjects=90,
                         Productivity=83, TeamWork=75
                     }
                },
               new Worker("Dima", "Beach")
                {
                    Id=9, Photo=null, DateOfBirth=new DateTime(1991,6,12), Position=PositionEnum.Architect, Salary=2500,
                     GetSkills = new Skills()
                     {
                         Development=95, ManagerialEffectiveness=70, PercentageSuccessfullyCompletedProjects=90,
                         Productivity=85, TeamWork=60
                     }
                },
               new Worker("Tony", "Ferguson")
                {
                    Id=10, Photo=null, DateOfBirth=new DateTime(1990,6,12), Position=PositionEnum.Architect, Salary=2300,
                     GetSkills = new Skills()
                     {
                         Development=97, ManagerialEffectiveness=72, PercentageSuccessfullyCompletedProjects=85,
                         Productivity=70, TeamWork=50
                     }
                },
               new Worker("Inna", "Krot")
                {
                    Id=11, Photo=null, DateOfBirth=new DateTime(1990,2,18), Position=PositionEnum.TeamLead, Salary=2200,
                     GetSkills = new Skills()
                     {
                         Development=70, ManagerialEffectiveness=99, PercentageSuccessfullyCompletedProjects=95,
                         Productivity=80, TeamWork=97
                     }
                },
            };
            return workers;
        }
        private static void CalculationRatingWorkers()
        {
            for (int i = 0; i < _workers.Count; i++)
                _workers[i].CalculationRating();
        }
    }
}
