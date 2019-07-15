using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Lab7_Jadina
{
    public partial class Form1 : Form
    {
        List<int> Out = new List<int>();//Выдача 
        List<int> coins = new List<int>();//Стоимость каждой монеты
        public Form1() => InitializeComponent();
        private void Add_Click(object sender, EventArgs e)
        {// Добавление новых монет
            if (!int.TryParse(textBox1.Text, out rubl)) return;
            if (!(rubl > 0) || coins.Contains(rubl)) return;
            coins.Add(rubl); textBox1.Text = "";
            listBox1.Items.Add(rubl);
        }

        void Jadina_Start()
        {// Рекурсивная реализация Jадного алгоритма
            if (rubl > 0)//Пока есть что менять
            {
                foreach (int coin in coins)// Проблемное место( дополнительная задержка на перебор )
                    if (rubl - coin >= 0)
                    {
                        rubl -= coin;
                        Jadina_Start();
                        Out.Add(coin);
                        break;
                    }
            }
        }
        int rubl = 0;//Сумма которую нужно разменять
        void Counting_Click(object sender, EventArgs e)
        {// Расчёт оптимальной выдачи жадным алгоритмом
            if (!int.TryParse(textBox2.Text, out rubl)) return;//Парсим сумму
            if (coins.Count == 0) return;
            listBox2.Items.Clear(); Out.Clear();
            coins.Sort(); coins.Reverse();//Сортируем по убыванию + разворачиваем список

            Jadina_Start();//Запускаем Jадный алгоритм

            Out.Sort(); Out.Reverse();//Сортируем по убыванию + разворачиваем список

            Dictionary<int, int> times = new Dictionary<int, int>();//Для 
            foreach (int coin in Out)
            {// Считаем сколько одинаковых монет
                if (!times.ContainsKey(coin)) times.Add(coin, 1);
                else
                {
                    times.TryGetValue(coin, out int n);
                    times.Remove(coin);
                    times.Add(coin, n + 1);
                }
            }

            foreach (var p in times)//Выводим выдачу
                listBox2.Items.Add(p.Key + "*" + p.Value);
            if (rubl > 0) listBox2.Items.Add("Осталось: " + rubl);
        }

        private void Clear_Click(object sender, EventArgs e)
        { textBox1.Text = ""; coins.Clear(); listBox1.Items.Clear(); listBox2.Items.Clear(); Out.Clear(); listBox1.Items.Add("Монеты"); }
    }
}