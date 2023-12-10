using System.Net.Sockets;

var port = 27001;

var client = new TcpClient("127.0.0.1", port);

var stream = client.GetStream();

var binaryReader = new BinaryReader(stream);
var binaryWriter = new BinaryWriter(stream);

Task.Run(async () => {

    Console.Write("Please enter your name: ");

    var name = Console.ReadLine();
    binaryWriter.Write(name!);

    while (true) {

        Console.Write($"To: ");
        var whom = Console.ReadLine();

        Console.Write($"Message: ");
        var message = Console.ReadLine();

        binaryWriter.Write(whom + " " + message);
    }

});

while (true) {

    var readString = binaryReader.ReadString();
    var index = readString.IndexOf(' ');
    var whom = readString.Substring(0, index);
    var message = readString.Substring(index + 1);

    if (!string.IsNullOrEmpty(message)) Console.WriteLine($"\nFrom {whom}: " + message + "\nTo: ");
}