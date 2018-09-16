using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace KarliCards_Gui
{
  /// <summary>
  /// Interaction logic for Options.xaml
  /// </summary>
  public partial class Options : Window
  {
    private GameOptions _gameOptions;

    public Options()
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
    }

    private void dumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
    }

    private void goodAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Good;
    }

    private void cheatingAIRadioButton_Checked(object sender, RoutedEventArgs e)
    {
      _gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
    }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {
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
  }
}
