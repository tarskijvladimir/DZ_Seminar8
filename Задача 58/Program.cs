// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

using System;

public class MatrixOperations
{
        public static void MultiplyIfPossible(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                Console.WriteLine("It is impossible to multiply.");
                return;
            }

            int[,] resultMatrix = MatrixMultiplication(matrixA, matrixB);
            Console.WriteLine("Result:");
            PrintMatrix(resultMatrix);
        }

    public static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
    {
        if (matrixA.GetLength(1) != matrixB.GetLength(0))
        {
            throw new ArgumentException("The number of columns in matrix A must match the number of rows in matrix B.");
        }

        int rowsA = matrixA.GetLength(0);
        int columnsA = matrixA.GetLength(1);
        int columnsB = matrixB.GetLength(1);

        int[,] resultMatrix = new int[rowsA, columnsB];
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < columnsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < columnsA; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }
        return resultMatrix;
    }


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
}

public class Answer
{
    public static void Main(string[] args)
    {
        int[,] matrix;

        if (args.Length == 0)
        {
            // Если аргументы не переданы, используем матрицу по умолчанию
            matrix = new int[,]
            {
                {5, 2},
                {8, 1}
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

        int[,] matrixB = {
            {5, 6},
            {7, 8}
        };

        Console.WriteLine("\nMatrix B:");
        MatrixOperations.PrintMatrix(matrixB);

        Console.WriteLine("\nMultiplication result:");

        MatrixOperations.MultiplyIfPossible(matrix, matrixB);
    }
}
