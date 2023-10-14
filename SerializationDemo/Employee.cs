using System;
using System.Windows.Forms;
// Binary
using System.Runtime.Serialization.Formatters.Binary;
// XML
using System.Xml.Serialization;
// SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JOSN
using System.Text.Json;
//File
using System.IO;



namespace SerializationDemo
{
    [Serializable]  //This inform to CLR that class can be serialized Or allow serialization.
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}
