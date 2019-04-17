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
using System.Windows.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName;
        private DateTime currentDate = DateTime.Now;
        private Employee emp;
        private Hospital hospital;

        public MainWindow(Employee currEmp, Hospital h, string fName)
        {
            InitializeComponent();

            emp = currEmp;
            hospital = h;
            fileName = fName;

            ConfigureWindow();
        }

        // Podstawowa konfiguracja okna. Włączenie zegara, dostosowanie interfejsu w zależności od zalogowanego użytkownika (administrator lub inny),
        // załadowanie listy pracowników do kontrolki DataGrid, oraz ustawienie kontrolki Calendar w zależności od listy dyżurów pracownika.
        #region Initial Configuration

        private void ConfigureWindow()
        {
            txtUser.Text = $"{emp.FirstName} {emp.LastName}";
            RunClock();

            if (emp.Specialization == "Administrator")
            {
                lviAdd.Visibility = Visibility.Visible;
                foreach (DataGridColumn dc in dataEmployees.Columns)
                    dc.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }

            foreach (DateTime dt in emp.Schedule.ListOfDays)
            {
                txtDates.Text += $"{dt.ToString("dd-MM-yyyy")} \n";
                calCurrent.BlackoutDates.Add(new CalendarDateRange(dt.AddDays(-1), dt.AddDays(1)));
            }

            dataEmployees.SelectedIndex = -1;
            dataEmployees.ItemsSource = hospital.ListOfEmployees;
            calCurrent.DisplayDateStart = new DateTime(currentDate.Year, currentDate.Month, 1);
            calCurrent.DisplayDateEnd = new DateTime(currentDate.Year, currentDate.AddMonths(1).Month, DateTime.DaysInMonth(currentDate.Year, currentDate.AddMonths(1).Month));
            calCurrent.BlackoutDates.Add(new CalendarDateRange(new DateTime(currentDate.Year, currentDate.Month, 1), currentDate));
        }

        private void RunClock()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            lblSeconds.Content = DateTime.Now.ToString("HH:mm:ss");
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblSeconds.Content = DateTime.Now.ToString("HH:mm:ss");

            CommandManager.InvalidateRequerySuggested();
        }

        #endregion

        // Obsługa wylogowania oraz wyjścia z aplikacji. Serializacja biężącej listy pracowników za każdym razem gdy okno jest zamykane.
        #region Closing Window

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Serialize(this.hospital, this.fileName);
            this.Hide();
            LoginWindow lw = new LoginWindow();
            lw.Show();
        }

        private void ButtonPopUpExit_Click(object sender, RoutedEventArgs e)
        {
            Serialize(this.hospital, this.fileName);

            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Serialize(this.hospital, this.fileName);
            Application.Current.Shutdown();
        }

        #endregion

        // Obsługa związana z menu Dyżury. Za pomocą kalendarza, pracownik może dodawać do swojej listy dyżurów kolejne dni.
        // Gdy pracownik doda konkretną datę, to na kontrolce Calendar automatycznie zostanie wyłączona możliwość w ogóle zaznaczenia
        // tego dnia, oraz dnia poprzedniego i kolejnego. Również nie będzie można dodawać kolejnych dni gdy liczba dyżurów w danym miesiącu osiągnie 10.
        #region Schedule Functionality

        private void lviSchedule_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            gridSchedule.Visibility = Visibility.Visible;
            gridEmployees.Visibility = Visibility.Hidden;
            gridAdd.Visibility = Visibility.Hidden;
        }

        private void btnAddDay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (calCurrent.SelectedDate.HasValue)
                {
                    DateTime selectedDay = calCurrent.SelectedDate.Value;
                    if (!emp.Schedule.CanAdd(selectedDay))
                        MessageBox.Show("You can't add this day", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        emp.Schedule.AddDate(selectedDay);
                        txtDates.Text = "";
                        foreach (DateTime dt in emp.Schedule.ListOfDays)
                        {
                            txtDates.Text += $"{dt.ToString("dd-MM-yyyy")} \n";
                        }
                        SearchForAnotherFreeDay(selectedDay);
                        calCurrent.BlackoutDates.Add(new CalendarDateRange(selectedDay.AddDays(-1), selectedDay.AddDays(1)));
                    }
                }
            }
            catch (TooMuchDutiedInTheMonthException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong - " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchForAnotherFreeDay(DateTime dt)
        {
            DateTime dtt = dt.AddDays(2);

            while (true)
            {
                if (calCurrent.BlackoutDates.Contains(dtt))
                {
                    dtt = dtt.AddDays(1);
                }
                else
                {
                    calCurrent.SelectedDate = dtt;
                    break;
                }
            }
        }

        private void btnResetSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure want to reset the whole schedule?", "Reseting schedule", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                emp.Schedule.ListOfDays.Clear();
                calCurrent.BlackoutDates.Clear();
                calCurrent.BlackoutDates.Add(new CalendarDateRange(new DateTime(currentDate.Year, currentDate.Month, 1), currentDate));
                txtDates.Text = "";
            }
        }

        #endregion

        // Obsługa związana z menu Pracownicy. Gdy zalogowany jest zwykły użytkownik to widzi tylko listę pracowników i podstawowe o nich informacje.
        // Gdy zalogowany jest Administrator, widzi on listę wszystkich pracowników oraz pełne o nich informację. Dodatkowo, po zaznaczeniu któregoś wiersza z danym pracownikiem,
        // ma on możliwość usunięcia go, bądź edytowania jego danych.
        #region Employees Functionality

        private void lviEmpoyees_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gridSchedule.Visibility = Visibility.Hidden;
            gridEmployees.Visibility = Visibility.Visible;
            gridAdd.Visibility = Visibility.Hidden;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataEmployees.SelectedIndex != -1)
            {
                EditWindow ew = new EditWindow(this, (Employee)dataEmployees.SelectedItem, hospital);
                ew.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please first select person to edit.", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataEmployees.SelectedIndex != -1)
            {
                if (emp == (Employee)dataEmployees.SelectedItem)
                    MessageBox.Show("You can't remove yourself.");
                else
                {
                    if (MessageBox.Show($"Are you sure you want to remove {((Employee)dataEmployees.SelectedItem).FirstName} {((Employee)dataEmployees.SelectedItem).LastName}?", "",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        hospital.ListOfEmployees.Remove((Employee)dataEmployees.SelectedItem);
                        dataEmployees.ItemsSource = null;
                        dataEmployees.ItemsSource = hospital.ListOfEmployees;
                    }
                }
            }
            else
                MessageBox.Show("Please first select person to delete.", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        #endregion

        // Obsługa związana z menu Dodawania nowego pracownika. Opcję tę widzi tylko Administrator. Ma on możliwość dodania nowego pracownika do systemu, wpisując jego wszystkie dane.
        #region Adding Employee Functionality
        
        private void lviAdd_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gridSchedule.Visibility = Visibility.Hidden;
            gridEmployees.Visibility = Visibility.Hidden;
            gridAdd.Visibility = Visibility.Visible;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            long pesel = 0;
            if (comboSpecialization.SelectedIndex != -1)
            {
                try
                {
                    if (txtFirstName.Text.Length < 1 || txtlastName.Text.Length < 1 || txtPesel.Text.Length < 1 || txtLogin.Text.Length < 1 || txtPassword.Password.Length < 1)
                        throw new EmptyGapException("Please fill all the gaps.");

                    if (!long.TryParse(txtPesel.Text, out pesel)) throw new WrongPeselException();

                    if (comboSpecialization.SelectedItem == citemAdmin)
                    {
                        hospital.ListOfEmployees.Add(new Administrator(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    else if (comboSpecialization.SelectedItem == citemNurse)
                    {
                        hospital.ListOfEmployees.Add(new Nurse(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    else if (comboSpecialization.SelectedItem == citemCardiologist)
                    {
                        hospital.ListOfEmployees.Add(new Cardiologist(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    else if (comboSpecialization.SelectedItem == citemLaryngologist)
                    {
                        hospital.ListOfEmployees.Add(new Laryngologist(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    else if (comboSpecialization.SelectedItem == citemNeurologist)
                    {
                        hospital.ListOfEmployees.Add(new Neurologist(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    else if (comboSpecialization.SelectedItem == citemUrologist)
                    {
                        hospital.ListOfEmployees.Add(new Urologist(txtFirstName.Text, txtlastName.Text, pesel, txtLogin.Text, txtPassword.Password));
                    }
                    dataEmployees.ItemsSource = null;
                    dataEmployees.ItemsSource = hospital.ListOfEmployees;
                    ClearTextBoxes();
                    MessageBox.Show("A new employee has been successfully added.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (EmptyGapException ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (WrongPeselException)
                {
                    MessageBox.Show("Wrong Pesel Number. Try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtPesel.Text = "";
                    lblWrongPesel.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a specialization!");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            comboSpecialization.SelectedIndex = -1;
            txtFirstName.Text = "";
            txtlastName.Text = "";
            txtLogin.Text = "";
            txtPesel.Text = "";
            txtPassword.Password = "";
            lblWrongPesel.Visibility = Visibility.Hidden;
        }

        #endregion

        // Każdy użytkownik ma możliwość zmiany swojego hasła.
        #region Changing Password 

        private void ButtonPopUpChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(emp);
            changePasswordWindow.ShowDialog();
        }

        #endregion

        // Serializacja. Serializowany jest obiekt szpital, który posiada informację o wszystkich pracownikach.
        #region Serialization

        private void Serialize(Hospital hospital, string fName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, hospital);
            }
        }

        #endregion
    }
}
