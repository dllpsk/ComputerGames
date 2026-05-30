using Model.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model.Core
{
    public partial class GameCatalog
    {
        private string _catalogFilePath;

        // Инициализация каталога с путём для сохранения
        public void InitializeCatalogPath(string folderPath, string format = "json")
        {
            if (string.IsNullOrEmpty(folderPath)) return;

            _catalogFilePath = Path.Combine(folderPath, $"catalog.{format}");

            if (File.Exists(_catalogFilePath))
            {
                LoadFromFile(_catalogFilePath, format);
            }
            else
            {
                SaveToFile(_catalogFilePath, format);
            }
        }

        // Сохраняет каталог в файл (json или xml)
        public void SaveToFile(string filePath, string format = "json")
        {
            if (string.IsNullOrEmpty(filePath)) return;

            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (format.ToLower() == "json")
            {
                JsonSerialization serializer = new JsonSerialization();
                serializer.Serialize(filePath, _games);
            }
            else if (format.ToLower() == "xml")
            {
                XmlSerialization serializer = new XmlSerialization();
                serializer.Serialize(filePath, _games);
            }

            _catalogFilePath = filePath;
        }

        // Загружает каталог из файла (json или xml)
        public void LoadFromFile(string filePath, string format = "json")
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) return;

            List<Game> loadedGames = null;

            if (format.ToLower() == "json")
            {
                JsonSerialization serializer = new JsonSerialization();
                loadedGames = serializer.Deserialize(filePath);
            }
            else if (format.ToLower() == "xml")
            {
                XmlSerialization serializer = new XmlSerialization();
                loadedGames = serializer.Deserialize(filePath);
            }

            if (loadedGames != null && loadedGames.Count > 0)
            {
                _games = loadedGames;
                _catalogFilePath = filePath;
            }
        }
    }
}
