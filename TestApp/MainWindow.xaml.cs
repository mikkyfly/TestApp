using System;
using System.ComponentModel;
using System.Windows;
using TestApp.Models;
using TestApp.Services;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\dataList.json";
        private BindingList<Model> _dataList;
        private FileIOService _fileIOService;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);
                        
            try
            {
                _dataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            _dataList = new BindingList<Model>()
            {
                new Model {Provider="CocaCola",IsDone=true,Product="botl",Type="sweet water",Price=145, Comment="Goood", Date=DateTime.Now  },
                new Model {Provider="Pepsi",IsDone=true,Product="botl",Type="sweet water",Price=111, Comment="Baaaaad",Date=DateTime.UtcNow }
            };

            dgOrders.ItemsSource = _dataList;
            _dataList.ListChanged += dataList_ListChanged;
        }

        private void dataList_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType==ListChangedType.ItemAdded || e.ListChangedType ==ListChangedType.ItemDeleted || e.ListChangedType ==ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
    }
}
