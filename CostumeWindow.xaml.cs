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
    /// Interaction logic for CostumeWindow.xaml
    /// </summary>
    public partial class CostumeWindow : Window
    {
        public int Size { get; set; }
        public int Bombs { get; set; }
        public CostumeWindow()
        {
            InitializeComponent();
        }
        public delegate void ButtonClicked(object sender ,int size, int bombs);
        public event ButtonClicked OnBUttonClickedEvent;

        private void SubmicButton_Click(object sender, RoutedEventArgs e)
        {
         
                try {
                    Size = int.Parse(SizeOfBoardtbx.Text);
                    Bombs = int.Parse(AmountOfBombstbx.Text);
                    if (Bombs > Size * Size)
                        throw new ToManyBombsException();
                    
                }
                catch (ToManyBombsException) {
                   
                    MessageBox.Show("To many bombs, try again!");
                }
                catch (Exception) {
                   
                    MessageBox.Show("Wrong input, try again!");
                }
         
            OnBUttonClickedEvent(this, Size, Bombs);
            Close();
        }
    }
}
