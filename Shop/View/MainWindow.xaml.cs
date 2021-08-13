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

namespace Shop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (LoginBox.Text == "" || PasswordBox.Text == "")
				{
					throw new Exception("не все поля заполнены");
				}
				else if (LoginBox.Text == "manager" && PasswordBox.Text == "manager")
				{
					new View.Manager.ManagerMidleWindow().Show();
					this.Close();
				}
				else
				{
					throw new Exception("нет такого пользователя");
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
