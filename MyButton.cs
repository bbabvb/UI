using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UI
{
    public class MyButton : Button
    {
        public Image Image { get; set; }
        public Image Flag { get; set; }
        public int num { get; set; }
        public Position Pos { get; set; }
        public bool isExposed { get; set; }
        public int Size { get; set; }
        public bool flagbool { get; set; }

        public MyButton(int x, int y, int size) : base()
        {
            Pos = new Position(x, y);
            this.Size = size;
            Image = new Image();
            isExposed = false;
            Flag = new Image();
            string path = Environment.CurrentDirectory;
            string path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\flag.png";
            Flag.Source = new BitmapImage(new Uri(path2));
            flagbool = false;
        }
    }
}
