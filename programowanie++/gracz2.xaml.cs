using System;
using System.Windows;
using System.Windows.Controls;

namespace programowanie__
{
    /// <summary>
    /// Interaction logic for gracz2.xaml
    /// </summary>
    public partial class gracz2 : Window
    {
        public gracz2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]++;
            else if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]--;
        }
        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }
}
