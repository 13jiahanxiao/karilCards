using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace KarliCards_Gui
{
  [Serializable]
  public class GameOptions : INotifyPropertyChanged
  {
    private bool _playAgainstComputer = true;
    private int _numberOfPlayers = 2;
    private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
    private ObservableCollection<string> _playerNames = new ObservableCollection<string>();
    public List<string> SelectedPlayers { get; set; }

    public GameOptions()
    {
      SelectedPlayers = new List<string>();
    }

    public ObservableCollection<string> PlayerNames
    {
      get
      {
        return _playerNames;
      }
      set
      {
        _playerNames = value;
        OnPropertyChanged(nameof(PlayerNames));
      }
    }

    public void AddPlayer(string playerName)
    {
      if (_playerNames.Contains(playerName))
        return;
      _playerNames.Add(playerName);
    }

    public int NumberOfPlayers
    {
      get { return _numberOfPlayers; }
      set
      {
        _numberOfPlayers = value;
        OnPropertyChanged(nameof(NumberOfPlayers));
      }
    }
    public bool PlayAgainstComputer
    {
      get { return _playAgainstComputer; }
      set
      {
        _playAgainstComputer = value;
        OnPropertyChanged(nameof(PlayAgainstComputer));
      }
    }
    public ComputerSkillLevel ComputerSkill
    {
      get { return _computerSkill; }
      set
      {
        _computerSkill = value;
        OnPropertyChanged(nameof(ComputerSkill));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
  [Serializable]
  public enum ComputerSkillLevel
  {
    Dumb,
    Good,
    Cheats
  }
}
