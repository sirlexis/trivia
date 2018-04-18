using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GameRunnerGoldenMaster
    {
        private static bool _notAWinner;

        public void Execute(int seed)
        {
            var gameSettings = new GameSettings(new List<Player>
                {
                    new Player("Chet"),
                    new Player("Pat"),
                    new Player("Sue")
                }, Location.Eleven);
            var game = new Game(gameSettings);

            //aGame.Add("Chet");
            //aGame.Add("Pat");
            //aGame.Add("Sue");

            var randomizer = new Random(seed);

            do
            {
                game.roll(randomizer.Next(5) + 1);

                if (randomizer.Next(9) == 7)
                {
                    _notAWinner = game.AnsweredIncorrectly();
                }
                else
                {
                    _notAWinner = game.AnsweredCorrectly();
                }
            } while (_notAWinner);
        }
    }
}