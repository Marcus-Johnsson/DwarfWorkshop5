using DwarfWorkhop5;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using DwarfWorkshop5.ViewPageModel;

namespace DwarfWorkshop5.DesignPattern
{
     interface ICommand
    {

        void Execute();

    }


     class ButtonHandler
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
        private readonly UserSession _session;


  
        private readonly GamePageModelViews _viewModel;
        public BuyDwarfShopCommand(MyDbContext mydb, GamePageModelViews viewModel)
        {
            _mydb = mydb;
            _viewModel = viewModel;
            _session = UserSession.GetInstance();
           
        }

        public void Execute()
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
        private readonly UserSession _session;

       
        public BuyUserLvl(MyDbContext mydb, GamePageModelViews viewModel)
        {
            _mydb = mydb;
            _viewModel = viewModel;
            _session = UserSession.GetInstance();
        }

        public void Execute()
        {
            var currentUser = _session.GetCurrentUser();
            var UserSaveInfo = _mydb.User.FirstOrDefault(u => u.Id == currentUser.Id);  


            if (UserSaveInfo.TokenAmount < 2 * currentUser.Lvl)
            {

            }
            else
            {
                UserSaveInfo.TokenAmount -= 2 * currentUser.Lvl;
                _viewModel.Token = UserSaveInfo.TokenAmount;
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


