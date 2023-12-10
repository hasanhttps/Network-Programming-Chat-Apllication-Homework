using System;
using System.Windows.Controls;

namespace Client.Views {
    public partial class LoginPage : Page {

        // Private Fields

        private Frame MainFrame;

        // Constructor

        public LoginPage(Frame frame) {

            MainFrame = frame;
            InitializeComponent();
        }

        // Functions

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
            MainFrame.Content = new ChatPage(MainFrame);
        }
    }
}
