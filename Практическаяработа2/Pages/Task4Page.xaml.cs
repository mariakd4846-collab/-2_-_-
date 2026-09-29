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
    /// Логика взаимодействия для Task4Page.xaml
    /// </summary>
    public partial class Task4Page : Page
    {
        private int[] array;
        public Task4Page()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            txtArray.Clear();

            if (!int.TryParse(txtN.Text, out int N))
            {
                txtResult.Text = "Ошибка: размер массива должен быть числом!";
                return;
            }

            // Для обращения к A[10] должно быть минимум 10 элементов
            if (N < 10)
            {
                txtResult.Text = "Ошибка: N должно быть не меньше 10!";
                return;
            }

            Random random = new Random();

            array = new int[N];

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(-20, 21);
            }

            ShowArray();

            txtResult.Text = "Массив сгенерирован.";
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";

            if (array == null)
            {
                txtResult.Text = "Ошибка: сначала сгенерируйте массив!";
                return;
            }

            int result = FindElement();

            if (result == 0)
            {
                txtResult.Text = "Таких элементов нет. Результат: 0";
            }
            else
            {
                txtResult.Text =
                    $"Первый подходящий элемент имеет номер: {result}";
            }
        }

        private int FindElement()
        {
            // A[1] в условии — первый элемент массива.
            // A[10] — десятый элемент массива.
            int first = array[0];
            int tenth = array[9];

            // Начинаем с первого элемента.
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > first && array[i] < tenth)
                {
                    // Возвращаем номер элемента,
                    // а не индекс.
                    return i + 1;
                }
            }

            return 0;
        }

        private void ShowArray()
        {
            txtArray.Text = "";

            for (int i = 0; i < array.Length; i++)
            {
                txtArray.Text += array[i];

                if (i < array.Length - 1)
                {
                    txtArray.Text += "  ";
                }
            }
        }
    }

}

