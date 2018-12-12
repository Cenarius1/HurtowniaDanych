using DWH.Domain;
using DWH.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DWH.GUI
{
    public partial class MainWindow : Window
    {
        private ETLProcessManager _ETLProcessManagers { get; set; }
        private CarDetailsRepository _carDetailsRepository { get; set; }
        private List<LoadCarDetail> _loadCarDetailsList { get; set; }
        private List<GridViewModel> _listGridViewModel { get; set; }
        private const int columnNumber = 6;
        private Dictionary<string, string> brandDictionary;
        public MainWindow()
        {
            InitializeComponent();
            _ETLProcessManagers = new ETLProcessManager();
            _loadCarDetailsList = new List<LoadCarDetail>();
            _carDetailsRepository = new CarDetailsRepository(new DataWarehouseContext());
            var columnWidth = (dataGrid.Width - 10) / columnNumber;
            dataGrid.ColumnWidth = columnWidth;
            dataGrid.Items.Refresh();
            SetStartupProcessButtons();
            brandDictionary = GetBrandList();
            cb_brand.ItemsSource = brandDictionary.Keys;
            cb_brand.SelectedIndex = 0;
        }

        private Dictionary<string, string> GetBrandList()
        {
            string templateLink = "https://www.otomoto.pl/osobowe/{0}/?search[filter_float_year%3Ato]=2018";
            return new Dictionary<string, string>()
            {
                {"ALL", String.Format(templateLink,"https://www.otomoto.pl/osobowe/?search[filter_float_year%3Ato]=2018")},
                {"BMW", String.Format(templateLink,"BMW")},
                {"Alfa Romeo",String.Format(templateLink,"alfa-romeo") },
                {"Audi",String.Format(templateLink,"audi") },
                {"Fiat",String.Format(templateLink,"fiat") },
                {"Jaguar",String.Format(templateLink,"Jaguar") },
                {"McLaren",String.Format(templateLink,"McLaren") },
                {"Nissan",String.Format(templateLink,"Nissan") },
                {"Opel",String.Format(templateLink,"Opel") },
                {"Peugeot",String.Format(templateLink,"Peugeot") },
                {"Porsche",String.Format(templateLink,"Porsche") },
                {"Seat",String.Format(templateLink,"Seat") },
                {"Toyota",String.Format(templateLink,"Toyota") },
                {"Volvo",String.Format(templateLink,"Volvo") },
            };
        }

        private void SetStartupProcessButtons()
        {
            btn_Transform.IsEnabled = false;
            btn_Load.IsEnabled = false;
            btn_Extract.IsEnabled = true;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            var paramLink = brandDictionary
                .FirstOrDefault(x => x.Key == cb_brand.SelectedValue.ToString()).Value;

            _ETLProcessManagers.LaunchAll(paramLink);
            SetStartupProcessButtons();

            _loadCarDetailsList = _carDetailsRepository.SelectAll();

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
                || x.Model.Contains(searchText)).ToList();
                //|| x.Price.Contains(searchText)
                this.dataGrid.ItemsSource = result;
            }

            dataGrid.Items.Refresh();
        }

        private void btn_Extract_Click(object sender, RoutedEventArgs e)
        {
            var paramLink = brandDictionary
                .FirstOrDefault(x => x.Key == cb_brand.SelectedValue.ToString()).Value;

            _ETLProcessManagers.LaunchAll(paramLink);
            btn_Extract.IsEnabled = false;
            btn_Transform.IsEnabled = true;
        }

        private void btn_Transform_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.LaunchTransform();
            btn_Transform.IsEnabled = false;
            btn_Load.IsEnabled = true;
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            _ETLProcessManagers.LaunchLoad();
            btn_Load.IsEnabled = false;
            btn_Extract.IsEnabled = true;

            _loadCarDetailsList = _carDetailsRepository.SelectAll();

            if (_loadCarDetailsList != null) {
                _listGridViewModel = GetMappedModelToVM();
                this.dataGrid.ItemsSource = _listGridViewModel;
            }
            dataGrid.Items.Refresh();
        }
    }
}
