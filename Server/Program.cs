using System.Net;
using Models.Classes;
using System.Net.Sockets;

TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1") , 27001);
server.Start();

Dictionary<string, TcpClient> Users = new Dictionary<string, TcpClient>();


while (true) {

    var client = server.AcceptTcpClient();
    

    Task.Run(() => {

        bool isRegistration = true;
        Console.WriteLine($"{client.Client.LocalEndPoint} Connected.... ");
        var stream = client.GetStream();

        var binaryReader = new BinaryReader(stream);
        var binaryWriter = new BinaryWriter(stream);

        if (isRegistration) {

            var username = binaryReader.ReadString();
            Console.WriteLine(username);
            Users.Add(username, client);
            isRegistration = false;
        }

        while (true) {

            var readString = binaryReader.ReadString();
            var index = readString.IndexOf(' ');
            var whom = readString.Substring(0, index);
            var message = readString.Substring(index + 1);

            foreach (var key in Users) {
                if (key.Key == whom) {
                    stream = key.Value.GetStream();
                    binaryWriter = new BinaryWriter(stream);
                    Console.WriteLine(message);
                    binaryWriter.Write(readString);
                    break;
                }
            }
        }
    });
}
