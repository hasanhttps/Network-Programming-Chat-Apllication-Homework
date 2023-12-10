using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
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

            var ip = IPAddress.Parse("127.0.0.1");
            var port = 27001;

            TcpClient client = new TcpClient();
            client.Connect(ip, port);

            var stream = client.GetStream();

            var binaryReader = new BinaryReader(stream);
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(UsernameTB.Text);

            MainFrame.Content = new ChatPage(MainFrame, UsernameTB.Text, binaryReader, binaryWriter);
        }
    }
}
