using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Interactive_Event_Maps.ViewModels.Base
{
	public class BaseViewModel : INotifyPropertyChanged, INotifyCollectionChanged
	{
		protected IServiceProvider serviceProvider;
		/// <inheritdoc />
		public event PropertyChangedEventHandler? PropertyChanged;
		public event NotifyCollectionChangedEventHandler? CollectionChanged;

		private bool _isBusy;

		private string _title;

		protected bool initialized;

		/// <summary>
		/// Gets or Sets IsBusy property
		/// </summary>
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		/// <summary>
		/// Gets or Sets the Title
		/// </summary>
		public string Title
		{
			get => _title ?? "No title available";
			set => SetProperty(ref _title, value);
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			MainThread.InvokeOnMainThreadAsync(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
		}

		protected virtual void OnCollectionChanged()
		{
			MainThread.InvokeOnMainThreadAsync(() => CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace)));
		}

		protected void RefreshCollection()
		{
			OnCollectionChanged();
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
