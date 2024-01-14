using FirebaseCRUD.Domain;
using FirebaseCRUD.Models;
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

namespace FirebaseCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IFirebaseDomain firebaseDomain;
        List<Student> StudentList { get; set;}
        public MainWindow()
        {
            
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            firebaseDomain = FirebaseDomainFactory.GetFirebaseDomain();
            StudentList = await firebaseDomain.GetListStudents();
            lvStudents.ItemsSource = StudentList;
            lstJugadors.ItemsSource = StudentList;
            InitializeComponent();
        }

        private async void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && tbId.Text != "" && tbEmail.Text != "" && tbHobbies.Text != "" && tbBirthdate.Text != "" && tbAverage.Text != "" && tbCicle.Text != "")
            {
                Student student = new Student()
                {
                    Name = tbName.Text,
                    Id = tbId.Text,
                    Email = tbEmail.Text,
                    Hobbies = tbHobbies.Text.Split(",").ToList(),
                    BirthDate = tbBirthdate.Text,
                    AverageScore = Convert.ToInt32(tbAverage.Text)
                };
                if (rbSi.IsChecked == true) student.Dual = true;
                else student.Dual = false;
                student.CicleCursat.FullName = tbCicle.Text;

                await firebaseDomain.AddStudent(student);

                StudentList = await firebaseDomain.GetListStudents();
                lvStudents.ItemsSource = StudentList;
                lstJugadors.ItemsSource = StudentList;
            }
            else
            {
                MessageBox.Show("Falten camps per omplir");
            }
            
        }

        private async void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (tbName2.Text != "" && tbId2.Text != "" && tbEmail2.Text != "" && tbHobbies2.Text != "" && tbBirthdate2.Text != "" && tbAverage2.Text != "" && tbCicle2.Text != "")
            {
                Student student = new Student()
                {
                    Name = tbName2.Text,
                    Id = tbId2.Text,
                    Email = tbEmail2.Text,
                    Hobbies = tbHobbies2.Text.Split(",").ToList(),
                    BirthDate = tbBirthdate2.Text,
                    AverageScore = Convert.ToInt32(tbAverage2.Text)
                };
                if (rbSi2.IsChecked == true) student.Dual = true;
                else student.Dual = false;
                student.CicleCursat.FullName = tbCicle2.Text;

                if(await firebaseDomain.UpdateStudent(student)) MessageBox.Show("Jugador actualitzat");

                StudentList = await firebaseDomain.GetListStudents();
                lvStudents.ItemsSource = StudentList;
                lstJugadors.ItemsSource = StudentList;
            }
            else
            {
                MessageBox.Show("Falten camps per omplir");
            }
        }

        private async void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            if(tbName2.Text != "")
            {
                if(await firebaseDomain.RemoveStudent(tbName2.Text)) MessageBox.Show("Jugador eliminat");
                StudentList = await firebaseDomain.GetListStudents();
                lstJugadors.ItemsSource = StudentList;
            }
            else
            {
                MessageBox.Show("Selecciona un jugador");
            }
        }
    }
}
