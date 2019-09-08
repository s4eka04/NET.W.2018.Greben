using DAL.Interface.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// using Ninject to inject dependencies
        /// </summary>
        public override void Load()
        {
            
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IAccountNumberCreateSevice>().To<AccountNumberCreateSevice>();
        }
    }
}
