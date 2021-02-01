using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesManager
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void readButton_Click(object sender, EventArgs e)
        {
            //resultTextBox.Text = string.Join("", ReadFile());
            var result = ListOfExpenses()
                .OrderBy(x => x.Date)
                .Select(x => $"{x.Date.ToString("yyyy/MM/dd")} | {x.Price} | {x.Category}");

            resultTextBox.Text = string.Join("\r\n", result);

        }


        private IEnumerable<string> ReadFile()
        {
            var path = pathTextBox.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist. Cannot proceed");
                return null;
            }

            var lines = File.ReadAllLines(path).Skip(1);
            return lines;
        }

        private List<Expense> ListOfExpenses()
        {
            var lines = ReadFile();

            var expenses = new List<Expense>();
            foreach (var line in lines)
            {
                var split = line.Split('|');
                var date = DateTime.ParseExact(split[0], "yyyy-MM-dd", null);
                var price = Convert.ToDecimal(split[1].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                var category = split[2];



                var expense = new Expense(date, price, category);
                expenses.Add(expense);
            }
            return expenses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = ListOfExpenses();
            var numbOfCateg = result
                .GroupBy(x => x.Category)
                .Count();
            var totalExpenses = result
                .Sum(x => x.Price);

            resultTextBox.Text = $"Number of categories: {numbOfCateg}, total expenses: {totalExpenses}";

            
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void resultTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Expense
    {
        public DateTime Date { get; }
        public decimal Price { get; }
        public string Category { get; }

        public Expense(DateTime date, decimal price, string categ)
        {
            Date = date;
            Price = price;
            Category = categ;
        }
    }
}