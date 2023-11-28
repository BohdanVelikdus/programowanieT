using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace programowanie__
{
    /// <summary>
    /// Interaction logic for gracz1.xaml
    /// </summary>
    public partial class gracz1 : Window
    {
        public gracz1()
        {
            InitializeComponent();
            int[] tab = new int[100];
            int[] tab2 = new int[100];
            Game gra = new Game(tab, tab2);
            plnPersonForm.DataContext = gra;
            gracz2 okno = new gracz2();
            okno.DataContext = gra;
            okno.Show();
        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]++;
            else if (((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]--;
        }

        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((Game)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Black);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Colors)
            {
                //if ((Colors)value == Colors.Red)
                //    return 4;
                //else
                //    return 0;
            }
            return 0;
        }
    }

    public class YesNoToBooleanConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Transparent);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Colors)
            {
                //if ((Colors)value == Colors.Red)
                //    return 4;
                //else
                //    return 0;
            }
            return 0;
        }
    }
}
