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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClearData4hML.ConsoleApp;

namespace Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                Vars.path = dlg.FileName;
                b1.Content = dlg.SafeFileName;
                //lines.Content = "Число строк: " + Program.calc(Vars.path);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "result"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                Vars.pathinput = dlg.FileName;
                b2.Content = dlg.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (b3.Content == "Процесс...".ToString())
            {

            }
            else predictA(b3);
        }

        static async void predictA(Button b3)
        {
            b3.Content = "Процесс...";

            if (Vars.path != null & Vars.pathinput != null)
            {
                await Task.Run(() => Program.predict(Vars.path, Vars.pathinput));

                b3.Content = "ГОТОВО!";
            }
        }

        private void b1_Copy_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                Vars.path = dlg.FileName;
                b1_Copy.Content = dlg.SafeFileName;
                //lines.Content = "Число строк: " + Program.calc(Vars.path);
            }
        }

        private void b3_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(b3_Copy.Content == "Процесс...".ToString())
            {

            }
            else testA(b3_Copy, lll);
        }

        static async void testA(Button b3, Label lll)
        {
            b3.Content = "Процесс...";

            if (Vars.path != null)
            {
                float acc = 0;

                await Task.Run(() => acc = Program.test(Vars.path)); 

                lll.Content = "Точность= " + acc + "%";

                b3.Content = "ГОТОВО!";
            }
        }
    }
}
