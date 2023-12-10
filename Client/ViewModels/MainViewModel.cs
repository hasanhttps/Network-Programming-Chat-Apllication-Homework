using System;
using Client.Views;
using System.Windows.Input;
using System.Windows.Controls;

namespace Client.ViewModels;

internal class MainViewModel {

    // Private Fields

    private Frame MainFrame;

    // Properties

    public ICommand? SendButtonCommand { get; set; }

    // Constructor

    public MainViewModel(Frame frame) {

        MainFrame = frame;
        MainFrame.Content = new LoginPage(MainFrame);
    }

    // Functions
}