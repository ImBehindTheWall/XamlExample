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
	/// Логика взаимодействия для ManagerMidleWindow.xaml
	/// </summary>
	public partial class ManagerMidleWindow : Window
	{
		public ManagerMidleWindow()
		{
			InitializeComponent();
		}

		private void RegCkientButton_Click(object sender, RoutedEventArgs e)
		{
			new View.ClientRegistrationWindow().Show();
			this.Close();
		}

		private void OrderInfo_Click(object sender, RoutedEventArgs e)
		{
			new ManagerCategoryWindow().Show();
			this.Close();
		}

		private void OrderHistoryButton_Click(object sender, RoutedEventArgs e)
		{
			new Manager.ManagerOrderInfo().Show();
			this.Close();
		}
	}
}
