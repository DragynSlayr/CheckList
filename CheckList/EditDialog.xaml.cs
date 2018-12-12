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

namespace CheckList {
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window {

        private string startString;
        private Brush startBrush;

        public EditDialog() {
            InitializeComponent();

            startString = TaskBox.Text.ToString();
            startBrush = TaskBox.Foreground;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                DragMove();
            }
        }

        private void TaskBox_GotFocus(object sender, RoutedEventArgs e) {
            if (TaskBox.Text.Equals(startString)) {
                TaskBox.Text = "";
                TaskBox.Foreground = Brushes.Black;
            }
        }

        private void TaskBox_LostFocus(object sender, RoutedEventArgs e) {
            if (TaskBox.Text.Equals("")) {
                TaskBox.Text = startString;
                TaskBox.Foreground = startBrush;
            }
        }
    }
}
