using FluentAssertions;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Bowling.SpecFlowXUnit.Drivers
{
    public class BowlingDriver
    {
        private Game _game;
        private readonly Random random = new Random();

        public void NewGame()
        {
            _game = new Game();
        }

        public void Roll(int pins, int rollCont)
        {
            for (int i = 0; i < rollCont; i++)
            {
                Thread.Sleep(random.Next(100, 1000));
                _game.Roll(pins);
            }
        }

        public void Roll(int pins1, int pins2, int rollCount)
        {
            for (int i = 0; i < rollCount; i++)
            {
                Thread.Sleep(random.Next(100, 1000));
                _game.Roll(pins1);
                Thread.Sleep(random.Next(100, 1000));
                _game.Roll(pins2);
            }
        }

        public void RollSeries(string series)
        {
            foreach (string roll in series.Trim().Split(','))
            {
                Thread.Sleep(random.Next(100, 1000));
                _game.Roll(int.Parse(roll));
            }
        }

        public void RollSeries(Table rolls)
        {
            foreach (var row in rolls.Rows)
            {
                Thread.Sleep(random.Next(100, 1000));
                _game.Roll(int.Parse(row["Pins"]));
            }
        }

        public void CheckScore(int expected)
        {
            _game.Score.Should().Be(expected);
        }
    }
}
