using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;

namespace WinRT.VariableGrid.Model
{
    public class Item : INotifyPropertyChanged, IVariableGridViewItem
    {
#if WINDOWS_PHONE_APP
        public static readonly double BaseWidth = (CoreApplication.MainView.CoreWindow.Bounds.Width / 4);
        public static readonly double BaseHeight = BaseWidth;
#else
        public static readonly double BaseHeight = (CoreApplication.MainView.CoreWindow.Bounds.Height / 10);
        public static readonly double BaseWidth = BaseHeight;
#endif

        public static readonly Size SmallSize = new Size(1, 1);
        public static readonly Size MediumSize = new Size(2, 2);
        public static readonly Size LargeSize = new Size(4, 2);
        public static readonly Size ExtraLargeSize = new Size(4, 4);

        private string _name;
        private string _color;
        private Size _displaySize;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        public int ActualWidth
        {
            get { return (int)(SpanSize.Width * BaseWidth); }
        }

        public int ActualHeight
        {
            get { return (int)(SpanSize.Height * BaseHeight); }
        }

        public Size SpanSize
        {
            get { return _displaySize; }
            set { SetProperty(ref _displaySize, value); }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
