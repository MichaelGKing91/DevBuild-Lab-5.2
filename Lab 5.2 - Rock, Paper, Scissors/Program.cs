using System;

namespace Lab_5._2___Rock__Paper__Scissors
{
    enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }
    abstract class Player
    {
        public string name;
        public Roshambo choice;
        public Random myRand = new Random();
        // Add method to genroshambo
        public virtual Roshambo GenerateRoshambo()
        {
            // This return does not matter; code path will never reach it.
            return choice;
        }
    }
    class PlayRock : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            name = "Rocky";
            return Roshambo.Rock;
        }
    }
    class PlayRandom : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            name = "Randi";
            int myInt = myRand.Next(0, 3);
            return (Roshambo)myInt;
        }
    }
    class PlayHuman : Player
    {
        public void SetName()
        {
            Console.Write("What is your name: ");
            name = Console.ReadLine();
        }
        public override Roshambo GenerateRoshambo()
        {

            Console.Write("\nRock, paper, or scissors? (R/P/S): ");
            string userChoice = Console.ReadLine().ToLower();
            while (userChoice != "r" && userChoice != "p" && userChoice != "s")
            {
                Console.Write("\nInvalid entry || Please type: 'R', 'P', or 'S'");
                userChoice = Console.ReadLine().ToLower();
            }
            if (userChoice == "r")
            {
                choice = Roshambo.Rock;
            }
            else if (userChoice == "p")
            {
                choice = Roshambo.Paper;
            }
            else
            {
                choice = Roshambo.Scissors;
            }
            return choice;
        }
    }
    class Program
    {

        public static string RunGame()
        {
            Console.Write("\nWho would you like to play against Rocky or Randi? ");
            string playerChoice = Console.ReadLine().ToLower();
            while (playerChoice != "rocky" && playerChoice != "randi")
            {
                Console.Write("\nInvalid response || Please type 'Rocky' or 'Randi':  ");
                playerChoice = Console.ReadLine().ToLower();
            }
            return playerChoice;

        }
        public static Roshambo PlayRocky()
        {
            PlayRock rocky = new PlayRock();
            return rocky.GenerateRoshambo();
        }
        public static Roshambo PlayRandi()
        {
            PlayRandom randi = new PlayRandom();
            return randi.GenerateRoshambo();
        }
        public static void DetermineWinner(Roshambo hummy, Roshambo PC)
        {
            if (hummy == PC)
            {
                Console.WriteLine("Tie game!");
            }
            else if (hummy == Roshambo.Rock && PC == Roshambo.Paper)
            {
                Console.WriteLine("You lose!");
            }
            else if (hummy == Roshambo.Rock && PC == Roshambo.Scissors)
            {
                Console.WriteLine("You win!");
            }
            else if (hummy == Roshambo.Paper && PC == Roshambo.Rock)
            {
                Console.WriteLine("You win!");
            }
            else if (hummy == Roshambo.Paper && PC == Roshambo.Scissors)
            {
                Console.WriteLine("You lose!");
            }
            else if (hummy == Roshambo.Scissors && PC == Roshambo.Rock)
            {
                Console.WriteLine("You lose!");
            }
            else if (hummy == Roshambo.Scissors && PC == Roshambo.Paper)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            PlayHuman hummy = new PlayHuman();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            bool done = false;
            while (!done)
            {
                string gameChoice = RunGame();
                Roshambo PCOutcome = Roshambo.Paper;
                if (gameChoice == "rocky")
                {
                    PCOutcome = PlayRocky();
                }
                else
                {
                    PCOutcome = PlayRandi();
                }
                Roshambo humanOutcome = hummy.GenerateRoshambo();
                Console.WriteLine($"\nYour choice: {humanOutcome}");
                if (gameChoice == "rocky")
                {
                    Console.WriteLine($"Rocky's choice: {PCOutcome}");
                }
                else
                {
                    Console.WriteLine($"Randi's choice: {PCOutcome}");
                }
                DetermineWinner(humanOutcome, PCOutcome);

                Console.Write("\nWould you like to play again? (Y/N): ");
                string doneYN = Console.ReadLine().ToLower();
                while (doneYN != "y" && doneYN != "yes" && doneYN != "n" && doneYN != "no")
                {
                    Console.Write("\nInvalid response || Play again? (Type 'Y' or 'N'): ");
                    doneYN = Console.ReadLine().ToLower();
                }
                if (doneYN == "n" || doneYN == "no")
                {
                    done = true;
                }
            }


        }
    }
}
