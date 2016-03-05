namespace AceOfSpades
{
    [System.AttributeUsage(
        System.AttributeTargets.All,
        Inherited = false,
        AllowMultiple = true)]
    public class Values : System.Attribute
    {
        public Values(params object[] args)
        {
            this.Args = args;
        }
        public object[] Args { get; }
    }
}