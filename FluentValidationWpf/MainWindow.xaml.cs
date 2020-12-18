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
using FluentValidationWpf.Validators;
using OrdersLibrary;

namespace FluentValidationWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order();
            decimal price;
            decimal.TryParse(PriceTextBox.Text, result: out price);
            
            order.Date = DatePicker.SelectedDate ?? DateTime.Now;
            order.Price = price;
            order.Description = DescriptionTextBox.Text;

            var validator = new OrderValidator();
            var result = validator.Validate(order);

            if (result.IsValid)
            {
                //Save to database
                MessageBox.Show("Order added to database");
                return;
            }

            foreach (var error in result.Errors)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
