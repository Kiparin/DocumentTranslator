using System.ComponentModel;

namespace DocumentTranslator.Helpers
{
    public class NotifyProperty<T> : INotifyPropertyChanged
    {
        private T _value;

        public NotifyProperty(T value)
        {
            _value = value;
        }

        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}