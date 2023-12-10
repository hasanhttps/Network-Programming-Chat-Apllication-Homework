using System;
using System.IO;
using System.Windows;
using Models.Classes;
using Client.Commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Client.Views {
    public partial class ChatPage : Page, INotifyPropertyChanged {

        // Private Fields

        private ObservableCollection<User> users;
        private ObservableCollection<Message> chatMessages;
        private Frame MainFrame;
        private BinaryReader BinaryReader;
        private BinaryWriter BinaryWriter;
        private string Name;

        // Properties

        public ObservableCollection<User> Users { get => users; 
            set { 
                users = value;
                OnPropertyChanged();
            } 
        }
        public ObservableCollection<Message> ChatMessages {
            get => chatMessages;
            set {
                chatMessages = value;
                OnPropertyChanged();
            }
        }
        public ICommand? SendButtonCommand { get; set; }

        // Constructor

        public ChatPage(Frame frame, string name, BinaryReader binaryReader, BinaryWriter binaryWriter) {

            InitializeComponent();
            SetCommands();
            DataContext = this;
            MainFrame = frame;
            Name = name;
            BinaryReader = binaryReader;
            BinaryWriter = binaryWriter;
            ChatMessages = new();
            Users = new();
            Users.Add(new User() { Username = "Hesen" });
            ListenClient();
        }

        // Functions

        private void SetCommands() {

            SendButtonCommand = new RelayCommand(SendButtonClicked);
        }

        private void SendButtonClicked(object? param) {

            string message = param as string;

            if (message != null && message != "Type a message.") { 

                BinaryWriter.Write(message);
            }
        }

        private void ListenClient() {

            Task.Run(() => {

                while (true) {

                    var readString = BinaryReader.ReadString();
                    var index = readString.IndexOf(' ');
                    var whom = readString.Substring(0, index);
                    var message = readString.Substring(index + 1);

                    var newuser = new User() { Username = whom, LatestMessage = message };
                    newuser.Messages.Add(message);
                    Users.Add(newuser);
                }
            });
        }

        private void Direct_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            var SelectedItem = Direct.SelectedItem as User;
            foreach (var message in SelectedItem.Messages)
                ChatMessages.Add(new Message() { Content = message, dateTime = DateTime.Now.ToString(), HorizontalAlignment = "Left"});
        }

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
