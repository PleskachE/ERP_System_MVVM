using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System_MVVM.Model.Repositoryes
{
    public static class ProjectRepository 
    {
        private static ObservableCollection<Project> _projects;
        public static ObservableCollection<Project> AllProjects 
        {
            get
            {
                if (_projects == null)
                    _projects = GenerateProjectRepository();
                return _projects;
            }
        }
        private static ObservableCollection<Project> GenerateProjectRepository()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>
            {
                new Project(){ Id = 1, Name="Solution1", Client="EPAM", PercentageCompletion=100, StartDate=new DateTime(2019, 4, 17), EndDate=new DateTime(2020, 4, 27), WorkersId=new List<int>(){1,3,4,5,6,8,9,11 } },
                new Project(){Id = 2, Name="Solution2", Client="Viber", PercentageCompletion=100, StartDate=new DateTime(2019, 5, 7), EndDate=new DateTime(2020, 5, 7),WorkersId=new List<int>(){1,2,4,3,6,7,9,11 }},
                new Project(){Id = 3 ,Name="Solution3", Client="Wargaming", PercentageCompletion=100, StartDate=new DateTime(2019, 6, 27), EndDate=new DateTime(2020, 3, 1),WorkersId=new List<int>(){3,2,5,8,6,7,10,11 }},
                new Project(){Id = 4 ,Name="Solution4", Client="CD PROJEKT RED", PercentageCompletion=100, StartDate=new DateTime(2019, 7, 1), EndDate=new DateTime(2020, 2, 17),WorkersId=new List<int>(){1,3,5,7,8,10,11 }}
            };
            return projects;
        }
    }
}
