using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day9
{
    public class MarbleGame
    {
        private readonly CircularLinkedList<int> _marblesOnBoard = new CircularLinkedList<int>();
        private readonly List<Player> _players = new List<Player>();
        private readonly int _totalMarbles;
        private readonly int _playerCount;

        public MarbleGame(GameAttributes gameAttributes)
        {
            SetupPlayers(gameAttributes);
            _totalMarbles = gameAttributes.LastMarbleValue;
            _playerCount = _players.Count();
        }

        public long GetWinningElfScore()
        {
            PlayGameTilCompletion();

            return _players.Max(m => m.Points);
        }

        private void PlayGameTilCompletion()
        {
            // First marble, not associated with a player
            _marblesOnBoard.Add(0);

            PlayMarbles();
        }

        private void PlayMarbles()
        {
            for (var marbleNumber = 1; marbleNumber < _totalMarbles + 1; marbleNumber++)
            {
                // special logic if marble is mod 23
                /*
                 *  keep marble (as points), take marble off board 7 indexes counter clockwise, 
                 *  add both marbles to player's points
                 *  */
                if (marbleNumber % 23 == 0)
                {
                    var points = marbleNumber;
                    var itemToRemove = _marblesOnBoard.GetPrevious(7);
                    _marblesOnBoard.Remove(itemToRemove);
                    points += itemToRemove.Value;

                    _players[marbleNumber % _playerCount].Points += points;
                }
                else
                {
                    _marblesOnBoard.GetNext(1);
                    _marblesOnBoard.Add(marbleNumber);
                }
            }
        }

        private void SetupPlayers(GameAttributes gameAttributes)
        {
            for (var i = 0; i < gameAttributes.NumberOfPlayers; i++)
            {
                _players.Add(new Player()
                {
                    PlayerId = i
                });
            }
        }
    }
}
