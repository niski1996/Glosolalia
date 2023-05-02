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
using Glosolalia.Business.Entities;
using Glosolalia.Data;

namespace Wordadding
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
            string pl = plInput.Text;
            string en = EnInput.Text;
            var pltmp = new PlWord(pl);
            var entmp = new EnWord(en);
            pltmp.EnWords.Add(entmp);
            entmp.PlWords.Add(pltmp);
            new PlWordRepository().Add(pltmp);


        }
    }
}
