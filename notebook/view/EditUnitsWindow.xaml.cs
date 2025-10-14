using System.Windows;
using Logic;

namespace notebook
{
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;

        public EditUnitsWindow(Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            DrawUnits();
        }

        private void DrawUnits()
        {
            UnitsList.ItemsSource = null;
            UnitsList.ItemsSource = notebook.ListUnits();
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            var editor = new EditElementWindow();
            if (editor.ShowDialog() == true)
            {
                try
                {
                    notebook.AddUnit(editor.Unit);
                    DrawUnits();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void EditUnit(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selected)
            {
                var editor = new EditElementWindow(selected);
                if (editor.ShowDialog() == true)
                {
                    selected.Name = editor.Unit.Name;
                    selected.Coef = editor.Unit.Coef;
                    DrawUnits();
                }
            }
        }

        private void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selected)
            {
                notebook.RemoveUnit(selected);
                DrawUnits();
            }
        }

        private void OpenModules(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selected)
            {
                var moduleWindow = new EditModulesWindow(selected);
                moduleWindow.ShowDialog();
            }
        }
    }
}
