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
    /// Логика взаимодействия для Task1Page.xaml
    /// </summary>
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            txtInput.Text = rnd.Next(100000, 999999).ToString();
            txtResult.Clear();
            txtError.Text = string.Empty;
        }
        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            txtError.Text = string.Empty;
            txtResult.Clear();

            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                txtError.Text = "Ошибка: введите число!";
                return;
            }

            if (!long.TryParse(txtInput.Text, out long number))
            {
                txtError.Text = "Ошибка: введено не целое число!";
                return;
            }

            string result = FindRepeatedDigits(number);

            if (string.IsNullOrEmpty(result))
                txtResult.Text = "Нет цифр, повторяющихся более одного раза";
            else
                txtResult.Text = result;
        }
        private string FindRepeatedDigits(long number)
        {

            int[] digitCounts = new int[10];

            long absNumber = Math.Abs(number);

            if (absNumber == 0)
                return string.Empty;


            while (absNumber > 0)
            {
                int digit = (int)(absNumber % 10);
                digitCounts[digit]++;
                absNumber /= 10;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                if (digitCounts[i] > 1)
                {
                    if (sb.Length > 0)
                        sb.Append(", ");
                    sb.Append($"цифра {i} (встречается {digitCounts[i]} раз)");
                }
            }

            return sb.ToString();
        }
    }
}
