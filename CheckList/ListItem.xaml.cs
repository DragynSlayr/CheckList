﻿using System;
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
    /// Interaction logic for ListItem.xaml
    /// </summary>
    [Serializable]
    public partial class ListItem : UserControl {

        private MainWindow window;
        private Brush normal, finished;
        public DateTime date;

        public ListItem(MainWindow Window, string Text, DateTime Date) {
            InitializeComponent();

            window = Window;
            date = Date;
            Task.Text = Text;
            normal = BG.Fill;
            finished = new SolidColorBrush(Color.FromRgb(75, 75, 75));
        }

        private void TickBox_Checked(object sender, RoutedEventArgs e) {
            window.Items.Children.Remove(this);
            window.Finished.Children.Add(this);
            BG.Fill = finished;
        }

        private void TickBox_Unchecked(object sender, RoutedEventArgs e) {
            window.Finished.Children.Remove(this);
            window.Items.Children.Add(this);
            BG.Fill = normal;
        }

        public static int CompareListItem(ListItem li1, ListItem li2) {
            return li1.date.CompareTo(li2.date);
        }
    }
}
