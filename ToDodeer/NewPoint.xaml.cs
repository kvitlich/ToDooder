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

namespace ToDodeer
{
    /// <summary>
    /// Interaction logic for NewPoint.xaml
    /// </summary>
    public partial class NewPoint : Page
    {
        public NewPoint()
        {
            InitializeComponent();
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            string name = pointName.Text;
            if (name.StartsWith(" ") && name.EndsWith(" "))
            {
                MessageBox.Show("Название не может начинаться с пробелов!");
            }
            else
            {
                Point newPoint = new Point
                {
                    Name = name,
                    Content = new NoticeDomain.Content
                    {
                        Text = "Hello, world!"
                    }
                };
                NoticesExplorer.notices.Notices.Where(x=>x.Name.Equals(NoticesExplorer.selectedNotice.Name)).FirstOrDefault().Points.Add(newPoint);
                await NoticesExplorer.SaveNotesToJson();
            }
        }
    }
}
