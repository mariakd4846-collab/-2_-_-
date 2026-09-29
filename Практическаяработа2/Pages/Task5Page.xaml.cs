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
    /// Логика взаимодействия для Task5Page.xaml
    /// </summary>
    public partial class Task5Page : Page
    {
        private int[] array;

        public Task5Page()
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

            if (N <= 0)
            {
                txtResult.Text = "Ошибка: N должно быть больше 0!";
                return;
            }

            Random random = new Random();

            array = new int[N];

            // Генерируем положительные числа,
            // чтобы в массиве могли встречаться простые
            // и совершенные числа.
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(1, 100);
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

            int primeIndex = -1;
            int perfectIndex = -1;

            // Ищем первое простое число
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                {
                    primeIndex = i;
                    break;
                }
            }

            // Ищем первое совершенное число
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPerfect(array[i]))
                {
                    perfectIndex = i;
                    break;
                }
            }

            // Проверяем, нашли ли оба числа
            if (primeIndex == -1 && perfectIndex == -1)
            {
                txtResult.Text =
                    "В массиве нет простого и совершенного числа.";
                return;
            }

            if (primeIndex == -1)
            {
                txtResult.Text =
                    "В массиве не найдено простое число.";
                return;
            }

            if (perfectIndex == -1)
            {
                txtResult.Text =
                    "В массиве не найдено совершенное число.";
                return;
            }

            // Запоминаем значения
            int prime = array[primeIndex];
            int perfect = array[perfectIndex];

            // Меняем местами
            array[primeIndex] = perfect;
            array[perfectIndex] = prime;

            ShowArray();

            txtResult.Text =
                $"Поменяны местами первое простое число {prime} " +
                $"и первое совершенное число {perfect}.";
        }

        // Проверка на простое число
        private bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Проверка на совершенное число
        private bool IsPerfect(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum == number;
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
