using System.Windows;
using Logic;

namespace notebook
{
    public partial class EditElementWindow : Window
    {
        public Unit Unit { get; private set; }

        public EditElementWindow()
        {
            InitializeComponent();
        }

        public EditElementWindow(EducationalElement element) : this()
        {
            NameBox.Text = element.Name;
            CoefBox.Text = element.Coef.ToString();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit = new Unit(NameBox.Text, float.Parse(CoefBox.Text));
                DialogResult = true;
            }
            catch (System.Exception ex)
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
