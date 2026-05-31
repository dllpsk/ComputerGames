using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;
using System.Windows.Forms;


namespace ComputerGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public static string selectFolderPath;
        public static string selectFileFormat;
        private Model.Core.GameCatalog _catalog = new Model.Core.GameCatalog();

        public MainWindow()
        {
            InitializeComponent();
            if (selectFolderPath != "не выбрана")
            {
                SavePath.Text = "выбрана";
            }
        }
        static MainWindow()
        {
            selectFolderPath = "не выбрана";
            selectFileFormat = "json";
        }
        private void Goto_Catalog(object sender, RoutedEventArgs e)
        {
            if (selectFolderPath != "не выбрана")
            {
                CatalogMain catalogMain = new CatalogMain();
                catalogMain.Show();
                this.Close();
            }
            else
            {
                // System.Windows.MessageBox.Show - выплывющее окно 
                System.Windows.MessageBox.Show("Вы не выбрали папку для сохранения!", "Ошибка", MessageBoxButton.OK);

                return;
            }
        }
        private void LoadingPathClick(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            // dialog.ShowDialog()  - открываем проводник и далее проверяем нажал ли пользователь ок
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                SavePath.Text = "выбрана";
                selectFolderPath = dialog.SelectedPath;  

                var selectedFormatItem = FileFormatSelect.SelectedItem as ComboBoxItem;
                string format = selectedFormatItem?.Content?.ToString()?.ToLower() ?? "json";
                selectFileFormat = format;

                _catalog.InitializeCatalogPath(selectFolderPath, format);
            }
        }

    }
}