using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System_MVVM.ViewModel
{
	public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
	{

		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void Dispose()
		{
			OnDispose();
		}

		protected virtual void OnDispose()
		{
		}
	}
}
