using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameEngine
    {
        public enum Response
        {
            Rock = 1, //beats scissors
            Scissors = 2,  //beats paper
            Paper = 3//beats rock
        }

        public enum Outcome
        {
            Win,
            Lose,
            Draw
        }

        public Response? GetResponseFromEnteredString(string enteredString)
        {
            switch (enteredString.ToLower())
            {
                case "r":
                    return Response.Rock;
                case "p":
                    return Response.Paper;
                case "s":
                    return Response.Scissors;
                default:
                    return null;
            }
        }

        public Outcome PlayerOneGameOutcome(int p1Score, int p2Score)
        {
            if (p1Score > p2Score)
            {
                return Outcome.Win;
            }
            if (p1Score == p2Score)
            {
                return Outcome.Draw;
            }
            
            return Outcome.Lose;
            
        }

        public bool IsAnInteger(string enteredValue)
        {
            return enteredValue.All(Char.IsDigit) && enteredValue.Length<=9; // not really quite an int, cos misses the billions, but it will do
        }

        public bool ValidNumberOfGames(int gamesRequested, int maxGames)
        {
            return gamesRequested <= maxGames && gamesRequested > 0;
        }

        public Response GetComputerResponse()
        {
            var computerResponse = new Random();
            return (Response)computerResponse.Next(1, 3);
        }

        public Outcome FirstResponseOutcome(Response firstResponse, Response secondResponse)
        {

            if (firstResponse == secondResponse)
            {
                return Outcome.Draw;
            }

            if (firstResponse == Response.Rock && secondResponse == Response.Scissors)
            {
                return Outcome.Win;
            }

            if (firstResponse == Response.Scissors && secondResponse == Response.Paper)
            {
                return Outcome.Win;
            }

            if (firstResponse == Response.Paper && secondResponse == Response.Rock)
            {
                return Outcome.Win;
            }

            //no win, no draw then it must be...
            return Outcome.Lose;

        }

    }
}
