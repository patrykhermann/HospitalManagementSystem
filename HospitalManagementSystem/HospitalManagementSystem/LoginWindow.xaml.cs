using System;
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

using Employees;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Hospital hospital = new Hospital();
        private string fileName = "HospitalData.dat";

        public LoginWindow()
        { 
            InitializeComponent();

            if (File.Exists(fileName))
            {
                hospital = Deserialize(fileName);
            }
            else
            {
                InitializeList();
            }
        }

        // Logowanie
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach(Employee emp in hospital.ListOfEmployees)
            {
                if(emp.CheckLoginAndPassword(txtLogin.Text, txtPassword.Password))
                {
                    MainWindow mw = new MainWindow(emp, hospital, fileName);
                    this.Hide();
                    mw.Show();
                }
            }
            txtLogin.Text = "";
            txtPassword.Password = "";
            txtIncorrect.Visibility = Visibility.Visible;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Inicjalizowana przykładowa lista pracowników, w razie gdy nie istnieje plik ze zserializowaną wcześniej listą
        private void InitializeList()
        {
            hospital = new Hospital();
            try
            {
                hospital.ListOfEmployees.AddRange(
                new List<Employee>
                    {
                        new Cardiologist("Jan", "Kowalski", 65091203031, "jan_kowalski", "jankowalski"),
                        new Urologist("Anna", "Zielna", 78022200920, "anna_zielna", "annazielna"),
                        new Administrator("Patryk", "Hermann", 96011800733, "patryk_hermann", "patrykhermann"),
                        new Laryngologist("Ryszard", "Mostek", 80100212309, "ryszard_mostek", "ryszardmostek"),
                        new Neurologist("Maciej", "Kwiecień", 75052301011, "maciej_kwiecien", "maciejkwiecien"),
                        new Nurse("Grażyna", "Gajewska", 68012380980, "grazyna_gajewska", "grazynagajewska"),
                        new Administrator("admin", "admin", 11111111111, "admin", "admin")
                    });
            }
            catch(WrongPeselException ex)
            {
                MessageBox.Show("Wrong PESEL" + ex.Message);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Deserializacja
        private Hospital Deserialize(string fName)
        {
            Hospital h = new Hospital();
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.Open(fName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                h = (Hospital)binFormat.Deserialize(fStream);
            }
            return h;
        }
    }
}
