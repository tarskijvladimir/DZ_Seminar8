// Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.

using System;

public class Answer
{
    public static int SumOfRow(int[,] matrix, int row)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[row, j];
        }
        return sum;
    }
    
    public static int[] MinimumSumRow(int[,] matrix)
    {
        int minRowIndex = 0;
        int minRowSum = SumOfRow(matrix, 0);
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            int rowSum = SumOfRow(matrix, i);
            if (rowSum < minRowSum)
            {
                minRowIndex = i;
                minRowSum = rowSum;
            }
        }
        return new int[] { minRowIndex, minRowSum };
    }

    public static void Main(string[] args)
    {
        // Пример использования методов
        int[,] matrix = new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
            {10, 11, 12}
        };
        Console.WriteLine($"Сумма элементов в строке 2: {SumOfRow(matrix, 2)}");
        int[] minRow = MinimumSumRow(matrix);
        Console.WriteLine($"Строка с наименьшей суммой элементов: {minRow[0]}, сумма элементов: {minRow[1]}");
    }
}
