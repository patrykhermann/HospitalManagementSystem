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
using System.Windows.Shapes;

using Employees;

namespace HospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        Employee employee;

        public ChangePasswordWindow(Employee emp)
        {
            InitializeComponent();
            employee = emp;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee.ChangePassword(txtOldPassword.Password, txtNewPassword.Password);

                if (MessageBox.Show("The password has been successfully changed", "", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();
            }
            catch(WrongPasswordException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong - " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
