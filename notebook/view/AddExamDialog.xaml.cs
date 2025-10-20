using Logic;
using System;
using System.Windows;

namespace notebook
{
    public partial class AddExamDialog : Window
    {
        private Notebook notebook;
        public Exam Exam { get; private set; }

        public AddExamDialog(Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            ModuleBox.ItemsSource = notebook.ListModules();
            DatePicker.SelectedDate = DateTime.Today;
            AbsentBox.IsChecked = true;
            NoteBox.Text = "0";
            CoefBox.Text = "1";
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ModuleBox.SelectedItem is not Module selectedModule)
                    throw new Exception("Veuillez sélectionner un module.");

                Exam = new Exam(
                    TeacherBox.Text,
                    DatePicker.SelectedDate ?? DateTime.Today,
                    float.Parse(CoefBox.Text),
                    float.Parse(NoteBox.Text),
                    AbsentBox.IsChecked == true
                );

                selectedModule.AddExam(Exam);
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
