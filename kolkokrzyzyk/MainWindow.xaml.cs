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
        /// Holds the current resultf of cells in active game
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
        public void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[81];

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
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast a sender to a button
            var button = (Button)sender;

            // FindCommonVisualAncestor the buttons position in array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 9);

            // dont do anythig if cell has already a value
            if (mResults[index] != MarkType.Free)
                return;

            // seting a value in cell based on which turn is it
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            // seting button text
            button.Content = mPlayer1Turn ? "X" : "O";

            // change button color
            if (!mPlayer1Turn)
                button.Foreground = Brushes.Green;

            //toggle players turns, bool's (instead if statement)
            mPlayer1Turn ^= true;

            CheckForWinner();



        }

        #endregion

        #region setting winner logic

        
        /// <summary>
        ///     checks if there iis a winner of a 3 line striaght
        /// </summary>
        public void CheckForWinner()
        {
            // Check for horizontal wins


                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
                {
                    //game ends
                    mGameEnded = true;

                    // highlight winning cells in green
                    Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;

                }


            // if none of mResluts is free, the game has ended
            if (!mResults.Any(result => result == MarkType.Free))
            {
                // game ended
                mGameEnded = true;

                // turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {

                    button.Background = Brushes.Orange;

                });

            }
        }

        #endregion
    }




}
    

