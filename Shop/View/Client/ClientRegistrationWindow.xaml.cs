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

namespace Shop.View
{
	/// <summary>
	/// Логика взаимодействия для ClientRegistrationWindow.xaml
	/// </summary>
	public partial class ClientRegistrationWindow : Window
	{
		public ClientRegistrationWindow()
		{
			InitializeComponent();
		}

		private void AcceptButton_Click(object sender, RoutedEventArgs e)
		{
			using (DataContext dataContext = new DataContext())
			{
				dataContext.Client.Add(new Client
				{
					FirstName = FirstNameBOx.Text,
					LastName = LastNameBOx.Text,
					SourceID = dataContext.Source.FirstOrDefault(sours => sours.Name == SourceBox.Text).ID
				}) ;
				dataContext.SaveChanges();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (DataContext dataContext = new DataContext())
			{
				SourceBox.ItemsSource = dataContext.Source.Select(s => s.Name).ToList();
			}
		}
	}
}
