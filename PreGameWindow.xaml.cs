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

namespace UI
{
    /// <summary>
    /// Interaction logic for PreGameWindow.xaml
    /// </summary>
    public partial class PreGameWindow : Window
    {
        public int Size { get; set; }
        public int Bombs { get; set; }
        public PreGameWindow()
        {
            InitializeComponent();
        }

        private void EasyDificultyButton_Click(object sender, RoutedEventArgs e)
        {
            Size = 8;
            Bombs = 10;
            MediumDificultyButton.IsChecked = false;
            HardDificultyButton.IsChecked = false;

        }

        private void MediumDificultyButton_Checked(object sender, RoutedEventArgs e)
        {
            Size = 12;
            Bombs = 25;
            EasyDificultyButton.IsChecked = false;
            HardDificultyButton.IsChecked = false;
        }

        private void HardDificultyButton_Checked(object sender, RoutedEventArgs e)
        {
            Size = 16;
            Bombs = 40;
            EasyDificultyButton.IsChecked = false;
            MediumDificultyButton.IsChecked = false;

        }

        private void PlayAloneBUtton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow(Size, Bombs);
            gw.ShowDialog();
        }

        private void CustumeButton_Click(object sender, RoutedEventArgs e)
        {
            CostumeWindow cw = new CostumeWindow();
            cw.OnBUttonClickedEvent += UpdatePropertiess;  //delegate that update the propeties from custum window
            cw.ShowDialog();
        }
        public void UpdatePropertiess(object sender, int size, int bombs)   
        {
            Size = size;
            Bombs = bombs;
        }
    }
}
