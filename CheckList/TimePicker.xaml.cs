using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl {

        private bool isPM;
        public int TimeHour, TimeMinute;

        public TimePicker() {
            InitializeComponent();

            isPM = true;
        }

        public string GetTime() {
            string h = Hour.Text.ToString();
            string m = Minute.Text.ToString();
            if (m.Length != 2) {
                m = "0" + m;
            }
            TimeHour = int.Parse(h) % 12;
            if (isPM) {
                TimeHour += 12;
            }
            TimeMinute = int.Parse(m);
            return (h + ":" + m + (isPM ? "PM" : "AM"));
        }

        private void PMBox_Checked(object sender, RoutedEventArgs e) {
            isPM = true;
        }

        private void AMBox_Checked(object sender, RoutedEventArgs e) {
            isPM = false;
        }

        private void Time_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            Regex r = new Regex("[^0-9]+");
            e.Handled = r.IsMatch(e.Text);
        }

        private void Time_GotFocus(Object sender, RoutedEventArgs e) {
            TextBox t = sender as TextBox;
            t.Text = "";
        }

        private void Time_LostFocus(object sender, RoutedEventArgs e) {
            TextBox t = sender as TextBox;
            if (t.Text.Equals("")) {
                t.Text = t.Name.Equals("Hour") ? "12" : "00";
            }
        }
    }
}
