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
	/// Логика взаимодействия для ManagerCategoryWindow.xaml
	/// </summary>
	public partial class ManagerCategoryWindow : Window
	{
		public ManagerCategoryWindow()
		{
			InitializeComponent();
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			new Manager.ManagerMidleWindow().Show();
			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (DataContext dataContext = new DataContext())
			{
				CategoryDataGrid.ItemsSource = dataContext.Category.Select(x=>new
				{
					ИД_категории = x.ID,
					Категория = x.Name
				}).ToList();
			}
		}
	}
}
