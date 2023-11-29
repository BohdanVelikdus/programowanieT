using System;
using System.Xml.Serialization;

namespace programowanie__
{
    [Serializable]
    [XmlRoot("Person")]
    public class Person
    {
        [XmlAttribute("Name")]
        public string name { get; set; }
        [XmlAttribute("Surname")]
        public string surname { get; set; }
        [XmlAttribute("PESEL")]
        public string pesel { get; set; }
        public Person(string name, string surname, string pesel)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
        }
        public Person() : this("Patryk", "Patryk", "0510101290")
        {
            
        }
    }
}
