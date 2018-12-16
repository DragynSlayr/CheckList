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

namespace CheckList {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public bool EditResult;
        public string EditString;
        public DateTime EditDate;

        public MainWindow() {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) {
            EditDialog d = new EditDialog(this);
            d.Owner = this;
            d.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            d.ShowDialog();
            if (EditResult) {
                Items.Children.Add(new ListItem(this, EditString, EditDate));
                List<ListItem> items = new List<ListItem>();
                foreach (UIElement ui in Items.Children) {
                    ListItem l = ui as ListItem;
                    if (l != null) {
                        items.Add(l);
                    }
                }
                items.Sort(ListItem.CompareListItem);
                Items.Children.Clear();
                foreach (ListItem l in items) {
                    Items.Children.Add(l);
                }
            }
        }

        private void MinButton_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                DragMove();
            }
        }
    }
}
