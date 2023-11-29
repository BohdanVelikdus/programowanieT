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

        private void CompleteAdding(object sender, RoutedEventArgs e)
        {
            IsOkPressed = true;
            this.Close();
        }

        private void DiscardChanges(object sender, RoutedEventArgs e)
        {
            IsOkPressed = false;
            this.Close();
        }
    }
}
