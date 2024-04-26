namespace LotteryTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            int columns = int.Parse(Console.ReadLine());
            int[,] ticket = new int[rows, columns];
            Console.WriteLine("Enter the elements of the ticket:");
            for (int i = 0; i < rows; i++)
            {
                string[] rowElements = Console.ReadLine().Split();
                for (int j = 0; j < columns; j++)
                {
                    ticket[i, j] = int.Parse(rowElements[j]);
                }
            }
            bool isWinning = IsWinningTicket(ticket, rows, columns);
            if (isWinning)
            {
                double winnings = CalculateWinnings(ticket, rows, columns);
                Console.WriteLine($"YES\nWinnings: {winnings:F2}");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static bool IsWinningTicket(int[,] ticket, int rows, int columns)
        {
            int mainDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            for (int i = 0; i < rows; i++)
            {
                mainDiagonalSum += ticket[i, i];
                secondaryDiagonalSum += ticket[i, columns - 1 - i];
            }
            if (mainDiagonalSum != secondaryDiagonalSum)
            {
                return false;
            }
            int aboveMainDiagonalSum = 0;
            int belowMainDiagonalSum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i < j)
                    {
                        aboveMainDiagonalSum += ticket[i, j];
                    }
                    else if (i > j)
                    {
                        belowMainDiagonalSum += ticket[i, j];
                    }
                }
            }
            if (aboveMainDiagonalSum % 2 != 0 || belowMainDiagonalSum % 2 == 0)
            {
                return false;
            }

            return true;
        }
        static double CalculateWinnings(int[,] ticket, int rows, int columns)
        {
            double belowMainDiagonalSum = 0;
            double mainDiagonalEvenSum = 0;
            double outerRowEvenSum = 0;
            double outerColumnOddSum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i > j)
                    {
                        belowMainDiagonalSum += ticket[i, j];
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                if (ticket[i, i] % 2 == 0)
                {
                    mainDiagonalEvenSum += ticket[i, i];
                }
            }
            for (int i = 0; i < columns; i++)
            {
                if (ticket[0, i] % 2 == 0)
                {
                    outerRowEvenSum += ticket[0, i];
                }
                if (ticket[rows - 1, i] % 2 == 0)
                {
                    outerRowEvenSum += ticket[rows - 1, i];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                if (ticket[i, 0] % 2 != 0)
                {
                    outerColumnOddSum += ticket[i, 0];
                }
                if (ticket[i, columns - 1] % 2 != 0)
                {
                    outerColumnOddSum += ticket[i, columns - 1];
                }
            }
            double winnings = (belowMainDiagonalSum + mainDiagonalEvenSum + outerRowEvenSum + outerColumnOddSum) / 4;
            return winnings;
        }   
    }
}
