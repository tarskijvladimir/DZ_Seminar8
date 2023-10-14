// Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

using System;

public class MatrixOperations
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public static void SortRowsDescending(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            // Сортировка элементов текущей строки по убыванию
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                for (int k = j + 1; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > matrix[i, j])
                    {
                        for (int l = 0; l < matrix.GetLength(1); l++)
                        {
                            int temp = matrix[i, l];
                            matrix[i, l] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
        }
    }
}

public class Answer
{
    public static void Main(string[] args)
    {
        int[,] matrix;
        if (args.Length == 0)
        {
            // Если аргументы не переданы, используем матрицу по умолчанию
            matrix = new int[,] {
                {5, 2, 9},
                {8, 1, 4},
                {6, 7, 3}
            };
        }
        else
        {
            // Иначе, парсим аргументы в двумерный массив
            string[] rows = args[0].Split(';');
            matrix = new int[rows.Length, rows[0].Split(',').Length];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] elements = rows[i].Split(',');
                if (elements.Length != matrix.GetLength(1))
                {
                    Console.WriteLine($"Ошибка: Неправильное количество элементов в строке {i + 1}.");
                    return;
                }
                for (int j = 0; j < elements.Length; j++)
                {
                    if (int.TryParse(elements[j], out int number))
                    {
                        matrix[i, j] = number;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка при парсинге аргумента {elements[j]}.");
                        return;
                    }
                }
            }
        }

        Console.WriteLine("Исходная матрица:");
        MatrixOperations.PrintMatrix(matrix);

        MatrixOperations.SortRowsDescending(matrix);

        Console.WriteLine("\nМатрица с упорядоченными по убыванию строками:");
        MatrixOperations.PrintMatrix(matrix);
    }
}
