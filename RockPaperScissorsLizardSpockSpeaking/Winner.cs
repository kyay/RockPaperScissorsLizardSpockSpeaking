using System.ComponentModel;

namespace RockPaperScissorsLizardSpock
{
    //An enum that represent the winner of a round of Tic Tac Toe
    public enum Winner
    {
        //The winner is X
        [Description("User wins!!")]
        User,
        //The winner is O
        [Description("Computer wins!!")]
        Computer,
        //There is no winner and it's a draw
        [Description("It's a Draw!!!")]
        Draw
    }
}
