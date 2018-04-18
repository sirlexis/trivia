using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using Trivia;
using static Trivia.Category;
using static Trivia.Location;

namespace TriviaTests
{
    [TestFixture]
    public class GameShould
    {
        [TestCase(Zero, Pop)]
        [TestCase(One, Science)]
        [TestCase(Two, Sports)]
        [TestCase(Three, Geography)]
        [TestCase(Four, Pop)]
        [TestCase(Five, Science)]
        [TestCase(Six, Sports)]
        [TestCase(Seven, Rock)]
        [TestCase(Eight, Pop)]
        [TestCase(Nine, Science)]
        [TestCase(Ten, Sports)]
        [TestCase(Eleven, Rock)]
        public void GiveCategoryForGivenPlayerLocation(Location playerLocation, Category expectedCategory)
        {
            var categoryForPlayer = Game.GiveCategoryFor(playerLocation);
            
            Assert.That(categoryForPlayer, Is.EqualTo(expectedCategory));
        }

        //[TestCase(1)]
        //[TestCase(10)]
        [TestCase(15)]
        public void AllowLocationToBeConfigurable(int numberOfLocations)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);

            var game = new Game(new GameSettings(new List<Player>(), numberOfLocations));

            var expectedOutput = stringWriter.ToString();
            Assert.True(expectedOutput.Contains("Number of locations was initialised to " + numberOfLocations));
        }
    }

}