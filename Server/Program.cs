using System.Net;
using System.Net.Sockets;

TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1") , 27001);
server.Start();

while (true) {
    Task.Run(() => {

        var client = server.AcceptTcpClient();
        Console.WriteLine($"{client.Client.LocalEndPoint} Connected.... ");
        var stream = client.GetStream();

        var binaryReader = new BinaryReader(stream);
        var binaryWriter = new BinaryWriter(stream);

        Console.WriteLine($"{binaryReader.ReadString()}");
    });
}
