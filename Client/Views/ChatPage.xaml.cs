using System;
using System.IO;
using System.Net;
using Client.Commands;
using System.Net.Sockets;
using System.Windows.Input;
using System.Windows.Controls;

namespace Client.Views {
    public partial class ChatPage : Page {

        // Private Fields

        private Frame MainFrame;

        // Properties

        public ICommand? SendButtonCommand { get; set; }

        // Constructor

        public ChatPage(Frame frame) {

            MainFrame = frame;
            InitializeComponent();
            SetCommands();
        }

        // Functions

        private void SetCommands() {

            SendButtonCommand = new RelayCommand(SendButtonClicked);
        }

        private void SendButtonClicked(object? param) {

            string message = param as string;

            if (message != null && message != "Type a message.") { 

                var ip = IPAddress.Parse("127.0.0.1");
                var port = 27001;

                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                var stream = client.GetStream();

                var binaryReader = new BinaryReader(stream);
                var binaryWriter = new BinaryWriter(stream);

                binaryWriter.Write(message);
            }
        }
    }
}
