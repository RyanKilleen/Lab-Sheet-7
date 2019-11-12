using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab_Sheet_7
{/// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Expense> expenses;
        Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create 3 expense objects
            Expense e1 = new Expense() { Category = "Travel", Amount = 19.95m, ExpenseDate = new DateTime(2019, 6, 30) };

            Expense e2 = new Expense()
            {
                Category = "Entertainment",
                Amount = 99.95m,
                ExpenseDate = new DateTime(2019, 7, 30)
            };

            Expense e3 = new Expense()
            {
                Category = "Office",
                Amount = 9.95m,
                ExpenseDate = new DateTime(2019, 6, 25)
            };

            //Add those to a list
            expenses = new ObservableCollection<Expense>(); // new list assigned on window load
            expenses.Add(e1);
            expenses.Add(e2);
            expenses.Add(e3);

            //Display list in listbox
            lbx_Expenses.ItemsSource = expenses;

            tblk_Total.Text = Expense.TotalExpenses.ToString();
        }

        //Methood to add expense
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //create an expense
            Expense e1 = new Expense()
            {
                Category = "Travel",
                Amount = 55.45m,
                ExpenseDate = DateTime.Now


            };

            expenses.Add(e1);

            //refresh screen
            lbx_Expenses.ItemSource = null;
            lbx_Expenses.ItemsSource = expenses;

            //Add that to the List
            expenses.Add(GetRandomExpense());
            tblk_Total.Text = Expense.TotalExpenses.ToString();
        }




        private Expense GetRandomExpense()
        {
            //get random category
            string[] categories = { "Office", "Travel", "Entertainment" };
            int randomNumber = rng.Next(0, 3); //0, 1 or 2
            string category = categories[randomNumber];

            //get random amount
            randomNumber = rng.Next(1, 10001);
            decimal randomAmount = (decimal)randomNumber / 100;

            //get random date - in the last 30 days
            randomNumber = rng.Next(0, 31); //0 .. 30
            DateTime randomDate = DateTime.Now.AddDays(-randomNumber);


            //create an expense object with random info
            Expense e1 = new Expense(randomAmount, randomDate, category);

            //return random object
            return e1;
        }
    }

}

