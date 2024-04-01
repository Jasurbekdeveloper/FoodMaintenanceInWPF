using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodMaintenance.Models
{
    /// <summary>
    /// Base implementation of a model implementing <see cref="INotifyPropertyChanged"/>
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseObservableModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}
