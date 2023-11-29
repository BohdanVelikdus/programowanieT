using System.Collections.Generic;
using System.Windows;

namespace programowanie__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainDser : Window
    {
        List<Person> listOfPersons = new List<Person>();
        string outFilePath = "output2.xml";
        public MainDser()
        {
            InitializeComponent();
            readFile(outFilePath);
            dgSimple.ItemsSource = listOfPersons;
        }
        public void writeFile(string xmlFilePath)
        {
            Serializer.SerializeToXml<List<Person>>(listOfPersons, xmlFilePath);
        }
        public void readFile(string xmlFilePath)
        {
            listOfPersons = Serializer.DeserializeToObject<List<Person>>(xmlFilePath);
        }
        public void Button_AddPerson(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            AddPerson addPersonDialog = new AddPerson();
            addPersonDialog.DataContext = person;
            addPersonDialog.ShowDialog();
            if (addPersonDialog.IsOkPressed)
            {
                listOfPersons.Add(person);
                dgSimple.Items.Refresh();
                writeFile(outFilePath);
            }
        }
    }
}
