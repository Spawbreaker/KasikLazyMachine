using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration; 


namespace KasikLazyMachine
{
    class Program
    {       
        static void Main(string[] args)
        {
            string gw2dir = ConfigurationSettings.AppSettings["gw2dir"];
            Console.WriteLine("Welcome to the Kasik Lazy Machine, this program will download Arcdps into your\ncomputer."
                +" The current download location is at:");
            Console.WriteLine(gw2dir);
            Console.WriteLine("If you wish to change this please edit the .xml file included with this program."); 
            WebClient webClient = new WebClient();
            try
            {
                Console.WriteLine("Now connecting to deltaconnected.com and trying to retrieve arcdps...\n"); 
                webClient.DownloadFile("https://www.deltaconnected.com/arcdps/x64/arcdps.ini", gw2dir + "arcdps.ini");
                webClient.DownloadFile("https://www.deltaconnected.com/arcdps/x64/d3d9.dll", gw2dir + "d3d9.dll");             
                Console.WriteLine("\n\nArcdps has been downloaded. Thanks for using the Kasik Lazy Machine.\n");
                Console.WriteLine("If you have any questions about this program \nfeel free to message me ingame to Bruno.8937"); 
            }
            catch (WebException ex)
            {
                Console.WriteLine("\n\nThe program has encountered an error. (1)\n" + 
                    "This error can occur if the specified Guild Wars 2 folder doesn't exist.\n"+
                    "Make sure the .xml included with this program has the right address to your GW2\ninstallation folder.");
                Console.WriteLine("\nFeel free to message me ingame to Bruno.8937\nif you're still having issues!\n\n");                
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nThe program has encountered an error. (2)");
                Console.WriteLine("I'm not sure what went wrong here, so..."); 
                Console.WriteLine("If the following message doesn't give you enough information\nas to what went wrong" + 
                    "\nfeel free to message me ingame to Bruno.8937\n\n");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nPress Enter to close this window."); 
            Console.ReadLine();
        }
    }
}
