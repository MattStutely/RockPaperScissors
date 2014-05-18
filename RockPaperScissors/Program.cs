using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        private static GameEngine _gameEngine = new GameEngine();
        private static int _p1Score = 0;
        private static int _p2Score = 0;

        public static void Main(string[] args)
        {
            Console.BackgroundColor=ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("ROCK - PAPER - SCISSORS");
            Console.WriteLine("A timeless classic brought to you by @MattStutely");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            Console.Write("Would you like to play a game? ");
            while (Console.ReadLine().ToLower().StartsWith("y"))
            {
                Console.Write("Are you playing this one (Y) or do you want CPU v CPU (any other key)? ");
                string gameType = Console.ReadLine();
                Console.WriteLine();
                if (gameType.ToLower() == "y")
                {                    
                    PlayHumanVsComputer();
                }
                else
                {
                    PlayComputerVsComputer();    
                }
                Console.Write("Would you like to play another game? ");
            }
            Console.WriteLine();
            Console.WriteLine("Well OK then - see ya!");
            Console.WriteLine("-- Press any key to quit --");
            Console.ReadKey();
        }

        private static void PlayComputerVsComputer()
        {
            //how many games
            int gamesToPlay = 0;

            _p1Score = 0;
            _p2Score = 0;

            while (gamesToPlay == 0)
            {
                gamesToPlay = SetUpGamesToPlay();
            }

            for (int i = 1; i <= gamesToPlay; i++)
            {
                WriteGameStartStuff(i);
                var response = _gameEngine.GetComputerResponse();
                Console.WriteLine("I choose " + response);
                Thread.Sleep(200);
                var cpuResponse = _gameEngine.GetComputerResponse();
                Thread.Sleep(200);
                Console.WriteLine("My alter-ego chooses " + cpuResponse + (response == cpuResponse ? " too!" : ""));
                Thread.Sleep(500);
                var outcome = _gameEngine.FirstResponseOutcome(response, cpuResponse);

                switch (outcome)
                {
                    case GameEngine.Outcome.Win:
                        Console.WriteLine("One point to me!");
                        _p1Score++;
                        break;
                    case GameEngine.Outcome.Lose:
                        Console.WriteLine("One point to Joshua!");
                        _p2Score++;
                        break;
                    case GameEngine.Outcome.Draw:
                        Console.WriteLine("Ooh the excitement!");
                        break;
                }
                Thread.Sleep(500);
            }

            //done
            Console.WriteLine();
            WriteResult("Me", "Joshua");
            Console.WriteLine();
            Console.WriteLine("A strange game. The only winning move is not to play.");
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        private static void WriteGameStartStuff(int round)
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("OK here we go with Round #" + round);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        
        private static void PlayHumanVsComputer()
        {
            //how many games
            int gamesToPlay = 0;
            _p1Score = 0;
            _p2Score = 0; 
            
            while (gamesToPlay == 0)
            {
                gamesToPlay = SetUpGamesToPlay();
            }

            for (int i = 1;i<=gamesToPlay;i++)
            {
                WriteGameStartStuff(i);   
                var response = CaptureResponse();
                var cpuResponse = _gameEngine.GetComputerResponse();
                Thread.Sleep(200);
                Console.WriteLine("I choose " + cpuResponse + (response==cpuResponse ? " too!" : ""));
                Thread.Sleep(500);
                var outcome = _gameEngine.FirstResponseOutcome(response, cpuResponse);

                switch (outcome)
                {
                    case GameEngine.Outcome.Win:
                        Console.WriteLine("One point to you!");
                        _p1Score++;
                        break;
                    case GameEngine.Outcome.Lose:
                        Console.WriteLine("One point to me!");
                        _p2Score++;
                        break;
                    case GameEngine.Outcome.Draw:
                        Console.WriteLine("Ooh the excitement!");
                        break;
                }
            }
            
            //done
            Console.WriteLine();
            WriteResult("You", "I");
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine();
        }

        private static void WriteResult(string p1Name, string p2Name)
        {
            Console.WriteLine("Thats it!! The final score is...");
            Console.WriteLine(p1Name + " : " + _p1Score);
            Console.WriteLine(p2Name + " : " + _p2Score);

            var outcome = _gameEngine.PlayerOneGameOutcome(_p1Score, _p2Score);

            switch (outcome)
            {
                case GameEngine.Outcome.Win:
                    Console.WriteLine(p1Name + " win!! Hail to the master");
                    break;
                case GameEngine.Outcome.Draw:
                    Console.WriteLine("A draw, what elite minds have been at work!");
                    break;
                case GameEngine.Outcome.Lose:
                    Console.WriteLine(p2Name + " win!! Hail to the master");
                    break;
            }
        }

        private static GameEngine.Response CaptureResponse()
        {
            GameEngine.Response? response = null;
            Console.WriteLine("Please make your selection");

            while (response==null)
            {
                Console.Write("(R)ock, (P)aper, or (S)cissors? ");
                string enteredResponse = Console.ReadLine();
                response = _gameEngine.GetResponseFromEnteredString(enteredResponse);
                if (response == null)
                {
                    Console.WriteLine("Ahem, maybe you made a mistake, try again...");    
                }
            }

            return (GameEngine.Response) response;
        }


        private static int SetUpGamesToPlay()
        {
            int gamesToPlay = 0;
            Console.Write("How many rounds in this game? (Let's not get bored, no more than 7) : ");
            string gamesToPlayEntered = Console.ReadLine();
            if (_gameEngine.IsAnInteger(gamesToPlayEntered))
            {
                if (_gameEngine.ValidNumberOfGames(int.Parse(gamesToPlayEntered),7))
                {
                    return int.Parse(gamesToPlayEntered);
                }
                else
                {
                    Console.WriteLine("No, that is too many/too few, try again...");
                }
            }
            else
            {
                Console.WriteLine("No, you need to enter a number, not some random text...");
            }
            Console.WriteLine();
            return gamesToPlay;
        }
    }
}
