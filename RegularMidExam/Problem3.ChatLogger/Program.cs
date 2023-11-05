using System.Collections;
using System.Globalization;

namespace Problem3.ChatLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<string> all = new List<string>();
            while (message != "end")
            {
                string[] array = message.Split(' ');
                string command = array[0];
                if (command == "Chat")
                {
                    string msg = array[1];
                    all.Add(msg);
                }
                else if (command == "Delete")
                {
                    string msg = array[1];
                    all.Remove(msg);
                }
                else if (command == "Edit")
                {
                    string msg = array[1];
                    string edit = array[2];
                    for (int i = 0; i < all.Count; i++)
                    {
                        if (all[i] == msg)
                        {
                            all.Insert(i, edit);
                            all.RemoveAt(i+1);
                            break;
                        }
                    }
                }
                else if(command == "Pin")
                {
                    string msg = array[1];
                    for (int i = 0; i < all.Count; i++)
                    {
                        if (all[i] == msg)
                        {
                            all.Add(msg);
                            all.RemoveAt(i);
                            break;
                        }
                    }
                }
                else if (command == "Spam")
                {
                    string msg = "";
                    for (int i = 1;i < array.Length; i++)
                    {
                        msg = array[i];
                        all.Add(msg);
                    }
                }
                message = Console.ReadLine();
            }
            foreach(string m in all)
            {
                Console.WriteLine(m);
            }
        }
    }
}