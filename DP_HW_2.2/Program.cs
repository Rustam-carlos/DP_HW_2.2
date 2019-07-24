using System;

namespace DP_HW_2._2
{
    public interface IComputerFactory
    {
        IMainboard CreateMainboard();
        IProcessor CreateProcessor();
    }

    class Dell : IComputerFactory
    {
        public IMainboard CreateMainboard()
        {
            return new DellMainboard();
        }
        public IProcessor CreateProcessor()
        {
            return new DellProcessor();
        }
    }

    class Sony : IComputerFactory
    {
        public IMainboard CreateMainboard()
        {
            return new SonyMainboard();
        }

        public IProcessor CreateProcessor()
        {
            return new SonyProcessor();
        }
    }

    public interface IMainboard
    {
        string ShowMessage();
    }

    class DellMainboard : IMainboard
    {
        public string ShowMessage()
        {
            return "Dell материнская плата тех описание";
        }
    }

    class SonyMainboard : IMainboard
    {
        public string ShowMessage()
        {
            return "Sony материнская плата тех описание";
        }
    }

    public interface IProcessor
    {
        string ShowProcessor();
        string ShowProcessorStation(IMainboard collaborator);
    }

    class DellProcessor : IProcessor
    {
        public string ShowProcessor()
        {
            return "Процессор Dell 6 ядер";
        }

        public string ShowProcessorStation(IMainboard device)
        {
            var result = device.ShowMessage();

            return $"({result}): установлен";
        }
    }

    class SonyProcessor : IProcessor
    {
        public string ShowProcessor()
        {
            return "Процессор Sony 8 ядер";
        }

        public string ShowProcessorStation(IMainboard device)
        {
            var result = device.ShowMessage();

            return $"({result}): установлен";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Тестирование кода клиента с первым типом фабрики...");
            ClientMethod(new Dell());
            Console.WriteLine();

            Console.WriteLine("Client: Тестирование того же клиентского кода со вторым типом фабрики...");
            ClientMethod(new Sony());
        }

        public void ClientMethod(IComputerFactory factory)
        {
            IMainboard mainboard = factory.CreateMainboard();
            IProcessor processor = factory.CreateProcessor();

            Console.WriteLine(processor.ShowProcessor());
            Console.WriteLine(processor.ShowProcessorStation(mainboard));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
            Console.ReadKey();
        }
    }
}
