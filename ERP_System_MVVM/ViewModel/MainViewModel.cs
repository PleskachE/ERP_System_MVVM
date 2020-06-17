using ERP_System_MVVM.Infrastructure;
using ERP_System_MVVM.Model;
using ERP_System_MVVM.Model.Common;
using ERP_System_MVVM.Model.Repositoryes;
using ERP_System_MVVM.Services.WindowFactory;
using ERP_System_MVVM.View;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace ERP_System_MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public IWindowFactory WindowFactory = new WindowFactory();
        public MainViewModel()
        {
            RemoveWorkerCommand = new RelayCommand(ExecuteRemoveWorkerCommand, CanExecuteRemoveWorkerCommand);
            ChangeWorkerCommand = new RelayCommand(ExecuteChangeWorkerCommand, CanExecuteChangeWorkerCommand);
            _cvsWorkers = new CollectionViewSource
            {
                Source = this.AllWorkers
            };
            _cvsWorkers.Filter += ApplyFilter;
            Formatter = value => value + " %";
        }

        #region command
        public RelayCommand RemoveWorkerCommand { get; }
        private void ExecuteRemoveWorkerCommand(object parameter)
        {
            if (MessageBox.Show("Delete the selected worker?", "Remov", MessageBoxButton.YesNo,
                        MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                AllWorkers.Remove(CurrentWorker);
                CurrentWorker = null;
            }
        }
        public bool CanExecuteRemoveWorkerCommand(object parameter)
        {
            return CurrentWorker != null;
        }
        public RelayCommand ChangeWorkerCommand { get; }
        private void ExecuteChangeWorkerCommand(object parameter)
        {
            var window = WindowFactory.CreateWindow(new WindowCreationOptions()
            {
                WindowSize = new WindowSize(new Size(350, 170)),
                Title = "Change Worker",
            });
            window.SizeToContent = SizeToContent.Height;
            var WorkerWindow = new WorkerWindow
            {
                DataContext = CurrentWorker,
                DialogCommand = new RelayCommand(r => window.DialogResult = (bool)r)
            };
            window.Content = WorkerWindow;
            var result = window.ShowDialog();
            if (!result != true)
                return;
        }
        public bool CanExecuteChangeWorkerCommand(object parameter)
        {
            return CurrentWorker != null;
        }
        #endregion

        #region workers
        private Worker _currentWorker;
        private ObservableCollection<Worker> _workers;
        public ObservableCollection<Worker> AllWorkers => _workers ?? (_workers = WorkerRepository.AllWorkers);
        private CollectionViewSource _cvsWorkers { get; set; }
        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
                OnFilterChanged();
            }
        }
        private void OnFilterChanged()
        {
            _cvsWorkers.View.Refresh();
        }
        public ICollectionView AllCVSWorkers
        {
            get { return _cvsWorkers.View; }
        }
        void ApplyFilter(object sender, FilterEventArgs e)
        {
            Worker _tempWorker = (Worker)e.Item;
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
                e.Accepted = true;
            else
                e.Accepted = _tempWorker.Surname.Contains(Filter);
        }
        public Worker CurrentWorker
        {
            get
            { if (_currentWorker == null)
                    return new Worker();
                return _currentWorker;
            }
            set
            {
                _currentWorker = value;
                if (_currentWorker != null)
                    CurrentProjects = GetCurrentProjects(_currentWorker.Id);
                Builds();
                OnPropertyChanged();
            }
        }
        #endregion

        #region projects
        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects => _projects ?? (_projects = ProjectRepository.AllProjects);
        private ObservableCollection<Project> _currentProjects;
        public ObservableCollection<Project> CurrentProjects
        {
            get
            {
                if (_currentProjects == null)
                    return _currentProjects = new ObservableCollection<Project>();
                return _currentProjects;
            }
            set
            {
                _currentProjects = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Project> GetCurrentProjects(int _id)
        {
            ObservableCollection<Project> _tempProjects = new ObservableCollection<Project>();
            foreach (Project item in Projects)
                if (item.WorkersId.FindAll(x => x == _id).Count != 0)
                    _tempProjects.Add(item);
            return _tempProjects;
        }
        #endregion

        #region charts
        public string[] Labels => new[] { "Development", "Productivity", "TeamWork",
            "%CompletedProjects", "ManagerialEffectiveness" };

        public Func<double, string> Formatter { get; set; }
        private ChartValues<ObservableValue> _skillsValues { get; set; }
        public SeriesCollection Skills { get; set; }
        private void Builds()
        {
            if (_skillsValues == null)
                _skillsValues = new ChartValues<ObservableValue>();
            _skillsValues.Clear();
            foreach (int item in CurrentWorker.GetSkills.AllSkills())
                _skillsValues.Add(new ObservableValue(item));
            Skills = new SeriesCollection()
                {
                    new StackedColumnSeries()
                    {
                        Values = _skillsValues,
                        StackMode = StackMode.Values,
                        DataLabels = true,
                    }
                };
        }
        #endregion
    }
}
