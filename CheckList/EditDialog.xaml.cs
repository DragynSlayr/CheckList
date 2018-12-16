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
        private MainWindow window;
        private static string[] MONTHS = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public EditDialog(MainWindow Window) {
            InitializeComponent();

            window = Window;
            startString = TaskBox.Text.ToString();
            startBrush = TaskBox.Foreground;
            Date.SelectedDate = DateTime.Today;
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

        private void DenyButton_Click(object sender, RoutedEventArgs e) {
            window.EditResult = false;
            Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
            string s = TaskBox.Text + " by " + TimePicker.GetTime() + " on ";
            DateTime? d = Date.SelectedDate;
            DateTime date = d ?? DateTime.Today;
            s += MONTHS[date.Month - 1] + " " + date.Day + ", " + date.Year;

            window.EditString = s;
            window.EditResult = true;
            window.EditDate = new DateTime(date.Year, date.Month, date.Day, TimePicker.TimeHour, TimePicker.TimeMinute, 0);
            Close();
        }
    }
}
