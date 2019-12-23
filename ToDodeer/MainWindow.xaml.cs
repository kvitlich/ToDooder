using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using ToDodeer.NoticeDomain;

namespace ToDodeer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitInfo();
        }

        public async void InitInfo()
        {
            NoticesExplorer.notices = await NoticesExplorer.GetNotesFromJson();
            noticesDataGrid.ItemsSource = NoticesExplorer.notices.Notices;
        }

        private void CreateNote(object sender, RoutedEventArgs e)
        {
            mainFrame.Visibility = Visibility.Visible;
            mainFrame.Navigate(new Uri("NewNotice.xaml", UriKind.Relative));
            InitInfo();
        }

        private void CreatePoint(object sender, RoutedEventArgs e)
        {
            mainFrame.Visibility = Visibility.Visible;
            mainFrame.Navigate(new Uri("NewPoint.xaml", UriKind.Relative));
            InitInfo();
        }

        private void SaveContent(object sender, RoutedEventArgs e)
        {
            ((Point)pointsDataGrid.SelectedItem).Content.Text = contentTextBox.Text;
            NoticesExplorer.notices.Notices = noticesDataGrid.ItemsSource as List<Notice>;
            NoticesExplorer.SaveNotesToJson();
        }

        private void NoticeChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (noticesDataGrid.SelectedItem != null)
            {
                pointsDataGrid.ItemsSource = null;
                pointsDataGrid.ItemsSource = ((Notice)noticesDataGrid.SelectedItem).Points;
                NoticesExplorer.selectedNotice = (Notice)noticesDataGrid.SelectedItem;
                pointsDataGrid.Visibility = Visibility.Visible;
            }
        }

        private void PointChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (pointsDataGrid.SelectedItem != null)
            {
                contentTextBox.Text = ((Point)pointsDataGrid.SelectedItem).Content.Text;
                contentTextBox.Visibility = Visibility.Visible;
                saveButton.Visibility = Visibility.Visible;
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            InitInfo();

        }
    }
}
