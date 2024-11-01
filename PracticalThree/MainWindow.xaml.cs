using LibMas;
using System;
using System.Data;
using System.Windows;
using System.Printing;
using static LibMas.VisualArray;

namespace PracticalThree
{
    public partial class MainWindow : Window
    {
        private double[,] matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Выход"
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Обработчик кнопки "О программе"
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Сухомяткина Ксения\nНомер работы: 3\nЗадание: Для каждого столбца матрицы найти произведение его элементов.", "О программе");
        }

        // Обработчик кнопки для заполнения матрицы
        private void FillMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputM.Text, out int m) && int.TryParse(InputN.Text, out int n) && m > 0 && n > 0)
            {
                matrix = new double[m, n];
                Random random = new Random();
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = random.Next(1, 10); // Заполнение случайными числами от 1 до 9
                    }
                }

                // Преобразование в DataTable и вывод, если необходимо
                DataTable dataTable = VisualArray.ToDataTable(matrix);
                MessageBox.Show("Матрица заполнена.", "Уведомление");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите положительные целые числа для M и N.", "Ошибка ввода");
            }
        }

        // Обработчик кнопки для вычисления произведения столбцов
        private void CalculateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                double[] products = MatrixOperations.ProductOfColumns(matrix);
                ResultText.Text = "Произведения столбцов:\n" + string.Join("\n", products);
            }
            else
            {
                MessageBox.Show("Сначала заполните матрицу.", "Ошибка");
            }
        }
    }
}