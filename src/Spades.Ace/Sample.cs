namespace AceOfSpades
{
    using System;
    
    using static System.Console;
    
    public class MyFirstExperiments
    {
        [Experiment("First experiment", Play.Later)]
        public void Test1()
        {
            WriteLine($"this my 1st experiment at {DateTime.Now}");
            WriteLine($"(now deactive this by changing the param 'Play.Now' to 'Play.Later' and go to next experiment)");
        }

        [Values("Donald", 3,"nephews")]
        [Values("Mickey", 1,"dog")]
        [Experiment("Second, we play with values", Play.Now)]
        public void Test2(string name, int number, string youhave)
        {
            WriteLine($"your name is {name} and you have {number} {youhave}");
        }
    }
}