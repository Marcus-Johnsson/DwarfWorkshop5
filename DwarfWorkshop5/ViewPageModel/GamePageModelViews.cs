using CommunityToolkit.Mvvm.Input;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.WebUI;

namespace DwarfWorkshop5.ViewPageModel
{
    public partial class GamePageModelViews : INotifyPropertyChanged
    {
        public GamePageModelViews(MyDbContext dbContext)
        {
            _mydb = dbContext;
            _session = UserSession.GetInstance();
            LoadData();
            SelectDwarfCommand = new Command<Dwarfs>(OnSelectDwarf);
            ChangeRecipeCommand = new Command<int>(ChangeRecipe);

        }

        private readonly UserSession _session;
        private User? _currentUser;
        private readonly MyDbContext _mydb;

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
        public ICommand SelectDwarfCommand { get; }

        public ICommand ChangeRecipeCommand { get; }


        private void OnSelectDwarf(Dwarfs selectedDwarf)
        {
            if (selectedDwarf != null)
            {
                SelectedDwarf = selectedDwarf;
            }
        }

        private List<Inventory> _inventoryFinishedProducts = new();
        public List<Inventory> InventoryFinishedProducts => _inventoryFinishedProducts;

        private List<Inventory> _inventoryMaterials = new();
        public List<Inventory> InventoryMaterials => _inventoryMaterials;



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
                                       SelectedDwarf.QualityRank >= 1 ? 0.01 + (100 * 0.00025 *
                                       (1 + 0.05 * SelectedDwarf.QualityRank)) : 0.0;

        public double QualityPrice => SelectedDwarf != null ? 200 *
                            Math.Pow(1.08, SelectedDwarf.QualityRank) : 200;

        public int RankUpgrade => SelectedDwarf != null ? SelectedDwarf.Rank * 2 : 2;

        //          Work Speed(1×(1+WorkSpeedIncreaseRate×EffifencyRank)×(1+0.05×Rank))
        public double WorkSpeed => SelectedDwarf != null ? (1 + WorkSpeedIncreaseRate * SelectedDwarf.EffifencyRank)
                                    * (1 + 0.05 * SelectedDwarf.Rank) : 1;

        private const double InitialWorkSpeedCost = 100; // Adjust this base cost if needed

        private const double WorkSpeedIncreaseRate = 0.05; // Adjust as needed

        private const double WorkSpeedCostRate = 0.1; // Adjust as needed
        public double WorkSpeedCost => SelectedDwarf != null? Math.Round
                                                (InitialWorkSpeedCost * Math.Pow
                                                (1 + WorkSpeedCostRate, Math.Max
                                                (0, SelectedDwarf.EffifencyRank - 1)))
                                                : InitialWorkSpeedCost;
        [RelayCommand]
        private void ChangeRecipe(int slot)
        {
            // Open the Picker and let the user select a new recipe
            var selectedRecipe = OpenRecipePicker();

            if (selectedRecipe != null)
            {
                // Assign the selected recipe (ProductId) to the appropriate slot
                switch (slot)
                {
                    case 1:
                        SelectedDwarf.SelectedRecipe1 = selectedRecipe.ProductId;
                        break;
                    case 2:
                        SelectedDwarf.SelectedRecipe2 = selectedRecipe.ProductId;
                        break;
                    case 3:
                        SelectedDwarf.SelectedRecipe3 = selectedRecipe.ProductId;
                        break;
                }
            }
        }


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


        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}