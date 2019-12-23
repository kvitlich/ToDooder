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
    /// Interaction logic for NewNotice.xaml
    /// </summary>
    public partial class NewNotice : Page
    {
        public NewNotice()
        {
            InitializeComponent();
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            string name = noteName.Text;
            if (name.StartsWith(" ") && name.EndsWith(" "))
            {
                MessageBox.Show("Название не может начинаться с пробелов!");
            }
            else 
            {
                Notice newNotice = new Notice
                {
                    Name = name,
                };
                NoticesExplorer.notices.Notices.Add(newNotice);
                await NoticesExplorer.SaveNotesToJson(); 
            }
        }
    }
}
