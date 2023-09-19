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

namespace Prog6212Part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Module> modules = new List<Module>();
        List<Module> filtered;

        public Module md = new Module();

        public object CalculateMod { get; private set; }

        public MainWindow()

        {
            InitializeComponent();
        }

        public class Module
        {
            public string moduleName { get; set; }
            public string moduleCode { get; set; }
            public int No_ofCredits { get; set; }
            public int Hours { get; set; }
            public int Weeks { get; set; }
            public string startDate { get; set; }
            public int self { get; set; }
            public int remain { get; set; }

            internal int SelfStudies(int value1, int value2, int value3) => throw new NotImplementedException();

            internal int RemainingHours(int self, int value4) => throw new NotImplementedException();
        }


        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            //validation 
            if (tb1.Text.Length == 0 || tb2.Text.Length == 0 || tb3.Text.Length == 0 || tb4.Text.Length == 0)
            {
                MessageBox.Show("Fields cannot be Left Blank >>>>");
            }
            else
            {
                // confirm if entry is correct before sending to the Datagrid
                if (MessageBox.Show("Is the entry correct?", "Cofirm Entry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // pull info from the boxes
                    Module md = new Module();
                    md.moduleName = tb2.Text;
                    md.moduleCode = tb1.Text;
                    md.No_ofCredits = Convert.ToInt32(this.tb3.Text);
                    md.Hours = Convert.ToInt32(this.tb4.Text);

                    cb1.Items.Add(md.moduleCode);

                    modules.Add(md);



                    //Info from the text boxes are added into the datagrid
                    Datagrid1.Items.Add(md);

                    //Clear all the textboxes
                    //tb1.Text = "";
                    //tb2.Text = "";
                    //tb3.Text = "";
                    //tb4.Text = "";
                }
            }
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            // Clear the datagrid
            Datagrid1.Items.Clear();
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Datagrid1.Items.Clear();

        }

    

        private void bt6_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(tb3.Text, out int value1) &&
                int.TryParse(tb5.Text, out int value2) &&
                int.TryParse(tb4.Text, out int value3) &&
                int.TryParse(tb6.Text, out int value4)) 
            {
                Module md = new Module();
                md.self = md.SelfStudies(value1, value2, value3);
                md.remain = md.RemainingHours(md.self, value4);

                tb7.Text = md.remain.ToString();
            }
            else
            {
                // Handle the case where input is not a valid integer
                tb7.Text = "Invalid input";
            }
        }
        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Datagrid1.Items.Clear();
            ComboBoxItem cbi = (ComboBoxItem)cb2.SelectedItem;
            if (cb2.SelectedItem != null)
            {
                string opt = cbi.Content.ToString();
                switch (opt)
                {
                    case "Ascending order by Module Name":
                        filtered = modules.OrderBy(md => md.moduleName).ToList();

                        //using linq
                        filtered = (from f in modules
                                    orderby md.moduleName
                                    select f).ToList();
                        foreach (Module m in filtered)
                        {
                            Datagrid1.Items.Add(m);
                        }

                        break;

                    case "Descending Order by Hours per Week":
                        filtered = modules.OrderBy(md => md.Hours).ToList();
                        filtered = (from f in modules
                                    orderby md.moduleName
                                    select f).ToList();
                        foreach (Module m in filtered)
                        {
                            Datagrid1.Items.Add(m);
                        }

                        break;
                }






            }
        }
    }
}
   
