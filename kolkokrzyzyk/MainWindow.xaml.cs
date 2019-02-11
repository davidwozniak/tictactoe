using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace kolkokrzyzyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current result of cells in active game
        /// </summary>
        private MarkType[] mResults;


        /// <summary>
        /// True if its player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        ///  true if the game has ended
        /// </summary>
        private bool mGameEnded;
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow ()
        {
            InitializeComponent();

            NewGame();

        }

        #endregion

        #region Clearing board, starting new game
        /// <summary>
        /// starting new game, clearing board
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[25];


            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;
                
                

            // Make sure p[layer 1 starts the game
            mPlayer1Turn = true;
            

            // access every button in the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
               
            });

            

            //make sure the game hasn't finished
            mGameEnded = false;

        }

        #endregion

        #region setting buttons logic
        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">button that was clicked</param>
        /// <param name="e">events of clicks</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast a sender to a button
            var button = (Button)sender;

            // Find the buttons position in array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 5);

            // dont do anythig if cell has already a value
            if (mResults[index] != MarkType.Free)
                return;

            // seting a value in cell based on which turn is it
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // seting button text
            button.Content = mPlayer1Turn ? "X" : "O";

            // change button color
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Red;

            //toggle players turns, bool's (instead if statement)
            mPlayer1Turn ^= true;



            // check for win
            var mark = CheckWin();

            if (mark!= MarkType.Free)
            {
                button.Background = Brushes.Orange;
                mGameEnded = true;
                if (mark == MarkType.Nought)
                {
                    Container.Children.Cast<Button>().ToList().ForEach(item =>
                    {

                        item.Background = Brushes.Red;

                    });

                }
                else
                {
                    Container.Children.Cast<Button>().ToList().ForEach(item =>
                    {

                        item.Background = Brushes.Blue;

                    });
                }
            }




        }

        #endregion

        #region setting winner logic


        /// <summary>
        /// checking for win
        /// </summary>
        /// <returns></returns>
        private MarkType CheckWin()
        {
            for (var x = 0; x < 5; x++)
            {
                for (var y = 0; y < 5; y++)
                {
                    var offset = y * 5 + x;
                    var mark = mResults[offset];
                    if (mark == MarkType.Free)
                    {
                        // don't do the checks when we are on a free mark
                        continue;

                    }

                    if (x <= 2 && mark == mResults[offset + 1] && mark == mResults[offset + 2])
                    {
                        // Horizontal match at (x,y)..(x+2,y)
                        return mark;


                    }

                    if (y <= 2 && mark == mResults[offset + 5] && mark == mResults[offset + 10])
                    {
                        // Vertical match at (x,y)..(x,y+2)
                        return mark;
                    }

                    if (x <= 2 && y <= 2 && mark == mResults[offset + 6] && mark == mResults[offset + 12])
                    {
                        // Diagonal match at (x,y)..(x+2,y+2)
                        return mark;
                    }
                    if (x <= 2 && y >= 2 && mark == mResults[offset - 4] && mark == mResults[offset - 8])
                    {
                        // Diagonal match at (x,y)..(x+2,y-2)
                        return mark;
                    }
                }
            }

            // if none of mResluts is free, the game has ended
            if (!mResults.Any(result => result == MarkType.Free))
            {
                // game ended
                mGameEnded = true;

                // turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {

                    button.Background = Brushes.Black;

                });

            }
            return MarkType.Free;
        }



        #endregion
    }




}
    

