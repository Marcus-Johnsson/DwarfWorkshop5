using CommunityToolkit.Mvvm.Input;
using DwarfWorkhop5;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DwarfWorkshop5.ViewPageModel
{
    public partial class GamePageModelViews : INotifyPropertyChanged
    {
        private readonly UserSession _session;
        private User? _currentUser;

        
        
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

        public ICommand SelectDwarfCommand { get; }


        [RelayCommand]
        public async Task BuyDwarfCommand()
        {
            var currentUser = _session.GetCurrentUser();
            var userDwarf = _mydb.Dwarfs.FirstOrDefault(p => p.UserId == currentUser.Id && p.Unlocked == false);

            if (userDwarf == null || currentUser == null || currentUser.TokenAmount < 2)
            {

            }
            else
            {
                currentUser.TokenAmount -= 2;
                userDwarf.Unlocked = true;
                UnlockedDwarfs.Add(userDwarf);
                Token = currentUser.TokenAmount;
                _mydb.SaveChanges();

            }
        }
        [RelayCommand]
        private async Task SelectDwarf(Dwarfs dwarfs)
        {
            
        }
        [RelayCommand]
        private async Task BuyCommand(Products products)
        {
            if (products == null)
            {
                return;
            }
            if (_currentUser.Gold >= products.Price)
            {
                _currentUser.Gold -= products.Price;
                var inventory = _mydb.Inventory.Where(p => p.ProductId == products.Id).FirstOrDefault();
                if (inventory != null)
                {
                    _mydb.Inventory.Add(

                    new Inventory
                    {
                        ProductId = products.Id,
                        Quantity = 1,
                        UserId = _currentUser.Id,
                        Quality = false,
                    });
                }
                else if (inventory != null)
                {
                    inventory.Quantity++;
                }
                _mydb.SaveChanges();
            }
        }

       // private Dwarfs _selectedDwarf;
       //public Dwarfs SelectedDwarf
       // {
       //     get => _selectedDwarf;
       //     set
       //     {
       //         _selectedDwarf = value;
       //         OnPropertyChanged(nameof(SelectedDwarf));
       //     }
       // }

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
            _session = UserSession.GetInstance();
            LoadData();
            
        }
        //private void OnDwarfSelected(Dwarfs selectedDwarf)
        //{
        //    if (selectedDwarf != null)
        //    {
        //        SelectedDwarf = selectedDwarf;
        //    }
        //}
        public async void LoadData()
        {
            var currentUser = _session.GetCurrentUser();

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
        }





    }
}