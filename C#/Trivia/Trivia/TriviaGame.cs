using System;
using Trivia;

internal class TriviaGame
{
    private static bool _notAWinner;

    public void Execute()
    {
        var aGame = new Game();

        aGame.Add("Chet");
        aGame.Add("Pat");
        aGame.Add("Sue");

        var rand = new Random();

        do
        {
            aGame.roll(rand.Next(5) + 1);

            if (rand.Next(9) == 7)
            {
                _notAWinner = aGame.AnsweredIncorrectly();
            }
            else
            {
                _notAWinner = aGame.AnsweredCorrectly();
            }
        } while (_notAWinner);
    }
}