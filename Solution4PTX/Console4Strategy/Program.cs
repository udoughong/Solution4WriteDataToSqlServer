using System;
using System.Collections.Generic;
using System.IO;

namespace Console4Strategy
{
    public interface IPassengerTypeStrategy
    {
        void ImplementCase();
    }

    public class DrPassengerTypeStrategy : IPassengerTypeStrategy
    {
        public void ImplementCase()
        {
            Console.WriteLine("I am a Doctor.");
        }
    }

    public class MrPassengerTypeStrategy : IPassengerTypeStrategy
    {
        public void ImplementCase()
        {
            Console.WriteLine("I am a Mr.");
        }
    }

    public class MrsPassengerTypeStrategy : IPassengerTypeStrategy
    {
        public void ImplementCase()
        {
            Console.WriteLine("I am a Mrs.");
        }
    }

    public enum PassengerType
    {
        Mr,
        Mrs,
        Dr,
    }

    public class Context
    {
        private static readonly Dictionary<PassengerType, IPassengerTypeStrategy> strategiesDictionary 
            = new();

        static Context()
        {
            strategiesDictionary.Add(PassengerType.Mr, new MrPassengerTypeStrategy());
            strategiesDictionary.Add(PassengerType.Mrs, new MrsPassengerTypeStrategy());
            strategiesDictionary.Add(PassengerType.Dr, new DrPassengerTypeStrategy());
        }

        public static void ImplementCase(PassengerType type)
        {
            strategiesDictionary[type].ImplementCase();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PassengerType type1 = PassengerType.Dr;
            Console.WriteLine("PassengerType type = PassengerType.Dr;");
            Context.ImplementCase(type1);
            PassengerType type2 = PassengerType.Mr;
            Console.WriteLine("PassengerType type = PassengerType.Mr;");
            Context.ImplementCase(type2);
            PassengerType type3 = PassengerType.Mrs;
            Console.WriteLine("PassengerType type = PassengerType.Mrs;");
            Context.ImplementCase(type3);
            Console.ReadLine();
        }
    }
}
