using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // step 1 - store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                // step 2
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.dat", FileMode.Create, FileAccess.Write);
             
                // step3
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                // step1 - read data from file
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.dat", FileMode.Open, FileAccess.Read);
                // step2- deserialized
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Employee employee = new Employee();
                employee = (Employee)binaryFormatter.Deserialize(fs);
                // step3- display
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // step 1 - store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                // step 2
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.xml", FileMode.Create, FileAccess.Write);
                // step3
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                xmlSerializer.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                // step1 - read data from file
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.xml", FileMode.Open, FileAccess.Read);
                // step2- deserialized
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee employee = new Employee();
                employee = (Employee)xmlSerializer.Deserialize(fs);
                // step3- display
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // step 1 - store data in the object
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                // step 2
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.SOAP", FileMode.Create, FileAccess.Write);
                // step3
                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
                txtId.Clear();
                txtName.Clear();
                txtSalary.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                // step1 - read data from file
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.SOAP", FileMode.Open, FileAccess.Read);
                // step2- deserialized
               SoapFormatter soapFormatter= new SoapFormatter();
                Employee employee = new Employee();
                employee = (Employee)soapFormatter.Deserialize(fs);
                // step3- display
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);

                //step2 
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.Json", FileMode.Create, FileAccess.Write);
                //step3
                JsonSerializer.Serialize<Employee>(fs, employee);
                fs.Close();
                MessageBox.Show("Done");
                txtId.Clear();
                txtName.Clear();
                txtSalary.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\EmpSerialization\emp.Json", FileMode.Open, FileAccess.Read);

                //deserialization
                Employee employee = new Employee();
                employee = JsonSerializer.Deserialize<Employee>(fs);

                //display
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
