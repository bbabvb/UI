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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        public int Size { get; set; }                //size of the board
        public int Amaount_of_bombs { get; set; }
        public int bombsCounter { get; set; }       
        public MyButton[,] Board { get; set; }      //board buttons arrey  
        public int TimeCounter { get; set; }
        public bool isClockRunable { get; set; }
        
        public GameWindow(int size, int bombs )     
        {

            InitializeComponent();
      

            Size = size;                      //need to change
            Amaount_of_bombs = bombs;          //need to change
            bombsCounter = bombs;
            bombtbx.Text = Amaount_of_bombs.ToString();
            bombtbx.FontSize = 20;
            TimeCounter = 0;
            clocktbx.Text = TimeCounter.ToString(); ;   // initialize bomb counter

            int xPos = 0;   // var to alocate the buttons in the grid
            int yPos = 0;   // var to alocate the buttons in the grid
            Board = new MyButton[Size, Size];


            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();    // create timer for the clock
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            isClockRunable = false;
            Image image = new Image();
            string path = Environment.CurrentDirectory;
            string path2 = path.Substring(0, path.LastIndexOf("bin")) + @"Pictures\happy-face.png";
            image.Source = new BitmapImage(new Uri(path2));
            startButton.Content = image;


            for (int i = 0; i < Size; i++) {  // create the buttons grid
                for (int j = 0; j < Size; j++) {
                    Board[i, j] = new MyButton(i, j, Size) {

                        Width = 33, // Width of button 
                        Height = 26 // Height of button 
                    };
                    Board[i, j].Click += OnButtonCliked;
                    Board[i, j].MouseRightButtonDown += OnButtonRightCliked;
                   
                    // Location of button: 
                    Canvas.SetLeft(Board[i, j], xPos);
                    Canvas.SetTop(Board[i, j], yPos);
                    // Add buttons to a Panel: 
                    pnlButtons.Children.Add(Board[i, j]);

                    xPos = xPos + (int)Board[i, j].Width; // Left of next button 


                }
                yPos += 26;
                xPos = 0;

            }
            DisableAllButton();

            Random rnd = new Random();

            for (int i = 0; i < bombs; i++) {    // locate random bomb's location
                int x_cordinate = rnd.Next(0, Size);
                int y_cordinate = rnd.Next(0, size);
                if (Board[y_cordinate, x_cordinate].num == -1)
                    i--;
                else {
                    Board[y_cordinate, x_cordinate].num = -1;

                }
            }  
            for (int i = 0; i < Size; i++) {         // arenge the board and set each button with the corspone picure 
                for (int j = 0; j < Size; j++) {
                    if (Board[i, j].num != -1)
                        Board[i, j].num = getNumOfBombes(i, j);
                    switch (Board[i, j].num) {   
                        case -1:
                            path = Environment.CurrentDirectory ;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\bomb.jpg";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2)); // set the picture behaind to bomb picture
                            break;
                        case 0:
                            path = Environment.CurrentDirectory;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\empty.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));    // set the picture behaind to bomb picture
                            break;
                        case 1:
                             path = Environment.CurrentDirectory + @"\Pictures\one.png";
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\one.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));   // set the picture behaind to bomb picture
                            break;
                        case 2:
                             path = Environment.CurrentDirectory ;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\\two.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));    // set the picture behaind to bomb picture
                            break;
                        case 3:
                             path = Environment.CurrentDirectory ;// set the picture behaind to bomb picture
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\three.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));
                            break;
                        case 4:
                             path = Environment.CurrentDirectory;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\for.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));   // set the picture behaind to bomb picture
                            break;
                        case 5:
                             path = Environment.CurrentDirectory;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\five.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));   // set the picture behaind to bomb picture
                            break;
                        case 6:
                             path = Environment.CurrentDirectory ;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\six.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));  // set the picture behaind to bomb picture
                            break;
                        case 7:
                             path = Environment.CurrentDirectory;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\seven.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));  // set the picture behaind to bomb picture
                            break;
                        case 8:
                             path = Environment.CurrentDirectory;
                            path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\eghit.png";
                            Board[i, j].Image.Source = new BitmapImage(new Uri(path2));  // set the picture behaind to bomb picture
                            break;


                    }
                }
            }
             this.Height = Size*26 +190;
             this.Width = Size*34+32/Size;
            string temp = this.ActualHeight.ToString() + ActualWidth.ToString();
            clocktbx.Text = temp;

        }

        private int getNumOfBombes(int x, int y)      // return how many bombs there is neer this spsipic button
        {
            int counter = 0;
            for (int i = x - 1; i <= x + 1; i++) {
                if (i == -1 || i == Size)
                    continue;
                if (i >= 0) {
                    for (int j = y - 1; j <= y + 1; j++) {
                        if (j == -1 || j == Size)
                            continue;
                        if (j >= 0 && Board[i, j].num == -1)
                            counter++;
                    }
                }
            }
            return counter;
        }

        private void OnButtonCliked(Object sourse, EventArgs args)   // menagger for one turn
        {
            int counter=0;
            MyButton btn = (MyButton)sourse;

            if (!Expose(btn)) {
                // to do! game is over this user is loose
                ExposeAllBomobs();
                // update the pictur
                     Image image = new Image();
                     string path = Environment.CurrentDirectory;
                     string path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\sade-face.png";
                     image.Source = new BitmapImage(new Uri(path2));
                     startButton.Content = image;

                MessageBox.Show("Game is over, you lost!", "Game Over");
                Close();
            }
            else {
                // to do! turn is finished
                for (int i = 0 ; i < Size; i++) {         
                    for (int j = 0; j < Size; j++) {
                        if (Board[i, j].isExposed )
                            counter ++;
                    }
                }
            }
            if (counter == Size * Size - Amaount_of_bombs) {  // when this user is won
                ExposeAllBomobs();
                // update the pictur
                Image image = new Image();
                string path = Environment.CurrentDirectory;
                string path2 = path.Substring(0, path.LastIndexOf("bin")) + @"\Pictures\cool-face.jpg";
                image.Source = new BitmapImage(new Uri(path2));
                startButton.Content = image;
                MessageBox.Show("You won!");
                Close();
               
            }
        }

        private void OnButtonRightCliked(Object sourse, EventArgs args)  // update this button content to flag symbol
        {
          
            MyButton btn = (MyButton)sourse;
            if (btn.flagbool==false) {
                btn.Content = btn.Flag;
                btn.flagbool = true;
                bombsCounter--;
                bombtbx.Text = bombsCounter.ToString();
            }
            else {
                btn.Content = null;
                btn.flagbool = false;
                bombsCounter--;
                bombtbx.Text = bombsCounter.ToString(); ;
            }

           
            

        }  
        private void DispatcherTimer_Tick(Object sourse, EventArgs args)      // update the timer in every time click
        {
            if (isClockRunable) {
                TimeCounter++;
                clocktbx.Text = TimeCounter.ToString();
            }

        }

        private bool Expose(MyButton btn)  // expose button and return if the button that was cliked is bomb
        {
            if (btn.num != 0 && btn.num != -1) {  //when there is number in this cell
                btn.isExposed = true;
                btn.IsHitTestVisible = false;
                btn.Content = btn.Image;
                if (btn.flagbool == true) {   //update the bobs counter
                    Amaount_of_bombs++;
                    bombtbx.Text = Amaount_of_bombs.ToString();
                }
                return true;
            }
            else if (btn.num == -1) {       // when ther is bob in this cell (end of game)
                btn.Content = btn.Image;
                btn.IsHitTestVisible = false;
                if (btn.flagbool == true) {
                    bombsCounter--;
                    bombtbx.Text = bombsCounter.ToString();
                }

                return false;
            }

            else for (int i = btn.Pos.X - 1; (i <= btn.Pos.X + 1) && (i < Size); i++) {      // eposing rutin
                    if (i >= 0) {
                        for (int j = btn.Pos.Y - 1; (j <= btn.Pos.Y + 1) && (j < Size); j++) {
                            if ((j >= 0) && !Board[i, j].isExposed && Board[i, j].num != -1) {
                                Board[i, j].isExposed = true;
                                Board[i, j].IsHitTestVisible = false;
                                Board[i, j].Content = Board[i, j].Image;
                                if (Board[i, j].flagbool == true) {
                                    Amaount_of_bombs++;
                                    bombtbx.Text = Amaount_of_bombs.ToString();
                                }
                                if (Board[i, j].num == 0) {

                                    OnButtonCliked(Board[i, j], EventArgs.Empty);
                                }
                            }
                        }
                    }
                }
            return true;
        }

        private void ExposeAllBomobs()  // eexpose all the bomb in the end of the game
        {
            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    if (Board[i, j].num == -1)
                        Board[i, j].Content = Board[i, j].Image;
                }
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
             isClockRunable = true;
             ActivateAllButtons();
        }
        private void DisableAllButton()
        {
            for(int i=0; i <Size; i++) {
                for (int j = 0; j < Size; j++) {
                    Board[i, j].IsHitTestVisible = false;
                }
            }
        }
        private void ActivateAllButtons()
        {
            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    Board[i, j].IsHitTestVisible = true;
                }
            }
        }
        private void ActivateAllLegalButtons()
        {
            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    if (Board[i, j].isExposed)
                    Board[i, j].IsHitTestVisible = true;
                }
            }
        }
    }
}
