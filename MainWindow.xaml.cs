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
using System.Windows.Threading;

namespace BallGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationsTimer = new DispatcherTimer();
        private bool go_to_the_right = true;
        private bool go_up = true;

        public MainWindow()
        {
            InitializeComponent();

            _animationsTimer.Interval = TimeSpan.FromMilliseconds(30);
            _animationsTimer.Tick += _animationsTimer_Tick;

        }

        private void _animationsTimer_Tick(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);

            if (go_to_the_right)
            {
                if (x < (Playground.ActualWidth - Ball.ActualWidth))
                {
                    Canvas.SetLeft(Ball, x + 5);  //defines what should move and how far should it move
                }

                else
                {
                    go_to_the_right = false;
                }
            }

            else
            {
                if (x > 0)
                {
                    Canvas.SetLeft(Ball, x - 5);
                }
                else
                {
                    go_to_the_right = true;
                }
            }

            if (go_up)
            {
                if (y < Playground.ActualHeight - Ball.ActualHeight)
                {
                    Canvas.SetTop(Ball, y + 5);
                }
                else
                {
                    go_up = false;
                }
            }
            else
            {
                if (y > 0)
                {
                    Canvas.SetTop(Ball, y - 5);
                }

                else
                {
                    go_up = true;
                }
            }
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_animationsTimer.IsEnabled)
            {
                StartStopButton.Content = "START";
                _animationsTimer.Stop();   //if animation is on, stop it
            }

            else
            {
                StartStopButton.Content = "STOP";
                _animationsTimer.Start();  //if animation is off, start it
            }

        }
    }
}
