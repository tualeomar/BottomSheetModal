using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BottomSheet
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _commadOpen;
        private bool _isOpenSheet = false;
        public MainViewModel()
        {

        }

        public bool IsOpenSheet
        {
            get => _isOpenSheet;
            set => SetProperty(ref _isOpenSheet, value);
        }

        public ICommand CommandOpenSheet => _commadOpen ?? (_commadOpen = new Command(async () => { await OpenSheetAsync(); }));

        #region PropertiesChanged
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public async Task OpenSheetAsync()
        {
            try
            {
                IsOpenSheet = true;
                await Task.CompletedTask;
            }
            catch { }
        }
    }
}
