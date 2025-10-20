using System.Windows;
using Logic;

namespace notebook
{
    public partial class EditUnitsAndModulesWindow : Window
    {
        private Notebook notebook;

        public EditUnitsAndModulesWindow(Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            DrawUnits();
        }

        private void DrawUnits()
        {
            UnitsList.ItemsSource = null;
            UnitsList.ItemsSource = notebook.ListUnits();
            ModulesList.ItemsSource = null;
        }

        private void DrawModules(Unit unit)
        {
            ModulesList.ItemsSource = null;
            ModulesList.ItemsSource = unit.ListModules();
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

        private void DeleteUnit(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selected)
            {
                notebook.RemoveUnit(selected);
                DrawUnits();
            }
        }

        private void AddModule(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selectedUnit)
            {
                var editor = new EditElementWindow();
                if (editor.ShowDialog() == true)
                {
                    var module = new Module(editor.Unit.Name, editor.Unit.Coef)
                    {
                        ParentUnit = selectedUnit
                    };
                    selectedUnit.AddModule(module);
                    DrawModules(selectedUnit);
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez une unité avant d’ajouter un module.");
            }
        }

        private void DeleteModule(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selectedUnit &&
                ModulesList.SelectedItem is Module selectedModule)
            {
                selectedUnit.RemoveModule(selectedModule);
                DrawModules(selectedUnit);
            }
        }

        private void UnitsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selectedUnit)
            {
                DrawModules(selectedUnit);
            }
        }
        private void UnitsList_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void ModulesList_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (UnitsList.SelectedItem is Unit selectedUnit &&
                ModulesList.SelectedItem is Module selectedModule)
            {
                var editor = new EditElementWindow(selectedModule);
                if (editor.ShowDialog() == true)
                {
                    selectedModule.Name = editor.Unit.Name;
                    selectedModule.Coef = editor.Unit.Coef;
                    DrawModules(selectedUnit);
                }
            }
        }

    }
}
