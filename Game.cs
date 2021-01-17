using System;

namespace kpyap_laba_15_2
{
    [Serializable]
    public class Game
    {
        int points;
        int visitorsPerDay;
        int remainingMoves;
        int costumes;
        int pointsToWin;

        const int robberyProbability = 20;
        const int CostumeCreationPrice = 20;
        const int CostumeSellingPrice = 50;

        

        public Game(int movesCount, int visitorsPerDay, int startPoints, int pointsToWin)
        {
            this.points = startPoints;
            this.visitorsPerDay = visitorsPerDay;
            this.remainingMoves = movesCount;
            this.pointsToWin = pointsToWin;
        }
        public void Ad()
        {
            points-=100;
            visitorsPerDay*=2;
        }
        public void TakeMeasurements()
        {
            points-=15;
            visitorsPerDay+=visitorsPerDay/4;
        }

        public void SewCostumes(int amount)
        {
            points-=CostumeCreationPrice*amount;
            costumes+=amount;
        }

        public void Robbery()
        {
            costumes = 0;
            ///// событие (обработка нулевого значения в костюмах)
        }

        public string CurrentInfo()
        {
            return $"ходов осталось - {remainingMoves}\nочки - {points}\nпосетителей за ход - {visitorsPerDay}\nкостюмов имеется - {costumes}\n ";
        }
        
        public void SaveGame()
        {
            
        }

        public void BuyingСostumes(int amount)
        {
            if(amount>costumes) 
                {
                    amount = costumes;                    
                }
            costumes-=amount;
            points+=amount*CostumeSellingPrice;
            ////// событие и количество тоже показывать
        }

        public bool GameStep()
        {
            bool IsContinue = true;
            remainingMoves--;
            if(remainingMoves == 0 || points < 0)
               {
                // проигрыш
                IsContinue = false;
               }
            Random random = new Random();
            int boughtСostumes = random.Next(visitorsPerDay);
            if(boughtСostumes>0 && costumes>0)
            {
                BuyingСostumes(boughtСostumes);
            }
            if(random.Next(100)<robberyProbability)
            {
                Robbery();
            }
            if(points>=pointsToWin)
            {
                // выйгрыш
                IsContinue = false;
            }
            return IsContinue;
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