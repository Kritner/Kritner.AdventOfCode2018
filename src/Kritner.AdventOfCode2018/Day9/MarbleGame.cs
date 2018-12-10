using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kritner.AdventOfCode2018.Day9
{
    public class MarbleGame
    {
        private CircularList<int> _marblesOnBoard;
        private HashSet<Player> _players = new HashSet<Player>();
        private readonly int _totalMarbles;
        private int _marblesPlayed;

        public MarbleGame(GameAttributes gameAttributes)
        {
            _marblesOnBoard = new CircularList<int>(
                gameAttributes.LastMarbleValue + 1
            );

            SetupPlayers(gameAttributes);
            SetupPlayersMarbles(gameAttributes);
            _totalMarbles = gameAttributes.LastMarbleValue;
        }

        public long GetWinningElfScore()
        {
            PlayGameTilCompletion();

            return _players.Max(m => m.Points);
        }

        private void PlayGameTilCompletion()
        {
            // First marble, not associated with a player
            _marblesOnBoard.Add(0, 0);

            PlayMarbles();
        }

        private void PlayMarbles()
        {
            while (_marblesPlayed < _totalMarbles)
            {
                for (var playerNumber = 0; playerNumber < _players.Count; playerNumber++)
                {
                    // No more marbles to play, will break after for loop
                    if (_marblesPlayed >= _totalMarbles) 
                    {
                        break;
                    }

                    var player = _players.Where(w => w.PlayerId == playerNumber).First();

                    // No more marbles for this player
                    if (player.Marbles.Count == 0)
                    {
                        continue;
                    }

                    var marbleToPlay = player.Marbles.Dequeue();
                    _marblesPlayed++;

                    // special logic if marble is mod 23
                    /*
                     *  keep marble (as points), take marble off board 7 indeces counter clockwise, 
                     *  add both marbles to player's points
                     *  */
                    if (marbleToPlay % 23 == 0)
                    {
                        var points = marbleToPlay;
                        points += _marblesOnBoard.Remove(_marblesOnBoard.GetIndexRotatingCounterClockWise(7));

                        player.Points += points;
                    }
                    else
                    {
                        _marblesOnBoard.Add(_marblesOnBoard.GetIndexRotatingClockWise(2), marbleToPlay);
                    }
                }
            }
        }

        private void SetupPlayers(GameAttributes gameAttributes)
        {
            for (int i = 0; i < gameAttributes.NumberOfPlayers; i++)
            {
                _players.Add(new Player()
                {
                    PlayerId = i
                });
            }
        }

        private void SetupPlayersMarbles(GameAttributes gameAttributes)
        {
            int currentMarbleValue = 1;
            while (currentMarbleValue < gameAttributes.LastMarbleValue)
            {
                for (var playerNumber = 0; playerNumber < gameAttributes.NumberOfPlayers; playerNumber++)
                {
                    var player = _players.Where(w => w.PlayerId == playerNumber).First();
                    player.Marbles.Enqueue(currentMarbleValue++);
                }
            }
        }
    }
}
