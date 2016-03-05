namespace AceOfSpades
{
    [System.AttributeUsage(
        System.AttributeTargets.All,
        Inherited = false,
        AllowMultiple = false)]
    public class Experiment : System.Attribute
    {
        public Experiment(string name, Play play = Play.Deactivated)
        {
            this.Name = name;
            this.Play = play;
        }

        public string Name { get; }
        public Play Play { get; }
    }
}