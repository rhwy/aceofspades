namespace AceOfSpades
{
    using System;
    using static System.Console;
    
    public enum LogLevel { Info, Warning, Error, Fatal, Debug }
    public interface IAppLogger
    {
        void Log(LogLevel level, string template, params object[] args);
        void ShowDebug(bool value);
    }
    
    public static class LoggerFactory
    {
        private static Func<IAppLogger> buildDefaultLogger = ()=>new ConsoleAppLogger();
        public static Func<IAppLogger> DefineDefaultLogger {set{buildDefaultLogger=value;}}
        public static Func<IAppLogger> GetLogger => buildDefaultLogger;
    }
    
    public class ConsoleAppLogger : IAppLogger
    {
        private bool showDebug = false;
        public void Log(LogLevel level, string template, params object[] args)
        {
            var currentColor = ForegroundColor;
            bool show = true;
            
            switch (level)
            {
                case LogLevel.Info:
                    show = true;
                    ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Warning:
                    show = true;
                    ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    show = true;
                    ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Fatal:
                    show = true;
                    ForegroundColor = ConsoleColor.Magenta;
                    break;
                case LogLevel.Debug:
                    show = showDebug;
                    ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }
            if(show)
                WriteLine(template, args);
                
            ForegroundColor=currentColor;
        }
        
        public void ShowDebug(bool value)
        => showDebug = value;
    }
}