using HIMS.BL.Interfaces;
using HIMS.BL.Services;
using EmailDims = Email.Interfaces;
using EmailDimsService = Email.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;

namespace HIMS.Server.utils
{
    public class DependencesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISampleService>().To<SampleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IVUserProfileService>().To<VUserProfileService>();
            Bind<IUserProfileService>().To<UserProfileService>();
            Bind<IDirectionService>().To<DirectionService>();
            Bind<IProgressService>().To<ProgressService>();
            string apiKey = File.ReadAllText(ConfigurationManager.AppSettings["apiKey"]);
            Bind<EmailDims.IEmailService>().To<EmailDimsService.EmailService>()
            .InSingletonScope()
            .WithConstructorArgument("apiKey", apiKey)
            .WithConstructorArgument("email", ConfigurationManager.AppSettings["email"]);
        }
    }
}