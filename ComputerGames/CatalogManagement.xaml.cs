 using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Core;

namespace ComputerGames
{
    /// <summary>
    /// Interaction logic for CatalogManagement.xaml
    /// </summary>
    public partial class CatalogManagement : Window
    {
        private GameCatalog _catalog;

        public CatalogManagement(GameCatalog catalog)
        {
            InitializeComponent();
            _catalog = catalog;

            DpRelease.SelectedDate = DateTime.Now;

            RefreshTable();
        }

        private void RefreshTable()
        {
            GamesDataGrid.ItemsSource = null;

            List<Game> sortedList = _catalog.SortGames(_catalog.GetAllGames());

            GamesDataGrid.ItemsSource = sortedList ?? new List<Game>();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text) || string.IsNullOrWhiteSpace(TxtGenre.Text))
            {
                System.Windows.MessageBox.Show("Пожалуйста, заполните Название и Жанр игры!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TxtAge.Text, out int age) || age < 0)
            {
                System.Windows.MessageBox.Show("Возрастное ограничение должно быть целым положительным числом!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(TxtRating.Text, out double rating) || rating < 0 || rating > 10)
            {
                System.Windows.MessageBox.Show("Рейтинг должен быть числом от 0.0 до 10.0!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime releaseDate = DpRelease.SelectedDate ?? DateTime.Now;

            string imageUrl = string.IsNullOrWhiteSpace(TxtImage.Text)
                ? "https://static3.depositphotos.com/1000635/120/i/450/depositphotos_1208368-stock-photo-white-paper-seamless-background.jpg"
                : TxtImage.Text.Trim();

            string description = TxtDescription.Text.Trim() ?? "";

            string selectedType = (CmbType.SelectedItem as ComboBoxItem)?.Content?.ToString();

            Game newGame = null;
            if (selectedType == "Single")
            {
                newGame = new SingleGame(TxtTitle.Text.Trim(), TxtGenre.Text.Trim(), age, releaseDate, rating, imageUrl, description);
            }
            else if (selectedType == "Multiplayer")
            {
                newGame = new MultiplayerGame(TxtTitle.Text.Trim(), TxtGenre.Text.Trim(), age, releaseDate, rating, imageUrl, description);
            }
            else if (selectedType == "Online")
            {
                newGame = new OnlineGame(TxtTitle.Text.Trim(), TxtGenre.Text.Trim(), age, releaseDate, rating, imageUrl, description);
            }

            if (newGame != null)
            {
                int countBefore = _catalog.GetAllGames().Count;
                _catalog.Add(newGame);
                int countAfter = _catalog.GetAllGames().Count;

                if (countBefore == countAfter)
                {
                    System.Windows.MessageBox.Show($"Игра с названием \"{newGame.Title}\" уже присутствует в каталоге!", "Дублирование", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                TxtTitle.Clear();
                TxtGenre.Clear();
                TxtAge.Clear();
                TxtRating.Clear();
                TxtImage.Clear();
                TxtDescription.Clear();
                DpRelease.SelectedDate = DateTime.Now;

                RefreshTable();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Game selectedGame = GamesDataGrid.SelectedItem as Game;

            if (selectedGame == null)
            {
                System.Windows.MessageBox.Show("Выберите игру из таблицы для удаления!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirmResult = System.Windows.MessageBox.Show($"Вы действительно хотите безвозвратно удалить \"{selectedGame.Title}\" из каталога?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmResult == MessageBoxResult.Yes)
            {
                _catalog.Remove(selectedGame);
                RefreshTable();
            }
        }
    }
}
