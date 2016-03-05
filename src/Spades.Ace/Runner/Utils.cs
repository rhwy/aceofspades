namespace AceOfSpades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using static System.Console;
    public static class Utils
    {
        public static T GetAttribute<T>(MethodInfo method) where T : Attribute
        => (T)method.GetCustomAttribute<T>();
        
        public static IEnumerable<T> GetAllAttributes<T>(MethodInfo method) where T : Attribute
        => method.GetCustomAttributes<T>();
        
        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<T>(this Assembly assembly) where T : Attribute
        => assembly
            .GetTypes()
            .SelectMany(
                type => type.GetMethods().Where(
                    method => method.GetCustomAttributes().Any(
                        attribute => attribute.GetType() == typeof(T))));
                        
        public static void DoForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list) {
                action(item);
            }
        }  
        
        public static IEnumerable<T> DoOnceIfAny<T>(this IEnumerable<T> me, Action<IEnumerable<T>> action)
        {
            if(me.Any())
                action(me);
            return me;
        } 
    }
    
    public static class ColorConsoleHelper
    {
        public static void Red(string message)
        {
           var actual = ForegroundColor;
           ForegroundColor = ConsoleColor.Red;
           Write(message);
           ForegroundColor = actual;
        }
    }		
}