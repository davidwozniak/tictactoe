using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Class_Library;

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
        ///  True if the game has ended
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

            // Set each field on .Free
            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            // Make sure player 1 starts the game
            mPlayer1Turn = true;
            

            // Access every button in the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // change background,foreground (player1) and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
               
            });

            

            // Make sure the game hasn't finished
            mGameEnded = false;

        }

        #endregion

        #region setting button click events
        /// <summary>
        /// Handles a button click events
        /// </summary>
        /// <param name="sender">button that was clicked</param>
        /// <param name="e">events of clicks</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it is finished
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

            // toggle players turns, bool's (instead if statement)
            mPlayer1Turn ^= true;


            // check for win with returning MarkType
            CheckForWinner CheckWin = new CheckForWinner();
            var mark = CheckWin.CheckWin(mResults);


            if (mark != MarkType.Free)
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

            // if none of mResluts is free, the game has ended
            if (!mResults.Any(result => result == MarkType.Free))
            {
                // game ended
                mGameEnded = true;

                // turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(item =>
                {

                    item.Background = Brushes.Black;

                });

            }

        }

        #endregion
    }




}
    

