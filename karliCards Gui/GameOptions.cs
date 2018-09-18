using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace karliCards_Gui
{
    [Serializable]
    public class GameOptions:INotifyPropertyChanged
    {
        private bool _playAgainstComputer = true;
        private int _numberOfPlayers = 2;
        private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
        public bool PlayAgainstComputer
        {
            get { return _playAgainstComputer; }
            set
            { _playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
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
        public int MinutesBeforeLoss { get; set; }
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
