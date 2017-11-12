using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;


namespace IsolatedStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
                IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStore);

                StreamWriter userWriter = new StreamWriter(userStream);
                userWriter.WriteLine("User Prefs");
                userWriter.Close();

                string[] files = userStore.GetFileNames("UserSettings.set");
                if (files.Length == 0)
                {
                    Console.WriteLine("No files found");
                }
                else
                {
                    userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore);
                    StreamReader userReader = new StreamReader(userStream);
                    string contents = userReader.ReadToEnd();
                    Console.WriteLine(contents);
                    Console.ReadKey();
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
