using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWorkSample.Models
{
    public class Car: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
