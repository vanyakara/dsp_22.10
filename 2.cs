namespace test
{
    interface IElephant
    {
        int GetWeight();
        int GetHeight();
        string GetHabitat();
        string GetLatinName();
        string GetDiet();
    }
    interface ILion
    {
        string GetFeatures();
        void CanMeet(IElephant elephant);
        string GetHabitat();
        string GetLatinName();
        string GetDiet();
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
        public string GetHabitat() {
            return "Саваната на Африка";
        }
        public string GetLatinName() {
            return "Loxodonta africana";
        }
        public string GetDiet() {
            return "Тревопасен";
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
        public string GetHabitat() {
            return "Тропически гори на Индия";
        }
        public string GetLatinName() {
            return "Elephas maximus indicus";
        }
        public string GetDiet() {
            return "Тревопасен";
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
        public string GetHabitat()
        {
            return "Саваната на Африка";
        }
        public string GetLatinName()
        {
            return "Panthera leo";
        }
        public string GetDiet() {
            return "Месояден";
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
        public string GetHabitat() {
            return "Гори на Индия";
        }
        public string GetLatinName() {
            return "Panthera leo persica";
        }
        public string GetDiet()
        {
            return "Месояден";
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
            Console.WriteLine("Местообитание: " + elephant.GetHabitat());
            Console.WriteLine("Латинско наименование: " + elephant.GetLatinName());
            Console.WriteLine("Тип на хранене: " + elephant.GetDiet());
            Console.WriteLine(lion.GetType().Name + lion.GetFeatures());
            Console.WriteLine("Местообитание: " + lion.GetHabitat());
            Console.WriteLine("Латинско наименование: "+lion.GetLatinName());
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