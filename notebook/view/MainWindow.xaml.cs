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

        // Bouton : Saisir les Matières
        private void SaisirMatieres_Click(object sender, RoutedEventArgs e)
        {
            var unitsWindow = new EditUnitsWindow(notebook);
            unitsWindow.ShowDialog();
        }

        // Bouton : Rentrer un Examen
        private void RentrerExamen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : sélectionnez un module pour ajouter un examen.");
            // Tu peux ici ouvrir une fenêtre de sélection de module, puis EditExamsWindow
        }

        // Bouton : Afficher les Moyens
        private void AfficherMoyens_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fonction à implémenter : calcul et affichage des moyennes.");
            // Tu peux ici parcourir notebook.ListUnits() et calculer les moyennes
        }
    }
}
