using System.Windows;
using SCHOOL.DTOs.ViewModels.Student;

namespace SCHOOL.DESKTOP.ModulesPages.Student
{
    /// <summary>
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        public UpdateStudent(StudentBaseViewModel model)
        {
            InitializeComponent();
            MapData(model);
        }

        public void MapData(StudentBaseViewModel model)
        {
            PersonName.Text = model.PersonName;
            ClassName.Text = model.ClassName;
            RegistrationNumber.Text = model.RegistrationNumber.ToString();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
