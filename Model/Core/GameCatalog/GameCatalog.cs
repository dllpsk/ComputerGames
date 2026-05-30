using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class GameCatalog
    {
        // Список игр по умолчанию
        private List<Game> _games = new List<Game>()
        {
            new SingleGame(
                "Portal 2",
                "Puzzle",
                12,
                new DateTime(2011, 4, 18),
                9.0,
                "https://upload.wikimedia.org/wikipedia/en/f/f9/Portal2cover.jpg"),

            new SingleGame(
                "Skyrim",
                "RPG",
                18,
                new DateTime(2011, 11, 11),
                9.4,
                "https://i.redd.it/ctbgd6cujnc91.jpg"),

            new SingleGame(
                "The Witcher 3",
                "RPG",
                18,
                new DateTime(2015, 5, 19),
                9.8,
                "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/Witcher_3_cover_art.jpg/250px-Witcher_3_cover_art.jpg"),

            new SingleGame(
                "Cyberpunk 2077",
                "RPG",
                18,
                new DateTime(2020, 12, 10),
                8.5,
                "https://e.snmc.io/lk/o/x/861dfb13b8fd707ceee38785c3ab9742/11786140"),

            new SingleGame(
                "GTA V",
                "Action",
                18,
                new DateTime(2013, 9, 17),
                9.6,
                "https://upload.wikimedia.org/wikipedia/ru/c/c8/GTAV_Official_Cover_Art.jpg"),

            new SingleGame(
                "Elden Ring",
                "Action/RPG",
                16,
                new DateTime(2022, 2, 25),
                9.5,
                "https://m.media-amazon.com/images/I/614Y4NA6CVL._UF1000,1000_QL80_.jpg"),

            new SingleGame(
                "Doom Eternal",
                "Shooter",
                18,
                new DateTime(2020, 3, 20),
                8.8,
                "https://i.redd.it/b1ga0sjfnh5d1.jpeg"),

            new MultiplayerGame(
                "Terraria",
                "Sandbox",
                12,
                new DateTime(2011, 5, 16),
                8.9,
                "https://cdn.mobygames.com/covers/6798565-terraria-xbox-one-front-cover.jpg"),

            new MultiplayerGame(
                "Among Us",
                "Party",
                7,
                new DateTime(2018, 6, 15),
                7.5,
                "https://upload.wikimedia.org/wikipedia/en/thumb/9/9a/Among_Us_cover_art.jpg/250px-Among_Us_cover_art.jpg"),

            new MultiplayerGame(
                "Rocket League",
                "Sports",
                0,
                new DateTime(2015, 7, 7),
                8.6,
                "https://cdn.mobygames.com/covers/3195496-rocket-league-xbox-one-front-cover.jpg"),

            new MultiplayerGame(
                "Fall Guys",
                "Platformer",
                3,
                new DateTime(2020, 8, 4),
                8.0,
                "https://cdn.displate.com/artwork/270x380/2024-12-18/57c4c0df-d4d0-4d0d-bb66-ce66dee75db2.jpg"),

            new MultiplayerGame(
                "Minecraft",
                "Sandbox",
                6,
                new DateTime(2011, 11, 18),
                9.5,
                "https://upload.wikimedia.org/wikipedia/ru/archive/f/f4/20221114192239%21Minecraft_Cover_Art.png"),

            new MultiplayerGame(
                "It Takes Two",
                "Platformer",
                12,
                new DateTime(2021, 3, 26),
                9.7,
                "https://upload.wikimedia.org/wikipedia/en/a/aa/It_Takes_Two_cover_art.png"),

            new MultiplayerGame(
                "Overcooked! 2",
                "Simulator",
                3,
                new DateTime(2018, 8, 7),
                8.3,
                "https://upload.wikimedia.org/wikipedia/en/0/03/Overcooked_2_cover_art.png"),

            new OnlineGame(
                "Apex Legends",
                "Battle Royale",
                16,
                new DateTime(2019, 2, 4),
                8.2,
                "https://upload.wikimedia.org/wikipedia/en/d/db/Apex_legends_cover.jpg"),

            new OnlineGame(
                "Rust",
                "Survival",
                18,
                new DateTime(2018, 2, 8),
                8.0,
                "https://image.api.playstation.com/vulcan/ap/rnd/202103/1609/5xfXfcSQ71pczvAb6ANmrbxT.png"),

            new OnlineGame(
                "Dota 2",
                "MOBA",
                12,
                new DateTime(2013, 7, 9),
                8.4,
                "https://e.snmc.io/lk/f/x/9f1ed6ce6fa13239f3db66937204d1a6/5288889"),

            new OnlineGame(
                "Counter-Strike 2",
                "Shooter",
                18,
                new DateTime(2023, 9, 27),
                8.0,
                "https://upload.wikimedia.org/wikipedia/en/thumb/f/f2/CS2_Cover_Art.jpg/250px-CS2_Cover_Art.jpg"),

            new OnlineGame(
                "PUBG Mobile",
                "Battle Royale",
                16,
                new DateTime(2018, 3, 19),
                7.8,
                "https://m.media-amazon.com/images/M/MV5BODQzNzJjY2QtY2Y2YS00OWJmLTlkZWMtMmNmMmE2NTg1MjQzXkEyXkFqcGc@._V1_.jpg"),

            new OnlineGame(
                "Overwatch",
                "Hero Shooter",
                12,
                new DateTime(2016, 5, 24),
                8.1,
                "https://static.wikia.nocookie.net/overwatch_gamepedia/images/0/0a/Season_1_Conquest_Vertical.jpg/revision/latest?cb=20260212221731")
        };
        public List<Game> GetAllGames()
        {
            return _games;
        }


        public GameCatalog()
        {

        }


    }




}