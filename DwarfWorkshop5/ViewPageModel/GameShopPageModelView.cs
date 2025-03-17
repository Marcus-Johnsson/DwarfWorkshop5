using DwarfWorkshop5.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace DwarfWorkshop5.ViewPageModel
{
    class GameShopPageModelView : INotifyPropertyChanged
    {
        private readonly GamePageModelViews _gamePageModelViews;
        private readonly MyDbContext _mydb;
        

       


        private int _selectedQuantity;
        public int SelectedQuantity
        {
            get => _selectedQuantity;
            set
            {
                _selectedQuantity = value;
                OnPropertyChanged(nameof(SelectedQuantity));
            }
        }
        private string _selectedQuantityButtonText;
        public string SelectedQuantityButtonText
        {
            get => _selectedQuantityButtonText;
            set
            {
                _selectedQuantityButtonText = value;
                OnPropertyChanged(nameof(SelectedQuantityButtonText));
            }
        }
        public ICommand Get;
        public ICommand ChangeQuantityCommand { get; }
        public ICommand BuyProductCommand { get; }

        public GameShopPageModelView()
        {
            BuyProductCommand = new Command<Products>(OnBuyProduct);
        }

        private void ChangeQuantity()
        {
            if (SelectedQuantity == 1)
                SelectedQuantity = 5;
            else if (SelectedQuantity == 5)
                SelectedQuantity = 10;
            else if (SelectedQuantity == 10)
                SelectedQuantity = 25;
            else if (SelectedQuantity == 25)
                SelectedQuantity = int.MaxValue;
            else
                SelectedQuantity = 1;

            SelectedQuantityButtonText = SelectedQuantity == int.MaxValue ? "Max" : SelectedQuantity.ToString();
        }
        private void OnBuyProduct(Products product)
        {
            //Gold Logic add inventory
            if(product == null)
            {  return; }
            if()  // user amount of gold >= product price * SelectedQuantity fix inventory bla bla and make one for sell 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}