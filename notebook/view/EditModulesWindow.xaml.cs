using System.Windows;
using Logic;

namespace notebook
{
    public partial class EditModulesWindow : Window
    {
        private Unit unit;

        public EditModulesWindow(Unit u)
        {
            InitializeComponent();
            unit = u;
            DrawModules();
        }

        private void DrawModules()
        {
            ModulesList.ItemsSource = null;
            ModulesList.ItemsSource = unit.ListModules();
        }

        private void AddModule(object sender, RoutedEventArgs e)
        {
            var editor = new EditElementWindow();
            if (editor.ShowDialog() == true)
            {
                var module = new Module(editor.Unit.Name, editor.Unit.Coef);
                unit.AddModule(module);
                DrawModules();
            }
        }

        private void EditModule(object sender, RoutedEventArgs e)
        {
            if (ModulesList.SelectedItem is Module selected)
            {
                var editor = new EditElementWindow(selected);
                if (editor.ShowDialog() == true)
                {
                    selected.Name = editor.Unit.Name;
                    selected.Coef = editor.Unit.Coef;
                    DrawModules();
                }
            }
        }

        private void DeleteModule(object sender, RoutedEventArgs e)
        {
            if (ModulesList.SelectedItem is Module selected)
            {
                unit.RemoveModule(selected);
                DrawModules();
            }
        }

        private void OpenExams(object sender, RoutedEventArgs e)
        {
            if (ModulesList.SelectedItem is Module selected)
            {
                var examWindow = new EditExamsWindow(selected);
                examWindow.ShowDialog();
            }
        }
    }
}
