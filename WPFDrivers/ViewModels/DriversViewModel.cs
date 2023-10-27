using Drivers.BLL.DTOs.Responses;
using Drivers.BLL.Managers;
using Drivers.BLL.Managers.Contracts;
using Drivers.DAL_EF.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDrivers.Commands;

namespace WPFDrivers.ViewModels
{
    public class DriversViewModel : ViewModelBase
    {
        public int DriverId {get; set;}
        public FullDriverResponceDTO DriverInfo { get; set;}

        //public IDriversManager _driversManager { get; set;}
        private readonly IServiceProvider _serviceProvider;


        public DriversViewModel(IServiceProvider serviceProvider)//IDriversManager drvmanager)
        {
            GetDriverCommand = new GetDriverCommand(this);
            DriverId = 2;
            _serviceProvider = serviceProvider;
        }

        public ICommand GetDriverCommand { get; private set; }

        public async Task GetFullInfoAboutDriverAsync(int DriverId) 
        {
            using (IServiceScope serviceScope = this._serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _driversManager = provider.GetRequiredService<IDriversManager>();
                try
                {
                    this.DriverInfo = await _driversManager.GetFullInfoAboutDriver(DriverId);
                    var x = 10;
                }
                catch (Exception ex)
                {
                    //this.logger.LogError(DateTime.UtcNow + "=>" + "Запит до БД... Щось пішло не так: " + ex.Message);
                    //MessageBox.Show(ex.Message, "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
