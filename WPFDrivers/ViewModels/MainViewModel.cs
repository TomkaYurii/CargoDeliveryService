using Drivers.BLL.Contracts;
using System.Windows.Input;
using WPFDrivers.Commands;
using static WPFDrivers.Commands.NavigateCommand;

namespace WPFDrivers.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand NavigateCommand { get; set; }

    private readonly IDriversManager _driversManager;

    public MainViewModel(IDriversManager driversManager)
    {
        _driversManager = driversManager;
        NavigateCommand = new NavigateCommand(this, _driversManager);
        NavigateCommand.Execute(ViewType.Drivers);
    }

    public ViewModelBase CurrentVM { get; set; }
    public DriversViewModel DriversVM { get; set; }


}
