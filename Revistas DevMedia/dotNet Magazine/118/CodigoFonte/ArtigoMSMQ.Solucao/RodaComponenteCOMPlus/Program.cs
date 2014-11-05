using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;
using MyService;
using System.Messaging;

namespace RodaComponenteCOMPlus
{
    class Program
    {
        static void Main(string[] args)
        {

            //MyService.LuckyNumberGenerator gen = new MyService.LuckyNumberGenerator();
            //Console.WriteLine("Your lucky number is {0}",gen.GetLuckyNumber());
            LuckyNumberGenerator gen2 = new LuckyNumberGenerator();
            //gen.ImprimeResultado();
            gen2.ImprimeResultado();

            Console.ReadKey();

        }
    }
}

