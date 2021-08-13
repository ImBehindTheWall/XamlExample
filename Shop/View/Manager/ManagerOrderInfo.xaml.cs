using Shop.Core.Entity;
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
using System.Windows.Shapes;

namespace Shop.View.Manager
{
	/// <summary>
	/// Логика взаимодействия для ManagerOrderInfo.xaml
	/// </summary>
	public partial class ManagerOrderInfo : Window
	{
		public ManagerOrderInfo()
		{
			InitializeComponent();
		}

		private void backButton_Click(object sender, RoutedEventArgs e)
		{
			new ManagerMidleWindow().Show();
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (DataContext dataContext = new DataContext())
			{
				OrderInfoDatatGrid.ItemsSource = dataContext.Sale.Select(x => new 
				{
					ИД = x.ID,
					ФИО = x.Client.FirstName+" "+x.Client.LastName,
					Статус = x.Status.Name,
					Оформление = x.DAteCreated,
					Изменение = x.DateUpdate,
					Цена = x.SaleSum
				}).ToList().OrderBy(s => s.ИД);
				StatusBox.ItemsSource = dataContext.Status.Select(x => x.Name).ToList();
				FirstNameBox.ItemsSource = dataContext.Client.Select(client => client.FirstName).ToList();
				LastNameBox.ItemsSource = dataContext.Client.Select(client => client.LastName).ToList();
            }
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			new ManagerOrderAdd().Show();
			this.Close();
		}

		private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
           
            using (DataContext dataContext = new DataContext())
			{
                string space = " ";
                OrderInfoDatatGrid.ItemsSource = dataContext.Sale.Select(x => new
                {
                    ИД = x.ID,
                    ФИО = x.Client.FirstName + " " + x.Client.LastName,
                    Статус = x.Status.Name,
                    Оформление = x.DAteCreated,
                    Изменение = x.DateUpdate,
                    Цена = x.SaleSum
                }).ToList().OrderBy(s => s.ИД).Where(prod => prod.Статус == StatusBox.SelectedItem.ToString());
                FirstNameBox.SelectedItem = " ";
                FirstNameBox.SelectedItem = " ";
            }
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			
		}

        private void FirstNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                
                LastNameBox.SelectedItem = dataContext.Client.FirstOrDefault(client => client.FirstName.Equals(FirstNameBox.SelectedItem.ToString())).LastName;
                string fio = "";
                fio = FirstNameBox.SelectedItem.ToString() + " " + LastNameBox.SelectedItem.ToString();
                OrderInfoDatatGrid.ItemsSource = dataContext.Sale.Select(x => new
                {
                    ИД = x.ID,
                    ФИО = x.Client.FirstName + " " + x.Client.LastName,
                    Статус = x.Status.Name,
                    Оформление = x.DAteCreated,
                    Изменение = x.DateUpdate,
                    Цена = x.SaleSum
                }).ToList().OrderBy(x => x.ИД).Where(prod => prod.ФИО.Equals(fio));
            }
        }

        private void LastNameBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                FirstNameBox.SelectedItem = dataContext.Client.FirstOrDefault(client => client.LastName.Equals(LastNameBox.SelectedItem.ToString())).FirstName;
                string fio = "";
                fio = FirstNameBox.SelectedItem.ToString() + " " + LastNameBox.SelectedItem.ToString();
                OrderInfoDatatGrid.ItemsSource = dataContext.Sale.Select(x => new
                {
                    ИД = x.ID,
                    ФИО = x.Client.FirstName + " " + x.Client.LastName,
                    Статус = x.Status.Name,
                    Оформление = x.DAteCreated,
                    Изменение = x.DateUpdate,
                    Цена = x.SaleSum
                }).ToList().OrderBy(x => x.ИД).Where(prod => prod.ФИО.Equals(fio));
            }

            
        }
    }
}
