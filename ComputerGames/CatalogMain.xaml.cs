using Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace ComputerGames
{
    /// <summary>
    /// Interaction logic for CatalogMain.xaml
    /// </summary>
    public partial class CatalogMain : Window
    {

        private GameCatalog _catalog = new GameCatalog();
        private GameCatalog ListGame = new GameCatalog();
        private string FolderPath = MainWindow.selectFolderPath;
        private string _typefile = "";
        private Game _selectedGame;

        public CatalogMain()
        {
            InitializeComponent();

            //FolderPath = MainWindow.selectFolderPath;
            _typefile = MainWindow.selectFileFormat;

            // Инициализируем каталог с загрузкой существующих данных, если файл есть
            string catalogFile = System.IO.Path.Combine(FolderPath, $"catalog.{_typefile}");
            _catalog.InitializeCatalogPath(FolderPath, _typefile);

            PlatformCombox.ItemsSource = _catalog.SortGames(_catalog.GetAllGames());
            MaxBlock.Text = _catalog.MaxRating(_catalog.GetAllGames()).ToString("F2");
            MinBlock.Text = _catalog.MinRating(_catalog.GetAllGames()).ToString("F2");
            SrBlock.Text = _catalog.AverageRating(_catalog.GetAllGames()).ToString("F2");
            MidBlock.Text = _catalog.MedianRating(_catalog.GetAllGames()).ToString("F2");
        }

        private void ChoiseGame(object sender, SelectionChangedEventArgs e)
        {
            _selectedGame = PlatformCombox.SelectedItem as Game;
        }
        private void InformationButton(object sender, RoutedEventArgs e)
        {
            if (_selectedGame == null)
            {
                System.Windows.MessageBox.Show("Выберите игру");
                return;
            }

            GameInfoWindow window = new GameInfoWindow(_selectedGame);
            window.Show();
        }

        private void FilterGames(object sender, SelectionChangedEventArgs e)
        {
            if (PlatformCombox == null || _catalog.GetAllGames() == null) return;


            List<Game> Games = _catalog.SortGames(_catalog.GetAllGames());

            // Получаем выбранные значения в виде строк
            // PlatformSort.SelectedItem  - элемент который на данный момент выбран Content? - то что хранит платформа
            string Platform = (PlatformSort.SelectedItem as ComboBoxItem)?.Content?.ToString();  
            string Mode = (RejimSort.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (!string.IsNullOrEmpty(Platform) && Platform != "Выберите вариант..." && Platform != "Все")
            {
                Games = _catalog.SortPlatform(Games, Platform);
                MaxBlock.Text = _catalog.MaxRating(Games).ToString("F2");
                MinBlock.Text = _catalog.MinRating(Games).ToString("F2");
                SrBlock.Text = _catalog.AverageRating(Games).ToString("F2");
                MidBlock.Text = _catalog.MedianRating(Games).ToString("F2");
            }

            if (Mode != "Выберите вариант...")
            {
                Games = _catalog.SortMode(Games, Mode);
                MaxBlock.Text = _catalog.MaxRating(Games).ToString("F2");
                MinBlock.Text = _catalog.MinRating(Games).ToString("F2");
                SrBlock.Text = _catalog.AverageRating(Games).ToString("F2");
                MidBlock.Text = _catalog.MedianRating(Games).ToString("F2");
            }

            PlatformCombox.ItemsSource = Games;
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void ButtonGeneration(object sender, RoutedEventArgs e)
        {
            CatalogManagement managementWindow = new CatalogManagement(_catalog);

            managementWindow.ShowDialog();

            if (!string.IsNullOrEmpty(FolderPath))
            {
                string format = MainWindow.selectFileFormat ?? "json";

                string currentSavePath = System.IO.Path.Combine(FolderPath, $"catalog.{format}");
                _catalog.SaveToFile(currentSavePath, format);
            }

            List<Game> updatedGames = _catalog.SortGames(_catalog.GetAllGames());

            if (updatedGames == null) updatedGames = new List<Game>();

            PlatformCombox.ItemsSource = updatedGames;

            MaxBlock.Text = ListGame.MaxRating(updatedGames).ToString("F2");
            MinBlock.Text = ListGame.MinRating(updatedGames).ToString("F2");
            SrBlock.Text = ListGame.AverageRating(updatedGames).ToString("F2");
            MidBlock.Text = ListGame.MedianRating(updatedGames).ToString("F2");
        }
    }
}







