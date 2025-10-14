using Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace notebook
{
    public partial class AddExamDialog : Window
    {
        public Exam Exam { get; private set; }

        public AddExamDialog()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Today;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            try
            {
                Exam = new Exam(
                    TeacherBox.Text,
                    DatePicker.SelectedDate ?? DateTime.Today,
                    float.Parse(CoefBox.Text),
                    float.Parse(NoteBox.Text),
                    AbsentBox.IsChecked == true
                );
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
