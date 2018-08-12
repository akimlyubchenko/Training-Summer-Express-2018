﻿using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);

            
            Console.WriteLine($"InMemoryByByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);


            Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);

            Console.WriteLine($"InMemoryByBlockCopy() done. Total bytes: {InMemoryByBlockCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);

            Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);

            Console.WriteLine($"ByLineCopy() done. Total bytes: {ByLineCopy(source, destination)}");
            Console.ReadKey();
            ClearOutputFile(destination);

            Console.WriteLine(IsContentEquals(source, destination));
            Console.ReadKey();
            //etc
        }
    }
}
