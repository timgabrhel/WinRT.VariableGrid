using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using WinRT.VariableGrid.Model;

namespace WinRT.VariableGrid.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>();

            var random = new Random();
            for (int x = 1; x <= 30; x++)
            {
                Items.Add(new Item()
                {
                    Name = string.Format("Item {0}", x),
                    Color = String.Format("#FF{0:X6}", random.Next(0x1000000))
                });
            }

            RemeasureItems();
        }
        
        /// <summary>
        /// Enumerates over each item, and re-runs the logic to determine the dynamic sizes of the items
        /// </summary>
        public void RemeasureItems()
        {
            for (int i = 1; i <= Items.Count; i++)
            {
                var item = Items[i - 1];
                MeasureItem(item, i);
                Items[i - 1] = item;
            }
        }

        /// <summary>
        /// Given an Item and index, dynamically sets the items width and height
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void MeasureItem(Item item, int i)
        {
            var width = (CoreApplication.MainView.CoreWindow.Bounds.Width / 2);
            var height = width * 0.7941176470588235;

            Size size = new Size(width, height);

            item.Width = (int)size.Width;
            item.Height = (int)size.Height;

            if ((i % 5) == 0)
            {
                item.Width = (int)size.Width * 2;
                //item.Height = (int)size.Height * 2;
            }
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
