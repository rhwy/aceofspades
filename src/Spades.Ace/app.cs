namespace AceOfSpades
{
    using Microsoft.Extensions.PlatformAbstractions;

    public class Program
    {
        IAppLogger logger;
        ApplicationConfiguration configuration;
        public void Main(params string[] args)
        {
            var debug =(args.Length > 0)? (args[0]=="debug") : false;
            if (debug) logger.Log(LogLevel.Info,"debug mode activated");
            logger.ShowDebug(debug);
            showProgramStartupInfo();
            
            var ace = new ExperimentGame(logger,configuration);
            ace.RunExperiments();
        }
        
         public Program(IApplicationEnvironment appEnv)
        {
            LoggerFactory.DefineDefaultLogger=()=> new ConsoleAppLogger();
            logger = LoggerFactory.GetLogger();
            
            configuration = new ApplicationConfiguration(
                logger:logger,
                experiment:PlatformServices.Default.Application.ApplicationName
            );
            logger.Log(LogLevel.Debug,"started in folder : {0}", appEnv.ApplicationBasePath);
        }
        
        void showProgramStartupInfo()
        {
            logger.Log(LogLevel.Debug,$@"
ApplicationName = {PlatformServices.Default.Application.ApplicationBasePath}
ApplicationName = {PlatformServices.Default.Application.ApplicationName}
ApplicationVersion = {PlatformServices.Default.Application.ApplicationVersion}
RuntimeFramework = {PlatformServices.Default.Application.RuntimeFramework}
RuntimeArchitecture = {PlatformServices.Default.Runtime.RuntimeArchitecture}
RuntimePath = {PlatformServices.Default.Runtime.RuntimePath}
RuntimeType = {PlatformServices.Default.Runtime.RuntimeType}
RuntimeVersion = {PlatformServices.Default.Runtime.RuntimeVersion}
            ");
        }
    /*OperatingSystem = {PlatformServices.Default.Runtime.OperatingSystem}
    OperatingSystemPlatform = {PlatformServices.Default.Runtime.OperatingSystemPlatform}
    OperatingSystemVersion = {PlatformServices.Default.Runtime.OperatingSystemVersion}
    " */      
    }
    
    public class ApplicationConfiguration
    {
        public IAppLogger Logger {get;}
        public string WatchedExperiment {get;}
        public ApplicationConfiguration(
            IAppLogger logger,
            string experiment
        )
        {
            Logger = logger;
            WatchedExperiment = experiment;
        }
    }
}