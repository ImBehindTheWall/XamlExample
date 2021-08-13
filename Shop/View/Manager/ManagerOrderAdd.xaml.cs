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
	/// Логика взаимодействия для ManagerOrderAdd.xaml
	/// </summary>
	public partial class ManagerOrderAdd : Window
	{
		public ManagerOrderAdd()
		{
			InitializeComponent();
		}

		private void BcakButton_Click(object sender, RoutedEventArgs e)
		{
			new ManagerOrderInfo().Show();
			this.Close();
		}

		private void AcceptButton_Click(object sender, RoutedEventArgs e)
		{
			var fio = FIOBox.Text.Split(' ');
			string firstname = fio[0];
			string lastName = fio[1];
			using (DataContext dataContext = new DataContext())
			{
				dataContext.Sale.Add(new Sale
				{
					ClientID = dataContext
				.Client
				.FirstOrDefault(client => client.FirstName
				.Equals(firstname) & client.LastName.Equals(lastName)).ID,
					StatusID = 1,
					DAteCreated = DateTime.Now,
					DateUpdate = DateTime.Now,
					SaleSum = Convert.ToDecimal(SumBox.Text)

				}) ;
				dataContext.SaveChanges();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (DataContext dataContext = new DataContext())
			{
				FIOBox.ItemsSource = dataContext.Client.Select(x => x.FirstName + " " + x.LastName).ToList();
			}
		}
	}
}
