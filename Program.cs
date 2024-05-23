namespace adapter_pattern
{
    //A demonstration of the Adapter / Wrapper pattern in C#
    public class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            //Adaptee interface is incompatible with the client, but with the Adapter, the client can call it's method

            Console.WriteLine(target.GetRequest());
        }

        //ITarget defines the domain-specific interface used by the client code
        public interface ITarget
        {
            public string GetRequest();
        }

        //Adaptee contains some useful behavior, but its interface is incompatible with the existing client code.
        //The Adaptee needs some adaptation before the client code can use it
        public class Adaptee
        {
            public string GetSpecificRequest()
            {
                return "Specific request";
            }
        }

        //Adapter makes the Adaptee's interface compatible with the Target's interface
        class Adapter : ITarget
        {
            private readonly Adaptee adaptee;

            public Adapter(Adaptee adaptee)
            {
                this.adaptee = adaptee;
            }

            public string GetRequest()
            {
                return $"{this.adaptee.GetSpecificRequest()}";
            }
        }
    }
}
