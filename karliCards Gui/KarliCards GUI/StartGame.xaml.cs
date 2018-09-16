using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace KarliCards_Gui
{
  /// <summary>
  /// Interaction logic for StartGame.xaml
  /// </summary>
  public partial class StartGame : Window
  {
    private GameOptions _gameOptions;
    public StartGame()
    {
      if (_gameOptions == null)
      {
        if (File.Exists("GameOptions.xml"))
        {
          using (var stream = File.OpenRead("GameOptions.xml"))
          {
            var serializer = new XmlSerializer(typeof(GameOptions));
            _gameOptions = serializer.Deserialize(stream) as GameOptions;
          }
        }
        else
          _gameOptions = new GameOptions();
      }
      DataContext = _gameOptions;
      InitializeComponent();
      if (_gameOptions.PlayAgainstComputer)
        playerNamesListBox.SelectionMode = SelectionMode.Single;
      else
        playerNamesListBox.SelectionMode = SelectionMode.Extended;

    }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {
      foreach (string item in playerNamesListBox.SelectedItems)
      {
        _gameOptions.SelectedPlayers.Add(item);
      }
      using (var stream = File.Open("GameOptions.xml", FileMode.Create))
      {
        var serializer = new XmlSerializer(typeof(GameOptions));
        serializer.Serialize(stream, _gameOptions);
      }
      Close();
    }

    private void cancelButton_Click(object sender, RoutedEventArgs e)
    {
      _gameOptions = null;
      Close();
    }

    private void playerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (_gameOptions.PlayAgainstComputer)
        okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == 1);
      else
        okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == _gameOptions.NumberOfPlayers);

    }

    private void addNewPlayerButton_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
        _gameOptions.AddPlayer(newPlayerTextBox.Text);
      newPlayerTextBox.Text = string.Empty;
    }
  }
}
