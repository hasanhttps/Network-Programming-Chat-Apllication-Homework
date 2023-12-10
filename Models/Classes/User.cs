using System;
using System.Net;

namespace Models.Classes;

public class User {

    // Properties

    public int Id { get; set; }
    public string Username { get; set; }
    public IPEndPoint EndPoint { get; set; }
    public string LatestOnline { get; set; }
    public string LatestMessage { get; set; }
}