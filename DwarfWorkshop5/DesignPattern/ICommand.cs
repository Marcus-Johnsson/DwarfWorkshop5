using DwarfWorkhop5;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.ViewPageModel;

namespace DwarfWorkshop5.DesignPattern
{
    public interface ICommand
    {

        void Execute();

    }


    public class ButtonHandler
    {
        private readonly ICommand _command;

        public ButtonHandler(ICommand command)
        {
            _command = command;
        }

        public void OnClick()
        {
            _command.Execute();
        }
    }



    public class BuyDwarfShopCommand : ICommand
    {
        private readonly MyDbContext _mydb;
        private readonly GamePageModelViews _viewModel;
        public BuyDwarfShopCommand(MyDbContext mydb, GamePageModelViews viewModel)
        {
            _mydb = mydb;
            _viewModel = viewModel;
        }

        public void Execute()
        {
            var currentUser = _mydb.User.FirstOrDefault(u => u.Id == GetSetData.GetCurrentUser().Id);
            var userDwarf = _mydb.Dwarfs.FirstOrDefault(p => p.UserId == currentUser.Id && p.Unlocked == false);

            if (userDwarf == null || currentUser == null || currentUser.TokenAmount < 2)
            {

            }
            else
            {
                currentUser.TokenAmount -= 2;
                userDwarf.Unlocked = true;
                _viewModel.UnlockedDwarfs.Add(userDwarf);
                _viewModel.Token = currentUser.TokenAmount;
                _mydb.SaveChanges();

            }
        }
    }
    public class BuyUserLvl : ICommand
    {
        private readonly MyDbContext _mydb;
        private readonly GamePageModelViews _viewModel;
        public BuyUserLvl(MyDbContext mydb, GamePageModelViews viewModel)
        {
            _mydb = mydb;
            _viewModel = viewModel;
        }

        public void Execute()
        {
            var currentUser = _mydb.User.FirstOrDefault(u => u.Id == GetSetData.GetCurrentUser().Id);


            if (currentUser.TokenAmount < 2 * currentUser.Lvl)
            {

            }
            else
            {
                currentUser.TokenAmount -= 2 * currentUser.Lvl;
                _viewModel.Token = currentUser.TokenAmount;
                _mydb.SaveChanges();

            }
        }
    }
    //public class UpgradeDwarfsCommand : ICommand<Task>
    //{
    //    public Task<Task> Execute()
    //    {

    //        return ;
    //    }
    //}
    //public class BuyProductShopCommand : ICommand<Task>
    //{
    //    public Task Execute()
    //    {
    //        // Logic to show Inventory Ore

    //    }

    //}
    //public class SellProductCommand : ICommand<Task>
    //{
    //    public Task Execute()
    //    {
    //        // Logic to show Inventory Ore

    //    }
    //}
    //public class ChangeRecipeCommand : ICommand<Task>
    //{
    //    public Task Execute()
    //    {
    //        // Logic to show Inventory Ore

    //    }
    //}
}


