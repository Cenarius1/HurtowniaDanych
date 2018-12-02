using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DWH.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ogolna lista i tu wladowac wszystkie wyniki, po ktorych bedziemy filtrowac
        public List<Worker> WorkerList = new List<Worker>();
        public MainWindow()
        {
            InitializeComponent();

            //haki zeby w miare rowno wyswietlalo kolumny
            int columnNumber = 3;
            var columnWidth = (dataGrid.Width - 10) / columnNumber;
            dataGrid.ColumnWidth = columnWidth;

            var w1 = new Worker
            {
                FirstName = "john",
                LastName = "smart",
                Age = "111"
            };

            var w2 = new Worker
            {
                FirstName = "john2",
                LastName = "smart",
                Age = "222"
            };

            var w3 = new Worker
            {
                FirstName = "john3",
                LastName = "smart",
                Age = "333"
            };

            var w4 = new Worker
            {
                FirstName = "john3",
                LastName = "smart",
                Age = "444"
            };

            var w5 = new Worker
            {
                FirstName = "john4",
                LastName = "smart",
                Age = "555"
            };

            //dodajemy do listy workerow - z bazy to tam trzeba czy ten parser?
            WorkerList.Add(w1);
            WorkerList.Add(w2);
            WorkerList.Add(w3);
            WorkerList.Add(w4);
            WorkerList.Add(w5);

            //po dolaczeniu danych trzeba odswiezyc
            this.dataGrid.ItemsSource = WorkerList;
            dataGrid.Items.Refresh();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            //wszystko z konsoli do odpalenia
        }

        private void btn_serach_Click(object sender, RoutedEventArgs e)
        {
            var searchText = tbx_seatch.Text;
            //jak sie nic nie wpisze to pokazujemy wszystko
            if (searchText == string.Empty)
            {
                this.dataGrid.ItemsSource = WorkerList;
                dataGrid.Items.Refresh();
            }

            //szukamy w wszystkich prop czy zawiera text
                var result = WorkerList.Where(x => x.FirstName.Contains(searchText)
            || x.LastName.Contains(searchText)
            || x.Age.Contains(searchText)).ToList();


            this.dataGrid.ItemsSource = result;
            dataGrid.Items.Refresh();
        }
    }

    //do podmianki to co ma być
    public class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
    }
}
