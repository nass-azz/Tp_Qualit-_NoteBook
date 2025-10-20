using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;
namespace notebook.view
{
    /// <summary>
    /// Logique d'interaction pour ExamsListWindow.xaml
    /// </summary>
    public partial class ExamsListWindow  : Window
    {
        private readonly Notebook notebook;

        public ExamsListWindow (Notebook nb)
        {
            InitializeComponent();
            notebook = nb ?? throw new ArgumentNullException(nameof(nb));
            DrawExams();
        }

        private void DrawExams()
        {
            var exams = notebook.ListExams();
            examsList.Items.Clear();

            foreach (var exam in exams)
                examsList.Items.Add(exam); 
        }
    }
}
