using System.Windows;
using Logic;

namespace notebook
{
    public partial class EditExamsWindow : Window
    {
        private Module module;

        public EditExamsWindow(Module m)
        {
            InitializeComponent();
            module = m;
            DrawExams();
        }

        private void DrawExams()
        {
            ExamsList.ItemsSource = null;
            ExamsList.ItemsSource = module.ListExams();
        }

        private void AddExam(object sender, RoutedEventArgs e)
        {
            var dialog = new AddExamDialog();
            if (dialog.ShowDialog() == true)
            {
                module.AddExam(dialog.Exam);
                DrawExams();
            }
        }

        private void DeleteExam(object sender, RoutedEventArgs e)
        {
            if (ExamsList.SelectedItem is Exam selected)
            {
                module.RemoveExam(selected);
                DrawExams();
            }
        }
    }
}
