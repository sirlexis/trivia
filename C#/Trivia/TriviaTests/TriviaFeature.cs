using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class TriviaFeature
    {
        [TestCase(1, 1)]
        [TestCase(2, 10)]
        [TestCase(3, 49)]
        [TestCase(4, 599)]
        [TestCase(5, 5000)]
        [TestCase(6, 6837)]
        public void ShouldProvideMeWithGoldenMasters(int goldeMasterFileId, int seed)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);

            var gameRunner = new GameRunnerGoldenMaster();

            gameRunner.Execute(seed);

            var result = stringWriter.ToString();

            using (var tw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"GoldenMaster{goldeMasterFileId}.txt"), true))
            {
                tw.WriteLine(result);
            }
        }

        [TestCase(1, 1)]
        [TestCase(2, 10)]
        [TestCase(3, 49)]
        [TestCase(4, 599)]
        [TestCase(5, 5000)]
        [TestCase(6, 6837)]
        public void CheckAgainstGameRunner(int goldeMasterFileId, int seed)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetError(stringWriter);
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                    $"GoldenMaster{goldeMasterFileId}.txt");
            var expectedResult = File.ReadAllText(path);
            var gameRunner = new GameRunnerGoldenMaster();
            
            gameRunner.Execute(seed);
            var actualResult = stringWriter.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}