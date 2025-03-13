using DwarfWorkshop5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DwarfWorkshop5.ViewPageModel
{
    class GamePageModelViews : INotifyPropertyChanged
    {
        private readonly MyDbContext _mydb;
        private readonly User _currentUser;
        public ObservableCollection<Products> ShopGems { get; set; }
        public ObservableCollection<Products> ShopOre { get; set; }

        public ObservableCollection<Inventory> InventoryMaterials { get; set; }
        public ObservableCollection<Inventory> InventoryFinishedProducts { get; set; }

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
            set { _gold = value; OnPropertyChanged(nameof(Lvl)); }
        }
        public GamePageModelViews(MyDbContext dbContext, User user)
        {
            _mydb = dbContext;
            _currentUser = user;    

            LoadData();
        }
        private async void LoadData()
        {

            var shopGemsList = await _mydb.Products.Where(p => p.CategoryId == 3 && p.LvlRequirement <= _currentUser.Lvl).ToListAsync();

            ShopGems = new ObservableCollection<Products>(shopGemsList);

            var shopOreList = await _mydb.Products.Where(p => p.CategoryId == 1 && p.LvlRequirement <= _currentUser.Lvl).ToListAsync();

            ShopOre = new ObservableCollection<Products>(shopOreList);

            var userInventory = _mydb.Inventory              // material list category 1,2,3 and 4 finished product
                .Where(inv => _currentUser.Id == inv.UserId)
                .ToList();

            var recipeAvailable = _mydb.Recipes
                .Where(r => _mydb.Products
                    .Any(p => p.Id == r.ProductId && p.LvlRequirement <= _currentUser.Lvl))
                .ToList();
            InventoryMaterials = new ObservableCollection<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 1 | p.CategoryId == 2 | p.CategoryId == 4))));

            InventoryFinishedProducts = new ObservableCollection<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 4))));

            Gold = _currentUser.Gold;
            Lvl = _currentUser.Lvl;


        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}