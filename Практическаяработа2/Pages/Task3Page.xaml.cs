using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическаяработа2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Task3Page.xaml
    /// </summary>
    public partial class Task3Page : Page
    {
        private int[,] array;
        public Task3Page()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";

            // Проверяем количество столбцов
            if (!int.TryParse(txtM.Text, out int M))
            {
                txtResult.Text = "Ошибка: M должно быть числом!";
                return;
            }

            // Проверяем количество строк
            if (!int.TryParse(txtN.Text, out int N))
            {
                txtResult.Text = "Ошибка: N должно быть числом!";
                return;
            }

            // Проверяем размеры
            if (M <= 0 || N <= 0)
            {
                txtResult.Text = "Ошибка: M и N должны быть больше 0!";
                return;
            }

            // Ограничим размер, чтобы таблица нормально помещалась
            if (M > 10 || N > 10)
            {
                txtResult.Text = "Ошибка: максимальный размер массива 10 × 10!";
                return;
            }

            // Создаем массив
            array = new int[N, M];

            Random random = new Random();

            // Заполняем массив числами от -10 до 10
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            // Показываем исходный массив
            ShowArray(dgOriginal, array);

            // Создаем список всех элементов
            List<int> elements = new List<int>();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    elements.Add(array[i, j]);
                }
            }

            // Сортировка по возрастанию
            elements.Sort();

            int[,] ascending = CreateArrayFromList(elements, N, M);

            ShowArray(dgAscending, ascending);

            // Сортировка по убыванию
            elements.Reverse();

            int[,] descending = CreateArrayFromList(elements, N, M);

            ShowArray(dgDescending, descending);

            // Поиск минимального и максимального элементов
            int min = array[0, 0];
            int max = array[0, 0];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }

            txtResult.Text = $"Минимальный элемент: {min}     Максимальный элемент: {max}";
        }

        // Преобразование списка обратно в двумерный массив
        private int[,] CreateArrayFromList(List<int> elements, int N, int M)
        {
            int[,] result = new int[N, M];

            int index = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result[i, j] = elements[index];
                    index++;
                }
            }

            return result;
        }

        // Вывод двумерного массива в DataGrid
        private void ShowArray(DataGrid grid, int[,] data)
        {
            grid.Columns.Clear();

            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            // Создаем столбцы
            for (int j = 0; j < columns; j++)
            {
                DataGridTextColumn column = new DataGridTextColumn();

                column.Header = "Столбец " + (j + 1);
                column.Binding = new System.Windows.Data.Binding($"Values[{j}]");

                grid.Columns.Add(column);
            }

            // Создаем строки
            List<ArrayRow> table = new List<ArrayRow>();

            for (int i = 0; i < rows; i++)
            {
                ArrayRow row = new ArrayRow();

                for (int j = 0; j < columns; j++)
                {
                    row.Values.Add(data[i, j]);
                }

                table.Add(row);
            }

            grid.ItemsSource = table;
        }
    }

    // Одна строка таблицы
    public class ArrayRow
    {
        public List<int> Values { get; set; }

        public ArrayRow()
        {
            Values = new List<int>();
        }
    }
}
