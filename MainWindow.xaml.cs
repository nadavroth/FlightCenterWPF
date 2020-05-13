using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightCenterWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Flight> flights = new ObservableCollection<Flight>();
        public MainWindow()
        {

            flights.Add(new Flight() { Id = 1, Name = "EL AL", Vacancy = 1 });
            flights.Add(new Flight() { Id = 2, Name = "ARKIYA", Vacancy = 0 });
            flights.Add(new Flight() { Id = 3, Name = "American airlines", Vacancy = 23 });
            flights.Add(new Flight() { Id = 4, Name = "Turkish", Vacancy = 0 });

            this.DataContext = flights;
            InitializeComponent();



        }





        private void CheckForFlights(object sender, RoutedEventArgs e)
        {
            int selectedIndex = AirlineCompanyListBox.SelectedIndex;

            if (flights[selectedIndex].Vacancy < 30 && flights[selectedIndex].Vacancy >= 0)
            {
                AvailbleText.Foreground = Brushes.Green;
                AvailbleText.Text = "Flight is available";
                AvailbleText.Visibility = Visibility.Visible;
            }
            else
            {
                AvailbleText.Foreground = Brushes.Red;
                AvailbleText.Text = "Flight is not available";
                AvailbleText.Visibility = Visibility.Visible;
            }

        }

        private void AirlineCompanyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AvailbleText.Visibility = Visibility.Hidden;
        }

        private void BookForFlight(object sender, RoutedEventArgs e)
        {
            int selectedIndex = AirlineCompanyListBox.SelectedIndex;
            if (flights[selectedIndex].Costumer != "Unkown")
            {
                if (flights[selectedIndex].Vacancy < 30 && flights[selectedIndex].Vacancy >= 0)
                {
                    AvailbleText.Text = "Flight has been book";
                    AvailbleText.Foreground = Brushes.Indigo;
                    AvailbleText.Visibility = Visibility.Visible;
                    flights[selectedIndex].Vacancy++;
                    //Binding.AddSourceUpdatedHandler(AirlineCompanyListBox, EventHandler<DataTransferEventArgs> handler = new EventHandler<DataTransferEventArgs>);



                }
                else
                {
                    AvailbleText.Text = "Flight is not available";
                    AvailbleText.Foreground = Brushes.Red;
                    AvailbleText.Visibility = Visibility.Visible;
                }
            }
        }
    }


    public class Flight : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private int _vacancy;
        private string _costumer;
        public string Costumer
        {
            get
            {
                if (string.IsNullOrEmpty(_costumer))
                    return "Unknown";
                return _costumer;
            }
            set
            {
                value = _costumer;
                OnPropertyChanged("Costumer");
            }

        }

        public int Vacancy
        {
            get { return _vacancy; }
            set
            {
                _vacancy = value;

                OnPropertyChanged("Vacancy");
            }
        }





    }
}
