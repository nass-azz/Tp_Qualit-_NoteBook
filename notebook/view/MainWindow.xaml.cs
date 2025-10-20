using System.Windows;
using Logic;

namespace notebook.view
{
    public partial class MainWindow : Window
    {
        private Notebook notebook;

        public MainWindow()
        {
            InitializeComponent();
            notebook = new Notebook();
        }

<<<<<<< HEAD
       
=======
>>>>>>> 4982de92ad3b3eeb4958cd562c12da320cdf63b7
        private void SaisirMatieres_Click(object sender, RoutedEventArgs e)
        {
            var unitsWindow = new EditUnitsAndModulesWindow(notebook);
            unitsWindow.ShowDialog();
        }
<<<<<<< HEAD

      
        private void RentrerExamen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : sélectionnez un module pour ajouter un examen.");
        }

      
=======
        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            var dialog = new AddExamDialog(notebook);
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("Examen ajouté avec succès.");
            }
        }





>>>>>>> 4982de92ad3b3eeb4958cd562c12da320cdf63b7
        private void AfficherMoyens_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : calcul et affichage des moyennes.");
        }

<<<<<<< HEAD
        private void GoListeExams(object sender, RoutedEventArgs e)
        {
            var examsWindow = new ExamsListWindow (notebook);
            examsWindow.ShowDialog();

        }
        private void GoListExams(object sender, RoutedEventArgs e)
        {
            var w = new ExamsListWindow (notebook);
            w.Show();
        }

=======
>>>>>>> 4982de92ad3b3eeb4958cd562c12da320cdf63b7
    }
}
