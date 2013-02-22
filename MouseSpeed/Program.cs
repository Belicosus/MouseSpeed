using System;
using System.Runtime.InteropServices;

namespace MouseSpeedSwitcher
{
    class Program
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, UInt32 pvParam, UInt32 fWinIni);


        static void Main(string[] args)
        {
            Console.WriteLine("Choose input unit: ");
            Console.WriteLine("[1] Mouse");
            Console.WriteLine("[2] Touchpad");
            string x = Console.ReadLine();

            uint sens = 10;

            switch (x)
            {
                case "1":
                    sens = 5;
                break;

                case "2":
                    sens = 19;
                break;

                default:
                    Console.WriteLine("No valid input. Sensetivity set to default");
                    sens = 10;
                break;
            }

            try
            {
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, sens, 0);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Did not succed");
            }
        }
    }
}