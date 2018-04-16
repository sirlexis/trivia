﻿using System;
using System.Collections.Generic;
using System.Linq;
using static Trivia.Location;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players = new Players();

        private readonly int[] _location = new int[6];
        private readonly int[] _purses = new int[6];

        private readonly bool[] _inPenaltyBox = new bool[6];

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayer = 0;
        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast("Rock Question " + i);
            }
        }

        public bool add(string playerName)
        {
            _players.Add(playerName);
            _location[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayerInPenaltyBox())
            {
                if (RolledOdd(roll))
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    
                    MovePlayer(roll);
                    
                    if (_location[_currentPlayer] > 11) _location[_currentPlayer] = _location[_currentPlayer] - 12;

                    Console.WriteLine(_players[_currentPlayer]
                            + "'s new location is "
                            + _location[_currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory((Location)_location[_currentPlayer]));
                    AskQuestion();
                }
                
                if (!RolledOdd(roll))
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            
            if (!CurrentPlayerInPenaltyBox())
            {
                MovePlayer(roll);
                if (_location[_currentPlayer] > 11) _location[_currentPlayer] = _location[_currentPlayer] - 12;

                Console.WriteLine(_players[_currentPlayer]
                        + "'s new location is "
                        + _location[_currentPlayer]);
                Console.WriteLine("The category is " + CurrentCategory((Location)_location[_currentPlayer]));
                AskQuestion();
            }

        }

        private void MovePlayer(int roll)
        {
            _location[_currentPlayer] = _location[_currentPlayer] + roll;
        }

        private static bool RolledOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private bool CurrentPlayerInPenaltyBox()
        {
            return _inPenaltyBox[_currentPlayer];
        }

        private void AskQuestion()
        {
            if (CurrentCategory((Location)_location[_currentPlayer]) == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory((Location)_location[_currentPlayer]) == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory((Location)_location[_currentPlayer]) == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory((Location)_location[_currentPlayer]) == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        public string CurrentCategory(Location currentPlayerLocation)
        {
            if (currentPlayerLocation == Zero) return "Pop";
            if (currentPlayerLocation == Four) return "Pop";
            if (currentPlayerLocation == Eight) return "Pop";
            if (currentPlayerLocation == One) return "Science";
            if (currentPlayerLocation == Five) return "Science";
            if (currentPlayerLocation == Nine) return "Science";
            if (currentPlayerLocation == Two) return "Sports";
            if (currentPlayerLocation == Six) return "Sports";
            if (currentPlayerLocation == Ten) return "Sports";
            return "Rock";
        }

        public bool AnsweredCorrectly()
        {
            if (CurrentPlayerInPenaltyBox())
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    
                    GiveCoinToCurrentPlayer();
                    
                    Console.WriteLine(_players[_currentPlayer]
                            + " now has "
                            + _purses[_currentPlayer]
                            + " Gold Coins.");

                    var winner = CurrentPlayerIsNoWinner();
                    
                    SetNextPlayer();
                    
                    ResetPlayerIfLast();
                    
                    return winner;
                }

                SetNextPlayer();
                    
                ResetPlayerIfLast();
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            GiveCoinToCurrentPlayer();
            Console.WriteLine(_players[_currentPlayer]
                              + " now has "
                              + _purses[_currentPlayer]
                              + " Gold Coins.");

            var currentPlayerIsNoWinner = CurrentPlayerIsNoWinner();
                
            SetNextPlayer();
                
            ResetPlayerIfLast();

            return currentPlayerIsNoWinner;
        }

        private void GiveCoinToCurrentPlayer()
        {
            _purses[_currentPlayer]++;
        }

        public bool AnsweredIncorrectly()
        {
            Console.WriteLine("Question was incorrectly answered");
            
            PutCurrentPlayerInPenaltyBox();
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");

            SetNextPlayer();
            
            ResetPlayerIfLast();
            
            return true;
        }

        private void ResetPlayerIfLast()
        {
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        private void PutCurrentPlayerInPenaltyBox()
        {
            _inPenaltyBox[_currentPlayer] = true;
        }

        private void SetNextPlayer()
        {
            _currentPlayer++;
        }

        private bool CurrentPlayerIsNoWinner()
        {
            return _purses[_currentPlayer] != 6;
        }
    }

    public enum Location
    {
        Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Eleven
    }
}
