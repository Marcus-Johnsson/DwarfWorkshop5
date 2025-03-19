using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DwarfWorkshop5.ViewPageModel
{
    public partial class GamePageModelViews : INotifyPropertyChanged 
    {
        private User? _currentUser;
        private readonly UserSession _session;
        private readonly MyDbContext _mydb;
        public GamePageModelViews(MyDbContext dbContext)
        {
            _mydb = dbContext;
            _session = UserSession.GetInstance();
            LoadData();
            SelectDwarfCommand = new Command<Dwarfs>(OnSelectDwarf);
            ChangeRecipeCommand = new AsyncRelayCommand<object>(OnChangeRecipe);


        }
        public class ProductWithCost
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public int? RecipeId { get; set; }
            public List<MaterialCost> Materials { get; set; } = new();
        }

        public class MaterialCost
        {
            public int MaterialId { get; set; }
            public int Quantity { get; set; }
        }


        private List<Products> _shopGems = new();
        public List<Products> ShopGems => _shopGems;


        private List<Products> _shopOre = new();
        public List<Products> ShopOre => _shopOre;

        public ObservableCollection<Dwarfs> Dwarf { get; private set; } = new ObservableCollection<Dwarfs>();

        Dwarfs unlockedDwarfs;
        public Dwarfs UnlockedDwarfs
        {
            get
            {
                return unlockedDwarfs;
            }
            set
            {
                if (unlockedDwarfs != value)
                {
                    unlockedDwarfs = value;
                }
            }
        }
        private List<Inventory> _inventoryFinishedProducts = new();
        public List<Inventory> InventoryFinishedProducts => _inventoryFinishedProducts;

        private List<Inventory> _inventoryMaterials = new();
        public List<Inventory> InventoryMaterials => _inventoryMaterials;

        private ProductWithCost _pickerProduct;
        public ProductWithCost PickerProduct
        {
            get { return _pickerProduct; }
            set
            {
                if (_pickerProduct != value)
                {
                    _pickerProduct = value;
                    OnPropertyChanged(nameof(PickerProduct));
                }
            }
        }

        private List<ProductWithCost> _availableRecipe;
        public List<ProductWithCost> AvailableRecipe
        {
            get => _availableRecipe;
            set
            {
                if (_availableRecipe != value)
                {
                    _availableRecipe = value;
                    OnPropertyChanged(nameof(AvailableRecipe));
                }
            }
        }
        public ICommand SelectDwarfCommand { get; }

        public ICommand ChangeRecipeCommand { get; }

        private async Task OnChangeRecipe(object recipe)
        {
            if (recipe != null)
            {
                var availableRecipe = await GetAvailableRecipe(); // Get the list of products with costs

                if (availableRecipe != null)
                {
                    _availableRecipe = availableRecipe; 
                    OnPropertyChanged(nameof(AvailableRecipe));

                }
            }
        }

        private void OnBuyUserLvl()
        {

        }
        private void OnSelectDwarf(Dwarfs selectedDwarf)
        {
            if (selectedDwarf != null)
            {
                SelectedDwarf = selectedDwarf;
            }
        }

        public async Task<List<ProductWithCost>> GetAvailableRecipe()
        {
            var currentUser = _session.GetCurrentUser();
            var availableRecipes = await _mydb.Products
                .Where(p => p.LvlRequirement <= currentUser.Lvl && p.RecipeId != null)
                .Select(p => new ProductWithCost
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    RecipeId = p.RecipeId,
                    Materials = p.RecipeId != null
                        ? _mydb.Recipes
                            .Where(r => r.Id == p.RecipeId)
                            .SelectMany(r => r.MaterialsRequired)
                            .Select(m => new MaterialCost
                            {
                                MaterialId = m.MaterialId,
                                Quantity = m.Quantity
                            }).ToList()
                        : new List<MaterialCost>() // No materials if no recipe
                })
                .ToListAsync();

            return availableRecipes; // Return the complete list
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

        [RelayCommand]
        public async Task BuyDwarf()
        {
            var currentUser = _mydb.User.Where(p => p.Id == _session.GetCurrentUser().Id).SingleOrDefault();
            var userDwarf = _mydb.Dwarfs.FirstOrDefault(p => p.UserId == currentUser.Id && p.Unlocked == false);

            if (userDwarf == null || currentUser == null || currentUser.TokenAmount < 2)
            {

            }
            else
            {
                currentUser.TokenAmount -= 2;
                userDwarf.Unlocked = true;
                OnPropertyChanged(nameof(Dwarf));
                Token = currentUser.TokenAmount;
                _mydb.SaveChanges();

            }
        }

        [RelayCommand]
        private async Task BuyProduct(Products products)
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
        [RelayCommand]
        private async Task BuyUserLvl()
        {
            if (Token >= _currentUser.Lvl * 2)
            {
                var currentUser = _mydb.User.Where(p => p.Id == _currentUser.Id).SingleOrDefault();
                currentUser.Lvl++;
                currentUser.TokenAmount = -currentUser.Lvl * 2;
            }

        }


        private Dwarfs _selectedDwarf;
        public Dwarfs SelectedDwarf
        {
            get => _selectedDwarf;
            set
            {
                _selectedDwarf = value;
                OnPropertyChanged(nameof(SelectedDwarf));
                OnPropertyChanged(nameof(QualityPrice));
                OnPropertyChanged(nameof(WorkSpeedCost));
                OnPropertyChanged(nameof(QualityChance));
                OnPropertyChanged(nameof(WorkSpeed));
                OnPropertyChanged(nameof(RankUpgrade));
            }
        }

        public double QualityChance => SelectedDwarf != null &&
                               SelectedDwarf.QualityRank >= 1
                               ? Math.Round(0.01 + (100 * 0.00025 * (1 + 0.05 * SelectedDwarf.QualityRank)), 2)
                               : 0.0;

        public double QualityPrice => SelectedDwarf != null ? 200 *
                            Math.Pow(1.08, SelectedDwarf.QualityRank) : 200;

        public int RankUpgrade => SelectedDwarf != null ? SelectedDwarf.Rank * 2 : 2;

        //          Work Speed(1×(1+WorkSpeedIncreaseRate×EffifencyRank)×(1+0.05×Rank))
        public double WorkSpeed => SelectedDwarf != null && SelectedDwarf.EffifencyRank == 1
                           ? Math.Round((1 + WorkSpeedIncreaseRate * SelectedDwarf.EffifencyRank)
                                        * (1 + 0.05 * SelectedDwarf.Rank - 1), 2)
                           : 1;

        private const double InitialWorkSpeedCost = 100; // Adjust this base cost if needed

        private const double WorkSpeedIncreaseRate = 0.05; // Adjust as needed

        private const double WorkSpeedCostRate = 0.1; // Adjust as needed
        public double WorkSpeedCost => SelectedDwarf != null
                               ? Math.Round(InitialWorkSpeedCost * Math.Pow
                                            (1 + WorkSpeedCostRate, Math.Max(0, SelectedDwarf.EffifencyRank - 1)), 2)
                               : Math.Round(InitialWorkSpeedCost, 2);


        public async void LoadData()
        {
            var currentUser = _session.GetCurrentUser();

            var shopGemsList = await _mydb.Products.Where(p => p.CategoryId == 3 && p.LvlRequirement <= currentUser.Lvl).ToListAsync();

            _shopGems = new List<Products>(shopGemsList);

            var shopOreList = await _mydb.Products.Where(p => p.CategoryId == 1 && p.LvlRequirement <= currentUser.Lvl).ToListAsync();

            _shopOre = new List<Products>(shopOreList);

            var dwarfs = _mydb.Dwarfs.Where(p => p.UserId == currentUser.Id).ToList();
            Dwarf = new ObservableCollection<Dwarfs>(dwarfs);

            var userInventory = _mydb.Inventory              // material list category 1,2,3 and 4 finished product
               .Where(inv => currentUser.Id == inv.UserId)
               .ToList();

            var recipeAvailable = _mydb.Recipes
                .Where(r => _mydb.Products
                    .Any(p => p.Id == r.ProductId && p.LvlRequirement <= currentUser.Lvl))
                .ToList();
            _inventoryMaterials = new List<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 1 | p.CategoryId == 2 | p.CategoryId == 4))));

            _inventoryFinishedProducts = new List<Inventory>
                                    (userInventory.Where(i => _mydb.Products
                                    .Any(p => p.Id == i.ProductId && (p.CategoryId == 4))));

            Gold = currentUser.Gold;
            Lvl = currentUser.Lvl;
            Token = currentUser.TokenAmount;
            OnPropertyChanged(nameof(ShopGems));
            OnPropertyChanged(nameof(ShopOre));
            OnPropertyChanged(nameof(Dwarf));

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}