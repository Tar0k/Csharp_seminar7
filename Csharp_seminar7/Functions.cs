namespace Csharp_seminar7;

public static class Functions
{
    public static int  GetUserInt(string variableDescription = "целочисленное значение")
    {
        while (true)
        {
            Console.Write($"Введите {variableDescription}: ");
            var userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("!!!НИЧЕГО НЕ ВВЕДЕНО!!!");
                continue;
            }
            if (int.TryParse(userInput, out var userInt)) return userInt;
            Console.WriteLine("!!!НЕ КОРРЕКТНЫЙ ВВОД!!!");
        }
    }
    
    public static int[,] Generate2DIntArray(
        int rows,
        int columns,
        int minElement = 1,
        int maxElement = 10
        )
    {
        var array = new int[rows, columns];
        var random = new Random();
        for (var row = 0; row < array.GetLength(0); row++)
        {
            for (var column = 0; column < array.GetLength(1); column++)
            {
                array[row, column] = random.Next(minElement, maxElement);
            }
        }
    
        return array;
    }
    
    public static double[,] Generate2DDoubleArray(
        int rows,
        int columns,
        int decimalPlaces = 0,
        int minElement = 1, 
        int maxElement = 10
        )
    {
        var array = new double[rows, columns];
        var random = new Random();
        for (var row = 0; row < array.GetLength(0); row++)
        {
            for (var column = 0; column < array.GetLength(1); column++)
            {
                array[row, column] = Math.Round(random.NextDouble() * (maxElement - minElement) + minElement, decimalPlaces);
            }
        }
        return array;
    }
    
    public static void Print2DArray(int[,] array) 
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    public static void Print2DArray(double[,] array) 
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}