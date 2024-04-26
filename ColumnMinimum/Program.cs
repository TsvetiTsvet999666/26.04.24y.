namespace ColumnMinimum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns:");
            int columns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, columns];
            Console.WriteLine($"Enter {rows} rows with {columns} elements each:");
            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine().Split();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(rowValues[j]);
                }
            }
            int[] minElements = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                int min = int.MaxValue;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                minElements[j] = min;
            }
            Console.WriteLine("The matrix with the minimum elements per column is:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
