[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DocumentSearcher.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DocumentSearcher.App_Start.NinjectWebCommon), "Stop")]

namespace DocumentSearcher.App_Start
{
    using System;
    using System.Configuration;
    using System.Web;
    using DocumentSearcher.Models.DatabaseAccess;
    using DocumentSearcher.Models.DatabaseAccess.MongoRepositoryImpl;
    using DocumentSearcher.Models.DatabaseAccess.RepositoryInterface;
    using Iveonik.Stemmers;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MongoDB.Driver;
    using Ninject;
    using Ninject.Web.Common;
    using SearchCore.TextProcessors.Implementation;
    using SearchCore.TextProcessors.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var database = MongoDbInitializer.Init();
            kernel.Bind<MongoDatabase>().ToConstant(database);

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IIndexedDocumentRepository>().To<IndexedDocumentRepository>();

            kernel.Bind<ITokenizer>().To<TextTokenizer>();
            kernel.Bind<IStopWordsProvider>().To<RusStopWordsProvider>();
            kernel.Bind<IStemmer>().To<RussianStemmer>();
            kernel.Bind<IWordCounter>().To<WordCounter>();
            kernel.Bind<SearchCore.TextProcessors.DocumentIndexator>().ToSelf();
            kernel.Bind<SearchCore.SearchHelpers.RelevancyCounter>().ToSelf();
        }

        public static IKernel GetKernel()
        {
            return bootstrapper.Kernel;
        }
    }
}
