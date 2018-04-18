using System;
using System.Collections.Generic;
using Trivia;

internal class TriviaGame
{
    private static bool _notAWinner;

    public void Execute()
    {
        var gameSettings = new GameSettings(new List<Player>
        {
            new Player("Chet"),
            new Player("Pat"),
            new Player("Sue")
        }, Location.Five);
        var game = new Game(gameSettings);
        var rand = new Random();

        do
        {
            game.roll(rand.Next(5) + 1);

            if (rand.Next(9) == 7)
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