using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    public class Player
    {
        private Winner winner;
        private Choice choice;
        private GameMode gameMode;
        private int winCount;
        private int lossCount;
        private int drawCount;
        private int roundsPlayed;

        public Winner Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
            }
        }

        public Choice Choice
        {
            get
            {
                return choice;
            }
            set
            {
                choice = value;
            }
        }

        public GameMode GameMode
        {
            get
            {
                return gameMode;
            }
            set
            {
                gameMode = value;
            }
        }

        public int WinCount
        {
            get
            {
                return winCount;
            }
            set
            {
                winCount = value;
            }
        }

        public int LossCount
        {
            get
            {
                return lossCount;
            }
            set
            {
                lossCount = value;
            }
        }

        public int DrawCount
        {
            get
            {
                return drawCount;
            }
            set
            {
                drawCount = value;
            }
        }

        public int RoundsPlayed
        {
            get
            {
                return roundsPlayed;
            }
            set
            {
                roundsPlayed = value;
            }
        }

        public Player()
        {
            winner = Winner.User;
        }

        public Player(Winner wnrWinner)
        {
            winner = wnrWinner;
        }

        public void OnWinnerAnnounced(Winner wnrNewWinner)
        {
            //Increment the correct counter based on the winner
            if (wnrNewWinner == Winner)
                winCount++;
            else if (wnrNewWinner == Winner.Draw)
                drawCount++;
            else
                lossCount++;
            roundsPlayed++;
        }

        public override string ToString()
        {
            //Return a string representation of the player object
            return "Win count: " + WinCount + "\n" +
                "Draw count: " + DrawCount + "\n" +
                "Loss count: " + LossCount + "\n" +
                "Current Choice: " + choice.ToString(gameMode) + "\n" +
                "Rounds Played: " + roundsPlayed;
        }
    }
}
