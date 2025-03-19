using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;

namespace DwarfWorkshop5.Models
{
    public class Dwarfs 
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        private int _efficiencyRank;
        public int EffifencyRank
        {
            get => _efficiencyRank;
            set
            {
                if (_efficiencyRank != value)
                {
                    _efficiencyRank = value;
                    OnPropertyChanged(nameof(EffifencyRank));
                }
            }
        }

        private int _qualityRank;
        public int QualityRank
        {
            get => _qualityRank;
            set
            {
                if (_qualityRank != value)
                {
                    _qualityRank = value;
                    OnPropertyChanged(nameof(QualityRank)); 
                }
            }
        }

        private int _rank;
        public int Rank
        {
            get => _rank;
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    OnPropertyChanged(nameof(Rank));
                }
            }
        }

        private bool _unlocked;
        public bool Unlocked
        {
            get => _unlocked;
            set
            {
                if (_unlocked != value)
                {
                    _unlocked = value;
                    OnPropertyChanged(nameof(Unlocked)); 
                }
            }
        }
       
        private int _selectedRecipe1;
        public int SelectedRecipe1
        {
            get => _selectedRecipe1;
            set
            {
                if (_selectedRecipe1 != value)
                {
                    _selectedRecipe1 = value;
                    OnPropertyChanged(nameof(SelectedRecipe1));
                }
            }
        }

        private int _selectedRecipe2;
        public int SelectedRecipe2
        {
            get => _selectedRecipe2;
            set
            {
                if (_selectedRecipe2 != value)
                {
                    _selectedRecipe2 = value;
                    OnPropertyChanged(nameof(SelectedRecipe2));
                }
            }
        }

        private int _selectedRecipe3;
        public int SelectedRecipe3
        {
            get => _selectedRecipe3;
            set
            {
                if (_selectedRecipe3 != value)
                {
                    _selectedRecipe3 = value;
                    OnPropertyChanged(nameof(SelectedRecipe3));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       

    }    
}
