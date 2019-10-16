using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    //A class that has various methods for dealing with enums generally and our specific enums.
    public static class EnumUtils
    {
    public static string[] strAlternativeChoiceNames = { "None", "Big Deal", "TSA", "Mozart", "FBLA", "Sir Talk-a-lot" };
        //Returns either the DescriptionAttribute value of this enum or its string representation if it doesn't have one
        public static string GetDescription(this Enum en)
        {
            try
            {
                //Get the MemberInfo object for that specific enum value from its enum Type and then get the DescriptionAttribute from it and retrieve the description from that
                return ((DescriptionAttribute)(en.GetType().GetMember(en.ToString()).FirstOrDefault()
                    .GetCustomAttributes(typeof(DescriptionAttribute), true)[0])).Description;
            }
            catch (Exception)
            {
                //Fail-safe: just return the string representation of that enum value
                return en.ToString();
            }
        }
        /*
         * Sir Talk-a-lot beats Mozart and Big Deal
         * FBLA beats TSA and Sir Talk-a-lot
         * TSA beats Sir Talk-a-lot and Big Deal
         * Mozart beats FBLA and TSA
         * Big Deal beats FBLA and Mozart
         *
         * Spock beats Scissors and Rock
         * Lizard beats Paper and Spock
         * Paper beats Spock and Rock
         * Scissors beat Lizard and Paper
         * Rock beats Lizard and Scissors
         */
        public static bool CanBeat(this Choice ch, Choice otherChoice)
        {
            //If the ch follows any one of the possible winning patterns against otherChoice, return true
            switch (ch)
            {
                case Choice.Rock:
                    if (otherChoice == Choice.Scissors || otherChoice == Choice.Lizard)
                    {
                        return true;
                    }
                    break;

                case Choice.Paper:
                    if (otherChoice == Choice.Rock || otherChoice == Choice.Spock)
                    {
                        return true;
                    }
                    break;

                case Choice.Scissors:
                    if (otherChoice == Choice.Paper || otherChoice == Choice.Lizard)
                    {
                        return true;
                    }
                    break;

                case Choice.Lizard:
                    if (otherChoice == Choice.Paper || otherChoice == Choice.Spock)
                    {
                        return true;
                    }
                    break;

                case Choice.Spock:
                    if (otherChoice == Choice.Scissors || otherChoice == Choice.Rock)
                    {
                        return true;
                    }
                    break;
            }


            //If it doesn't follow any pattern, then return false (even if it's a draw)
            return false;
        }

        public static string ToString(this Choice ch, GameMode gameMode)
        {
            if (gameMode == GameMode.LettsEdition)
            {
                return strAlternativeChoiceNames[(int)ch];
            }
            else
            {
                return ch.ToString();
            }
        }
    }
}
