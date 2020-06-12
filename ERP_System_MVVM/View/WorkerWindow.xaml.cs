using ERP_System_MVVM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ERP_System_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : ContentControl
	{
		public RelayCommand DialogCommand { get; set; }
		public WorkerWindow()
		{
			InitializeComponent();
		}
		private void Ok_OnClick(object sender, RoutedEventArgs e)
		{
			DialogCommand?.Execute(true);
		}
		private void Cancel_OnClick(object sender, RoutedEventArgs e)
		{
			DialogCommand?.Execute(false);
		}
	}
}
