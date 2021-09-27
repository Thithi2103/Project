using System;
using System.IO;
using DAL;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}

