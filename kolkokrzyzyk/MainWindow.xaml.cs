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
        public MainWindow()
        {
            InitializeComponent();

            NewGame();

        }



        #endregion

        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[81];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            // Make sure p[layer 1 is current player
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
    }
}
