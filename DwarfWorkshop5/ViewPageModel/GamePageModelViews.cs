using DwarfWorkhop5;
using DwarfWorkshop5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DwarfWorkshop5.ViewPageModel
{
    public class GamePageModelViews : INotifyPropertyChanged
    {
        private readonly MyDbContext _mydb;

        private ObservableCollection<Products> _shopGems = new();
        public ObservableCollection<Products> ShopGems => _shopGems;


        private ObservableCollection<Products> _shopOre = new();
        public ObservableCollection<Products> ShopOre => _shopOre;


        private ObservableCollection<Dwarfs> _unlockedDwarfs = new();
        public ObservableCollection<Dwarfs> UnlockedDwarfs 
        {
            get => _unlockedDwarfs;
             set
    {
        if (_unlockedDwarfs != value)
        {
            _unlockedDwarfs = value;
            OnPropertyChanged(nameof(UnlockedDwarfs));
                    
                }
    }
}


        private ObservableCollection<Inventory> _inventoryFinishedProducts = new();
        public ObservableCollection<Inventory> InventoryFinishedProducts => _inventoryFinishedProducts;

        private ObservableCollection<Inventory> _inventoryMaterials = new();
        public ObservableCollection<Inventory> InventoryMaterials => _inventoryMaterials;

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(Token));
            }
        }




        public ICommand SelectDwarfCommand { get; }


        public GamePageModelViews()
        {
            SelectDwarfCommand = new Command<Dwarfs>(OnDwarfSelected);
        }
        
       private Dwarfs _selectedDwarf;
       public Dwarfs SelectedDwarf
        {
            get => _selectedDwarf;
            set
            {
                _selectedDwarf = value;
                OnPropertyChanged(nameof(SelectedDwarf));
            }
        }

        private int _token;
        public int Token
        {
            get => _token;
            set { _token = value; OnPropertyChanged(nameof(Token)); }
        }

        private double _gold;
        public double Gold
        {
            get => _gold;
            set { _gold = value; OnPropertyChanged(nameof(Gold)); }
        }

        private int _lvl;
        public int Lvl
        {
            get => _lvl;
            set { _lvl = value; OnPropertyChanged(nameof(Lvl)); }
        }

       
        public GamePageModelViews(MyDbContext dbContext)
        {
            _mydb = dbContext;

            LoadData();
        }
        private void OnDwarfSelected(Dwarfs selectedDwarf)
        {
            if (selectedDwarf != null)
            {
                SelectedDwarf = selectedDwarf;
            }
        }
        private async void LoadData()
        {
            var currentUser = GetSetData.GetCurrentUser();
            var shopGemsList = await _mydb.Products.Where(p => p.CategoryId == 3 && p.LvlRequirement <= currentUser.Lvl).ToListAsync();

            _shopGems = new ObservableCollection<Products>(shopGemsList);

            var shopOreList = await _mydb.Products.Where(p => p.CategoryId == 1 && p.LvlRequirement <= currentUser.Lvl).ToListAsync();

            _shopOre = new ObservableCollection<Products>(shopOreList);

            var dwarfs = _mydb.Dwarfs.Where(p => p.UserId == currentUser.Id && p.Unlocked).ToList();
            _unlockedDwarfs = new ObservableCollection<Dwarfs>(dwarfs);

             var userInventory = _mydb.Inventory              // material list category 1,2,3 and 4 finished product
                .Where(inv => currentUser.Id == inv.UserId)
                .ToList();

            var recipeAvailable = _mydb.Recipes
                .Where(r => _mydb.Products
                    .Any(p => p.Id == r.ProductId && p.LvlRequirement <= currentUser.Lvl))
                .ToList();
            _inventoryMaterials = new ObservableCollection<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 1 | p.CategoryId == 2 | p.CategoryId == 4))));

            _inventoryFinishedProducts = new ObservableCollection<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 4))));

            Gold = currentUser.Gold;
            Lvl = currentUser.Lvl;
            Token = currentUser.TokenAmount;


        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
          
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            var currentUser = GetSetData.GetCurrentUser();
            currentUser.LastSave = DateTime.UtcNow;
            _mydb.SaveChanges();
        }





    }
}