
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models.Base
{
    public class BindableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// This is to be called at the set block of every proprty
        /// So that the property undergoes the steps commented below
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="val"></param>
        /// <param name="propertyName">The name of teh property called</param>
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This is to set properties and fire the event no matter when
        /// I use this for states (enums...)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <param name="val"></param>
        /// <param name="propertyName"></param>
        protected virtual void SetPropertyState<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// This is used when if one property is changed, it will automatically cause 
        /// One or two properties to change. Such as computed properties.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
