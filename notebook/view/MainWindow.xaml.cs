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

        private void SaisirMatieres_Click(object sender, RoutedEventArgs e)
        {
            var unitsWindow = new EditUnitsAndModulesWindow(notebook);
            unitsWindow.ShowDialog();
        }
        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            var dialog = new AddExamDialog(notebook);
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("Examen ajouté avec succès.");
            }
        }





        private void AfficherMoyens_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : calcul et affichage des moyennes.");
        }

    }
}
