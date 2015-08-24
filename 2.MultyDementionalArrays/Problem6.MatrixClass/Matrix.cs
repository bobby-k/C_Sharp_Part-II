using System;
using System.Text;

namespace Problem6.MatrixClass
{
    class Matrix
    {
        // поле - променлива за класа
        private int[,] matrix;

        // конструктор, задава начално състояние на нашето поле(променлива int[,] matrix; )
        public Matrix(int rows, int cols)
        {
            this.matrix = new int[rows, cols];
        }

        // пропърти - свойство за полето, т.е. променливата
        public int Rows
        {
            // метод на пропъртито който е read-only 
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        // пропърти - свойство за полето, т.е. променливата
        public int Cols
        {
            // метод на пропъртито който е read-only
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        // индексатори за ред и колона
        public int this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        // override operators +, -, *
        public static Matrix operator +(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first.Rows, first.Cols);

            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = first[row, col] + second[row, col];
                }
            }

            return result;
        }
        public static Matrix operator -(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first.Rows, first.Cols);

            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = first[row, col] - second[row, col];
                }
            }

            return result;
        }
        public static Matrix operator *(Matrix first, Matrix second)
        {
            Matrix result = new Matrix(first.Rows, second.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    int product = 0;

                    for (int i = 0; i < first.Cols; i++)
                    {
                        product += first[row, i] * second[i, col];
                    }

                    result[row, col] = product;
                }
            }
            
            return result;
        }

        public override string ToString()
        {
            string result = "";

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result += matrix[row, col] + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}
