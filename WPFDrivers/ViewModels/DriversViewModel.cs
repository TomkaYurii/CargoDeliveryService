using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDrivers.Commands;

namespace WPFDrivers.ViewModels
{
    public class DriversViewModel : ViewModelBase
    {
        public int DriverId {get; set;}
        public FullDriverResponceDTO DriverInfo { get; set;}

        public IDriversManager _driversManager { get; set;}
        

        public DriversViewModel(IDriversManager drvmanager)
        {
            GetDriverCommand = new GetDriverCommand(this);
            DriverId = 2;
            _driversManager = drvmanager;
        }

        public ICommand GetDriverCommand { get; private set; }

        public async Task GetFullInfoAboutDriverAsync(int DriverId) 
        {
            DriverInfo = await _driversManager.GetFullInfoAboutDriver(DriverId);
            var x = 10;
        }
    }
}
