using System;

namespace Models.Classes;

public class Message {

    private string? content;

    public string Content {
        get { return content; }
        set {
            content = value;
            Width = 200;
            Heigth += (int)(content.Length * 6 / 200) * 25;
        }
    }
    public string? HorizontalAlignment { get; set; }
    public string? Background { get; set; }
    public string? dateTime { get; set; }
    public int Width { get; set; }
    public int Heigth { get; set; } = 25;

}