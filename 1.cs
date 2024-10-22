using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    interface IElephant
    {
        int GetWeight();
        int GetHeight();
    }
    interface ILion
    {
        string GetFeatures();
        void CanMeet(IElephant elephant);
    }
    class AfricanElephant : IElephant
    {
        public int GetWeight()
        {
            return 7500;
        }
        public int GetHeight()
        {
            return 4;
        }
    }
    class IndianElephant : IElephant
    {
        public int GetWeight()
        {
            return 6000;
        }
        public int GetHeight()
        {
            return 3;
        }
    }
    class AfricanLion : ILion
    {
        public string GetFeatures()
        {
            return "Има голяма грива";
        }
        public void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " може да срешне " + elephant.GetType().Name);
        }
    }
    class AsiaticLion : ILion
    {
        public string GetFeatures()
        {
            return "Има малка грива";
        }
        public void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " може да срешне " + elephant.GetType().Name);
        }
    }
    interface IContinentalFactory
    {
        ILion CreateLion();
        IElephant CreateElephant();
    }
    class AfricanFactory : IContinentalFactory
    {
        public ILion CreateLion()
        {
            return new AfricanLion();
        }
        public IElephant CreateElephant()
        {
            return new AfricanElephant();
        }
    }
    class AsiaticFactory : IContinentalFactory
    {
        public ILion CreateLion()
        {
            return new AsiaticLion();
        }
        public IElephant CreateElephant()
        {
            return new IndianElephant();
        }
    }
    class Client
    {
        private ILion lion;
        private IElephant elephant;
        public Client(IContinentalFactory factory)
        {
            lion = factory.CreateLion();
            elephant = factory.CreateElephant();
        }
        public void Run()
        {
            Console.WriteLine(elephant.GetType().Name + " тежи " + elephant.GetWeight() + "кг");
            Console.WriteLine(elephant.GetType().Name + " е висок " + elephant.GetHeight() + "м");
            Console.WriteLine(lion.GetType().Name + lion.GetFeatures());
            lion.CanMeet(elephant);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IContinentalFactory factory1 = new AfricanFactory();
            Client client1 = new Client(factory1);
            client1.Run();

            IContinentalFactory factory2 = new AsiaticFactory();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }
}