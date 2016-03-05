
namespace AceOfSpades
{
    using System;
    using System.Reflection;
    using System.Linq;

    using static Utils;
    using static System.Console;
    using static EscapedConsole.Codes.Color;
    using System.Collections.Generic;

    public class ExperimentGame
    {
        public void RunExperiments()
        {
            Assembly
            .GetExecutingAssembly()
            .GetMethodsWithAttribute<Experiment>()
            .DoOnceIfAny(ClearAndWriteHeader)
            .DoForEach(method =>
            {
                var experience = GetAttribute<Experiment>(method);
                
                if (experience.Play == Play.Now)
                {
                    var values = GetAllAttributes<Values>(method);
                    string message = $@"[{Green}{experience.Name}{Reset}] {Grey}(on {method.DeclaringType.Name}.{method.Name}){Reset}";

                    WriteLine(message);
                    WriteLine(new String('-', BufferWidth));
                    
                    if (values.Any())
                    {
                        int count=0;
                        foreach (var item in values)
                        {
                            count++;
                            WriteLine($"{Green}[{count:00}]{Reset}.{Yellow}[{string.Join(",",item.Args)}]{Reset}");
                            method.Invoke(Activator.CreateInstance(method.DeclaringType), item.Args);
                            WriteLine("");
                        }
                    }
                    else
                    {
                        WriteLine($"{Purple} --- (no values) --- {Reset}");
                        method.Invoke(Activator.CreateInstance(method.DeclaringType), null);
                        WriteLine("");
                    }
                    WriteLine(new String('-', BufferWidth));
                
                }
            });
        }
        
        private void RunnableExperiment(MethodInfo method, Experiment experiment)
        {
            var values = GetAllAttributes<Values>(method);
            string message = $@"[{Green}{experiment.Name}{Reset}] {Grey}(on {method.DeclaringType.Name}.{method.Name}){Reset}";

            WriteLine(message);
            WriteLine(new String('-', BufferWidth));
            
            if (values.Any())
            {
                int count=0;
                foreach (var item in values)
                {
                    count++;
                    WriteLine($"{Green}[{count:00}]{Reset}.{Yellow}[{string.Join(",",item.Args)}]{Reset}");
                    method.Invoke(Activator.CreateInstance(method.DeclaringType), item.Args);
                    WriteLine("");
                }
            }
            else
            {
                WriteLine($"{Purple} --- (no values) --- {Reset}");
                method.Invoke(Activator.CreateInstance(method.DeclaringType), null);
                WriteLine("");
            }
            WriteLine(new String('-', BufferWidth));
                
        }
        private void ClearAndWriteHeader(IEnumerable<MethodInfo> list)
        {
            Clear();
            int total = list.Count();
            int playable = list.Count(m => GetAttribute<Experiment>(m).Play==Play.Now);
            string message = $@"Found {Blue} {total}{Reset} Experiments, {Blue} {playable}{Reset} running";
            WriteLine(new String('-', BufferWidth-1));
            WriteLine(message);
            WriteLine(new String('-', BufferWidth-1));  
        }
    }
}