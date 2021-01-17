using System;


namespace kpyap_laba_15_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while(true)
            {
                Console.WriteLine("1. Начать новую игру \n2. Загрузить игру");
                string choice;
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                    {
                        Console.WriteLine("Введите начальное количество очков.");
                        int points = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество ходов.");
                        int steps = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество очков, которое нужно набрать для выйгрыша.");
                        int winPoints = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество посетителей за ход.");
                        int visitors = int.Parse(Console.ReadLine());
                        Game game = new Game(steps,visitors,points,winPoints);
                        Gameplay(game);
                        break;
                    }

                    case "2":
                    {
                        Game game = LoadGame();
                        Gameplay(game);
                        break;
                    }
                    default:
                         break;
                }

            }
        }

        static Game LoadGame()
        {
            // сериализя
            Game game = new Game(0,0,0,0);
            return game;
        }

        static void Gameplay(Game game)
        {
            while(game.GameStep())
            {
                Console.WriteLine(game.CurrentInfo());
            }
        }


    }
}
// Игра Ателье. Задача получить n очков, имея m, за t ходов. Если очков
// меньше 0 игрок проигрывает. Количество посетителей в день p.
// - провести рекламу. Стоит 100 очков х2 посетителей.
// - снять мерки. Стоит 15 очков +0.25х посетителей.
// - Сшить костюм. Указывается количество. Костюмы покупаются не в
// большем количестве, чем приходят посетители в ход. Стоит 20 очков. При
// покупке 50 очков.
// Случайно может прийти банда в начале хода и украсть все костюмы.
// Вероятность этого 20%. Генерироваться событие, когда это происходит