namespace _3
{
    abstract class IElephant
    {
        public abstract int GetWeight();
        public abstract int GetHeight();
        public abstract string GetHabitat();
        public abstract string GetLatinName();
        public abstract string GetDiet();
    }
    abstract class ILion
    {
        public abstract string GetFeatures();
        public abstract void CanMeet(IElephant elephant);
        public abstract string GetHabitat();
        public abstract string GetLatinName();
        public abstract string GetDiet();
    }
    class AfricanElephant : IElephant
    {
        public override int GetWeight()
        {
            return 7500;
        }
        public override int GetHeight()
        {
            return 4;
        }
        public override string GetHabitat()
        {
            return "Саваната на Африка";
        }
        public override string GetLatinName()
        {
            return "Loxodonta africana";
        }
        public override string GetDiet()
        {
            return "Тревопасен";
        }
    }
    class IndianElephant : IElephant
    {
        public override int GetWeight()
        {
            return 6000;
        }
        public override int GetHeight()
        {
            return 3;
        }
        public override string GetHabitat()
        {
            return "Тропически гори на Индия";
        }
        public override string GetLatinName()
        {
            return "Elephas maximus indicus";
        }
        public override string GetDiet()
        {
            return "Тревопасен";
        }
    }
    class AfricanLion : ILion
    {
        public override string GetFeatures()
        {
            return "Има голяма грива";
        }
        public override void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " може да срешне " + elephant.GetType().Name);
        }
        public override string GetHabitat()
        {
            return "Саваната на Африка";
        }
        public override string GetLatinName()
        {
            return "Panthera leo";
        }
        public override string GetDiet()
        {
            return "Месояден";
        }
    }
    class AsiaticLion : ILion
    {
        public override string GetFeatures()
        {
            return "Има малка грива";
        }
        public override void CanMeet(IElephant elephant)
        {
            Console.WriteLine(this.GetType().Name + " може да срешне " + elephant.GetType().Name);
        }
        public override string GetHabitat()
        {
            return "Гори на Индия";
        }
        public override string GetLatinName()
        {
            return "Panthera leo persica";
        }
        public override string GetDiet()
        {
            return "Месояден";
        }
    }
    abstract class IContinentalFactory
    {
        public abstract ILion CreateLion();
        public abstract IElephant CreateElephant();
    }
    class AfricanFactory : IContinentalFactory
    {
        public override ILion CreateLion()
        {
            return new AfricanLion();
        }
        public override IElephant CreateElephant()
        {
            return new AfricanElephant();
        }
    }
    class AsiaticFactory : IContinentalFactory
    {
        public override ILion CreateLion()
        {
            return new AsiaticLion();
        }
        public override IElephant CreateElephant()
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
            Console.WriteLine("Местообитание: " + elephant.GetHabitat());
            Console.WriteLine("Латинско наименование: " + elephant.GetLatinName());
            Console.WriteLine("Тип на хранене: " + elephant.GetDiet());
            Console.WriteLine(lion.GetType().Name + lion.GetFeatures());
            Console.WriteLine("Местообитание: " + lion.GetHabitat());
            Console.WriteLine("Латинско наименование: " + lion.GetLatinName());
            Console.WriteLine("Тип на хранене: " + lion.GetDiet());
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
