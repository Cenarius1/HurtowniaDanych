using DWH.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DWH.GUI
{
    public partial class MainWindow : Window
    {
        private ETLProcessManager _ETLProcessManagers { get; set; }
        private List<LoadCarDetail> _loadCarDetailsList { get; set; }
        private List<GridViewModel> _listGridViewModel { get; set; }
        private const int columnNumber = 6;
        public MainWindow()
        {
            InitializeComponent();
            _ETLProcessManagers = new ETLProcessManager();
            _loadCarDetailsList = new List<LoadCarDetail>();
            var columnWidth = (dataGrid.Width - 10) / columnNumber;
            dataGrid.ColumnWidth = columnWidth;
            dataGrid.Items.Refresh();
            SetStartupProcessButtons();
        }

        private void SetStartupProcessButtons()
        {
            btn_Transform.IsEnabled = false;
            btn_Load.IsEnabled = false;
            btn_Extract.IsEnabled = true;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.Launch();
            SetStartupProcessButtons();

            _loadCarDetailsList = _ETLProcessManagers.GetLoadedCarDetail();
            if (_loadCarDetailsList != null)
            {
                _listGridViewModel = GetMappedModelToVM();
                this.dataGrid.ItemsSource = _listGridViewModel;
            }
        }

        private List<GridViewModel> GetMappedModelToVM()
        {
            List<GridViewModel> listGridViewModel = new List<GridViewModel>();
            foreach (var item in _loadCarDetailsList)
            {
                listGridViewModel.Add(new GridViewModel()
                {
                    Id = item.Id.ToString(),
                    Model = item.Model,
                    Title = item.Title,
                    Price = item.Price,
                    City = item.City,
                    Year = item.Year,
                });
            }
            return listGridViewModel;
        }

        private void btn_serach_Click(object sender, RoutedEventArgs e)
        {
            var searchText = tbx_seatch.Text;
            if (searchText == string.Empty)
            {
                this.dataGrid.ItemsSource = _listGridViewModel;
            }
            else
            {
                var result = _listGridViewModel.Where(x => x.Title.Contains(searchText)
                || x.City.Contains(searchText)
                || x.Year.Contains(searchText)
                || x.Model.Contains(searchText)
                || x.Price.Contains(searchText)).ToList();
                this.dataGrid.ItemsSource = result;
            }

            dataGrid.Items.Refresh();
        }

        private void btn_Extract_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.Extract();
            btn_Extract.IsEnabled = false;
            btn_Transform.IsEnabled = true;
        }

        private void btn_Transform_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.Extract();
            btn_Transform.IsEnabled = false;
            btn_Load.IsEnabled = true;
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.Load();
            btn_Load.IsEnabled = false;
            btn_Extract.IsEnabled = true;   
            _loadCarDetailsList = _ETLProcessManagers.GetLoadedCarDetail();
            if (_loadCarDetailsList != null)
            {
                _listGridViewModel = GetMappedModelToVM();
                this.dataGrid.ItemsSource = _listGridViewModel;
            }
            dataGrid.Items.Refresh();
        }
    }
}
