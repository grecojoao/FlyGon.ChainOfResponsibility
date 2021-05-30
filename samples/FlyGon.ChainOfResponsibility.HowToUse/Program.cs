using FlyGon.ChainOfResponsibility.Handlers;
using System;
using System.Collections.Generic;

namespace FlyGon.ChainOfResponsibility.HowToUse
{
    class MonkeyHandler : Handler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Banana")
                return $"Monkey: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    class SquirrelHandler : Handler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Nut")
                return $"Squirrel: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    class DogHandler : Handler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "MeatBall")
                return $"Dog: I'll eat the {request}.\n";
            return base.Handle(request);
        }
    }

    class Client
    {
        public static void ClientCode(Handler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");
                var result = handler.Handle(food);
                if (result != null)
                    Console.Write($"   {result}");
                Console.WriteLine($"   {food} was left untouched.");
            }
        }
    }

    static class Program
    {
        static void Main()
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();
            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}