using System;
using System.Threading.Tasks;
using Labyrinth.Model;
using Labyrinth.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Labyrinth.Test
{
    [TestClass]
    public class LabyrinthTest
    {
        private LabyrinthGameModel _model = null!;
        private LabyrinthField[,] _mockedLabyrinth = null!;
        private Mock<ILabyrinthDataAccess> _mock = null!;

        [TestInitialize]
        public void Initialize()
        {
            _mockedLabyrinth = OriginalLabyrinth();

            _mock = new Mock<ILabyrinthDataAccess>();
            _mock.Setup(mock => mock.Load(It.IsAny<String>()))
                .Returns(() => _mockedLabyrinth);

            _model = new LabyrinthGameModel(_mock.Object);
        }


        [TestMethod]
        public void LabyrinthLoadTest()
        {
            bool loaded = false;
            void VerifyLoad(Object? sender, LabyrinthEventArgs e)
            {
                loaded = true;
                LabyrinthField[,] originalLabyrinth = OriginalLabyrinth();
                for (int i = 0; i < _mockedLabyrinth.GetLength(0); i++)
                {
                    for (int j = 0; j < _mockedLabyrinth.GetLength(1); j++)
                    {
                        if(i == _mockedLabyrinth.GetLength(0) - 1 && j == 0)
                        {
                            Assert.AreEqual(e.Labyrinth[i, j].type, LabyrinthFieldType.Player);
                        }
                        else
                        {
                            Assert.AreEqual(e.Labyrinth[i, j].type, originalLabyrinth[i, j].type);
                        }
                    }
                }
            }
            _model.GameStarted += new EventHandler<LabyrinthEventArgs>(VerifyLoad);
            _model.Load("");

            Assert.IsTrue(loaded);
        }

        [TestMethod]
        public void LabyrinthValidMoveTest()
        {
            bool moved = false;
            void VerifyMove(Object? sender, LabyrinthEventArgs e)
            {
                moved = true;
                LabyrinthField[,] originalLabyrinth = OriginalLabyrinth();
                for (int i = 0; i < _mockedLabyrinth.GetLength(0); i++)
                {
                    for (int j = 0; j < _mockedLabyrinth.GetLength(1); j++)
                    {
                        if (i == _mockedLabyrinth.GetLength(0) - 1 && j == 1)
                        {
                            Assert.AreEqual(e.Labyrinth[i, j].type, LabyrinthFieldType.Player);
                        }
                        else
                        {
                            Assert.AreEqual(e.Labyrinth[i, j].type, originalLabyrinth[i, j].type);
                        }
                    }
                }
            }
            _model.PlayerMoved += new EventHandler<LabyrinthEventArgs>(VerifyMove);
            _model.Load("");
            _model.Move(LabyrinthDirection.Right);

            Assert.IsTrue(moved);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid direction.")]
        [DataRow(LabyrinthDirection.Down)]
        [DataRow(LabyrinthDirection.Left)]
        [DataRow(LabyrinthDirection.Up)]
        public void LabyrinthInValidMoveTest(LabyrinthDirection direction)
        {
            _model.Load("");
            _model.Move(direction);
        }

        [TestMethod]
        public void LabyrinthVisibilityTest()
        {
            _model.Load("");

            Assert.IsTrue(_model.Labyrinth[3, 0].isVisible);
            Assert.IsTrue(_model.Labyrinth[3, 1].isVisible);
            Assert.IsTrue(_model.Labyrinth[3, 2].isVisible);
            Assert.IsFalse(_model.Labyrinth[3, 3].isVisible);
            Assert.IsFalse(_model.Labyrinth[0, 1].isVisible);

            _model.Move(LabyrinthDirection.Right);
            Assert.IsTrue(_model.Labyrinth[1, 3].isVisible);
            Assert.IsFalse(_model.Labyrinth[0, 1].isVisible);

            _model.Move(LabyrinthDirection.Up);
            Assert.IsTrue(_model.Labyrinth[0, 1].isVisible);

            _model.Move(LabyrinthDirection.Down);
            _model.Move(LabyrinthDirection.Left);
            Assert.IsFalse(_model.Labyrinth[1, 3].isVisible);
        }

        [TestMethod]
        public void LabyrinthGameOver()
        {
            _model.Load("");
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Right);
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Right);
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Right);
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Up);
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Up);
            Assert.IsFalse(_model.GameOver);

            _model.Move(LabyrinthDirection.Up);
            Assert.IsTrue(_model.GameOver);
        }

        [TestMethod]
        public void LabyrinthAdvanceTime()
        {
            _model.Load("");
            Assert.AreEqual(_model.Time, 0);
            Assert.IsFalse(_model.Paused);

            _model.AdvanceTime();
            Assert.AreEqual(_model.Time, 1);

            _model.Paused = true;
            _model.AdvanceTime();
            Assert.AreEqual(_model.Time, 1);

            _model.Paused = false;
            _model.AdvanceTime();
            Assert.AreEqual(_model.Time, 2);
        }

        private LabyrinthField[,] OriginalLabyrinth()
        {
            return new LabyrinthField[,]{
                { new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty) },
                { new LabyrinthField(LabyrinthFieldType.Wall), new LabyrinthField(LabyrinthFieldType.Wall), new LabyrinthField(LabyrinthFieldType.Wall), new LabyrinthField(LabyrinthFieldType.Empty) },
                { new LabyrinthField(LabyrinthFieldType.Wall), new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Wall), new LabyrinthField(LabyrinthFieldType.Empty) },
                { new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty), new LabyrinthField(LabyrinthFieldType.Empty) }
            };
        }
    }
}
