using LetsGetChecked.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsGetChecked.Tests
{
    [TestClass]
    public class TurtleTests
    {
        [TestMethod]
        [DataRow("gameSettings.json", "MovesSuccess.json", "Success")]
        [DataRow("gameSettings.json", "MovesStillInDanger.json", "Still In Danger!!")]
        public void EnsureThatWillMoveTheTurtleFollowingTheSequence(string gameSettings, string moveFile, string expectedResult)
        {
            var _sut = new Turtle(gameSettings);
            var result = _sut.MoveTurtleFollowingSequence(moveFile);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod]
        [DataRow("gameSettings.json", "MovesOutOfBonds.json")]
        [ExpectedException(typeof(OutOfBondsException))]
        public void EnsureThatWillThrownExceptionWhenOutOfBounds(string gameSettings, string moveFile)
        {
            var _sut = new Turtle(gameSettings);
            _sut.MoveTurtleFollowingSequence(moveFile);
        }

        [TestMethod]
        [DataRow("gameSettings.json", "MovesHittingMine.json")]
        [ExpectedException(typeof(MineHitException))]
        public void EnsureThatWillThrownExceptionWhenHittingMine(string gameSettings, string moveFile)
        {
            var _sut = new Turtle(gameSettings);
            _sut.MoveTurtleFollowingSequence(moveFile);
        }
    }
}
