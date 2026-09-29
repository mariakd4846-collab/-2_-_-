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
    /// Логика взаимодействия для Task2Page.xaml
    /// </summary>
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Пример предложения для проверки программы
            txtInput.Text = "Я изучаю программирование в колледже";

            txtResult.Clear();
            txtError.Text = string.Empty;
        }
        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            txtError.Text = string.Empty;
            txtResult.Clear();

            // Проверяем, что пользователь ввел предложение
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                txtError.Text = "Ошибка: введите предложение!";
                return;
            }

            string sentence = txtInput.Text;

            string result = FindLongestWord(sentence);

            if (string.IsNullOrEmpty(result))
            {
                txtError.Text = "Ошибка: в предложении нет слов!";
            }
            else
            {
                txtResult.Text = result;
            }
        }

        private string FindLongestWord(string sentence)
        {
            // Убираем основные знаки препинания
            char[] punctuation =
            {
                '.', ',', '!', '?',
                ':', ';', '(', ')',
                '"', '-'
            };

            foreach (char symbol in punctuation)
            {
                sentence = sentence.Replace(symbol.ToString(), "");
            }

            // Разделяем предложение на слова
            string[] words = sentence.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                return string.Empty;
            }

            // Первое слово считаем самым длинным
            string longestWord = words[0];

            // Проверяем остальные слова
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }

            return longestWord;
        }
    }
}
