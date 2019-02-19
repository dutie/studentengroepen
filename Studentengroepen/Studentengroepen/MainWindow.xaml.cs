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
using System.IO;

namespace Studentengroepen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            createButtons();

            showDate();
        }

        private void createButtons()
        {

            string sourceDirectory = @"D:\OneDrive\Documents\School\Courses\2e\SEM 2\WPF\Exercises\Studentengroepen\Studentengroepen\Studentengroepen\Bestanden";
            Console.WriteLine("TEST!!!");
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");

                foreach (string doc in txtFiles)
                {
                    Button button = new Button();
                    string name = "";


                    name = doc.Substring(sourceDirectory.Length + 1);
                    name = name.Substring(0, name.Length - 4);
                    name = name.Substring(0, 1) + " " + name.Substring(1,3) + " " + name.Substring(name.Length-1,1);

                    button.Content = name;

                    button.Click += this.Button_Click;

                    this.panelButtons.Children.Add(button);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void showDate()
        {
            DateTime datum = DateTime.Now;
            this.footerPanel.Text = datum.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

      


            // read classes according to the pressed button

            //what is the chosen class:
            string klas = ((Button)sender).Content.ToString();
            //set header
            this.headerOverzicht.Text = "Overzicht studenten " + klas;

            //get correct file
            //set string to file format
            string bestand = klas.Replace(" ", "");
            bestand = bestand + ".txt";
            int counter = 1;
            //reading files
            //personen
            StringBuilder personen = new StringBuilder();
            using (StreamReader reader = new StreamReader("Bestanden/"+bestand,UTF7Encoding.UTF7)){
                while (!reader.EndOfStream)
                {
                    personen.Append(counter + ". \t" + reader.ReadLine() + Environment.NewLine);
                    counter++;
                }
            }

            this.MainText.Text = personen.ToString();





        }
    }
}
