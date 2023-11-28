using System.Windows;

namespace programowanie__
{
    /// <summary>
    /// Interaction logic for AddToXML.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        public bool IsOkPressed { get; set; }


        public AddPerson()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsOkPressed = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }
    }
}
