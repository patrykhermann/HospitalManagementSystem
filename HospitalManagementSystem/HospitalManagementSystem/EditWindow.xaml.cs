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

namespace HospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow mw;
        Employee emp;
        Hospital hospital;

        public EditWindow(MainWindow mw, Employee empToEdit, Hospital h)
        {
            InitializeComponent();

            this.emp = empToEdit;
            this.mw = mw;
            this.hospital = h;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            long pesel = 0;
            try
            {
                if (txtFName.Text.Length < 1 || txtFName.Text.Length < 1 || txtPesel.Text.Length < 1 || txtLogin.Text.Length < 1 || txtPassword.Password.Length < 1)
                    throw new EmptyGapException("Please fill all the gaps.");

                if (!long.TryParse(txtPesel.Text, out pesel))
                    throw new WrongPeselException();

                this.emp.EditDetails(txtFName.Text, txtLName.Text, pesel, txtLogin.Text, txtPassword.Password);
                mw.dataEmployees.ItemsSource = null;
                mw.dataEmployees.ItemsSource = hospital.ListOfEmployees;
                if(MessageBox.Show("The informations has been successfully changed", "", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();
            }
            catch (EmptyGapException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (WrongPeselException)
            {
                MessageBox.Show("Wrong Pesel Number. Try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPesel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
