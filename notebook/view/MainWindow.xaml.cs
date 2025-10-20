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
            var unitsWindow = new EditUnitsWindow(notebook);
            unitsWindow.ShowDialog();
        }

      
        private void RentrerExamen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : sélectionnez un module pour ajouter un examen.");
        }

      
        private void AfficherMoyens_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : calcul et affichage des moyennes.");
        }

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

    }
}
