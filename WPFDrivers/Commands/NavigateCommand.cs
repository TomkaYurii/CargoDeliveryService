using Drivers.BLL.Contracts;
using Drivers.BLL.Managers;
using WPFDrivers.ViewModels;

namespace WPFDrivers.Commands;

public class NavigateCommand : CommandBase
{
    private readonly MainViewModel _mainViewModel;
    private readonly IDriversManager _driversManager;

    public enum ViewType
    {
        Login,
        Drivers
    }


    public NavigateCommand(MainViewModel mainViewModel,
        IDriversManager driversManager)
    {
        _mainViewModel = mainViewModel;
        _driversManager = driversManager;
    }

    public override void Execute(object parameter)
    {
        if (parameter is ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Drivers:
                    _mainViewModel.CurrentVM = new DriversViewModel(_driversManager);
                    break;
                default:
                    break;
            }
        }
    }
}
