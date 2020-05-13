using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightCenterWPF
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string vacancy)
        {

            if (!String.IsNullOrEmpty(vacancy))
            {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(vacancy));

            }
        }
    }
}
