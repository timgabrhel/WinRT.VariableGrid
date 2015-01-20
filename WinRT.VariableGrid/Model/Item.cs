using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinRT.VariableGrid.Model
{
    public class Item : INotifyPropertyChanged, IVariableGridViewItem
    {
        private string _name;
        private string _color;
        private int _width;
        private int _height;

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
        
        public int Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }

        public int Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
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
