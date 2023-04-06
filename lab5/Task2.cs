using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace lab5
{
    internal class Task2
    {
        public static void Run()
        {
            Matrix matrix1 = new Matrix(), matrix2 = new Matrix(), result_matrix = null;
            Console.WriteLine("Initiate first matrix:");
            matrix1.Init();
            Console.WriteLine("Initiate second matrix:");
            matrix2.Init();
            string action, choice;
            int number;
            do
            {
                Console.Write("Enter what to do(show, add, substract, multiply_matrixes, multiply_number, compare, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "add":
                        result_matrix = matrix1 + matrix2;
                        if (!result_matrix.Exists()) 
                        {
                            Console.WriteLine("Such matrixes can't be added");
                            break;
                        }
                        Console.WriteLine("Result matrix:");
                        result_matrix.Show();
                        break;

                    case "substract":
                        result_matrix = matrix1 - matrix2;
                        if (!result_matrix.Exists())
                        {
                            Console.WriteLine("Such matrixes can't be substracted");
                            break;
                        }
                        Console.WriteLine("Result matrix:");
                        result_matrix.Show();
                        break;

                    case "multiply_matrixes":
                        Console.WriteLine("Result matrix:");
                        result_matrix = matrix1 * matrix2;
                        if (!result_matrix.Exists())
                        {
                            Console.WriteLine("Such matrixes can't be multiplied");
                            break;
                        }
                        Console.WriteLine("Result matrix:");
                        result_matrix.Show();
                        break;

                    case "multiply_number":
                        Console.Write("Enter which matrix to multiply(first, second): ");
                        choice = Console.ReadLine();
                        Console.Write("Enter number to multiply on: ");
                        int.TryParse(Console.ReadLine(), out number);
                        if (choice == "first")
                            result_matrix = matrix1 * number;
                        else if (choice == "second")
                            result_matrix = matrix2 * number;
                        Console.WriteLine("Result matrix:");
                        result_matrix.Show();
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch (compare)
                        {
                            case "==":
                                Console.WriteLine($"Result(matrix1 == matrix2): {matrix1 == matrix2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(matrix1 != matrix2): {matrix1 != matrix2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(matrix1.Equals(matrix2)): {matrix1.Equals(matrix2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("Matrix1:");
                        matrix1.Show();
                        Console.WriteLine("Matrix2:");
                        matrix2.Show();
                        break;
                }

            } while (action != "exit");
        }
    }

    class Matrix
    {
        private int[,] _matr { get; set; }

        public Matrix()
        {
            this._matr = new int[0, 0];
        }
        public Matrix(int[,] matr)
        {
            this._matr = new int[matr.GetUpperBound(0) + 1, matr.GetUpperBound(1) + 1];
            for (int i = 0; i <= matr.GetUpperBound(0); i++)
                for (int j = 0; j <= matr.GetUpperBound(1); j++)
                    this._matr[i, j] = matr[i, j];
        }

        public void Init()
        {
            Console.Write("Enter sizes of matrix: ");
            string[] idx = Console.ReadLine().Split(' ');
            int[] sizes = new int[2];
            try
            {
                for (int i = 0; i < idx.Length && i < 2; i++)
                {
                    sizes[i] = int.Parse(idx[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error collapsed: {ex.Message}");
                return;
            }
            this._matr = new int[sizes[0], sizes[1]];
            Console.WriteLine("Enter matrix:");
            string[] row;
            for (int i = 0; i < sizes[0]; i++)
            {
                row = Console.ReadLine().Split(' ');
                for (int j = 0; j < sizes[1] && j < row.Length; j++)
                {
                    int.TryParse(row[j], out this._matr[i, j]);
                }
            }
        }

        public bool Exists()
        {
            return this._matr.GetUpperBound(0)!=-1 && this._matr.GetUpperBound(0) != -1;
        }

        public void EditElement()
        {
            Console.Write("Enter indexes of element to change: ");
            string[] idx = Console.ReadLine().Split(' ');
            int[] indexes = new int[2];
            try
            {
                for (int i = 0; i < idx.Length && i < 2; i++)
                {
                    indexes[i] = int.Parse(idx[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error collapsed: {ex.Message}");
                return;
            }
            if (indexes[0] <= this._matr.GetUpperBound(0) && indexes[1] <= this._matr.GetUpperBound(1))
            {
                int val;
                Console.Write("Enter new value: ");
                try
                {
                    val = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error collapsed: {ex.Message}");
                    return;
                }
                this._matr[indexes[0], indexes[1]] = val;
            }
        }

        public void Show()
        {
            Console.WriteLine("---------------------------------");
            for (int i = 0; i <= this._matr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= this._matr.GetUpperBound(1); j++)
                    Console.Write($"{this._matr[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------");
        }

        public int[,] GetMatrix()
        {
            return this._matr;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            int[,] matr1 = matrix1.GetMatrix(), matr2 = matrix2.GetMatrix();
            if (matr1.GetUpperBound(0) != matr2.GetUpperBound(0) || matr1.GetUpperBound(1) != matr2.GetUpperBound(1))
                return new Matrix();
            int[,] result = new int[matr1.GetUpperBound(0) + 1, matr2.GetUpperBound(0) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    result[i, j] = matr1[i, j] + matr2[i, j];
            }
            return new Matrix(result);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            int[,] matr1 = matrix1.GetMatrix(), matr2 = matrix2.GetMatrix();
            if (matr1.GetUpperBound(0) != matr2.GetUpperBound(0) || matr1.GetUpperBound(1) != matr2.GetUpperBound(1))
                return new Matrix();
            int[,] result = new int[matr1.GetUpperBound(0) + 1, matr2.GetUpperBound(0) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    result[i, j] = matr1[i, j] - matr2[i, j];
            }
            return new Matrix(result);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            int[,] matr1 = matrix1.GetMatrix(), matr2 = matrix2.GetMatrix();
            if (matr1.GetUpperBound(1) != matr2.GetUpperBound(0))
                return new Matrix();
            int[,] result = new int[matr1.GetUpperBound(0) + 1, matr2.GetUpperBound(1) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    for (int k = 0; k <= matr1.GetUpperBound(1); k++)
                        result[i, j] += matr1[i, k] * matr2[k, j];
            }
            return new Matrix(result);
        }

        public static Matrix operator *(int num, Matrix matrix)
        {
            int[,] matr = matrix.GetMatrix();
            int[,] result = new int[matr.GetUpperBound(0) + 1, matr.GetUpperBound(1) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    result[i, j] = matr[i, j] * num;
            }
            return new Matrix(result);
        }
        public static Matrix operator *(Matrix matrix, int num)
        {
            int[,] matr = matrix.GetMatrix();
            int[,] result = new int[matr.GetUpperBound(0) + 1, matr.GetUpperBound(1) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    result[i, j] = matr[i, j] * num;
            }
            return new Matrix(result);
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            int[,] matr1 = matrix1.GetMatrix(), matr2 = matrix2.GetMatrix();
            if (matr1.GetUpperBound(0) != matr2.GetUpperBound(0) || matr1.GetUpperBound(1) != matr2.GetUpperBound(1))
                return false;
            int[,] result = new int[matr1.GetUpperBound(0) + 1, matr2.GetUpperBound(0) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    if (matr1[i, j] != matr2[i, j])
                        return false;
            }
            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            int[,] matr1 = matrix1.GetMatrix(), matr2 = matrix2.GetMatrix();
            if (matr1.GetUpperBound(0) != matr2.GetUpperBound(0) || matr1.GetUpperBound(1) != matr2.GetUpperBound(1))
                return true;
            int[,] result = new int[matr1.GetUpperBound(0) + 1, matr2.GetUpperBound(0) + 1];
            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                    if (matr1[i, j] != matr2[i, j])
                        return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj.GetType().Equals(GetType())))
                return false;
            return this == (Matrix)obj;
        }
    }
}
