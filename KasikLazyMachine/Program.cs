using System;
using System.IO; 
using System.Net;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;

namespace KasikLazyMachine
{
    class Program
    {      

        static void Main(string[] args)
        {
            bool UpToDate = false; 
            string gw2dir = ConfigurationSettings.AppSettings["gw2dir"];
            bool downloadBuildTemplates = ConfigurationSettings.AppSettings["buildtemplates"].ToUpper() == "Y"; 
            Console.WriteLine("Welcome to the Kasik Lazy Machine, this program will download Arcdps into your\ncomputer."
                +$" The current download location is at:\n{ gw2dir }\n"+
                "If you wish to change this please edit the .xml file included with this program."); 
            WebClient webClient = new WebClient();
            Console.WriteLine("Now connecting to deltaconnected.com and trying to retrieve arcdps...\n");
            try
            {
                string dllRoute = gw2dir + "d3d9.dll";
                if (File.Exists(dllRoute))
                {
                    string localMd5, remoteMd5;
                    MD5 md5 = MD5.Create();
                    using (var stream = File.OpenRead(dllRoute))
                    {
                        localMd5 = string.Join(string.Empty, Array.ConvertAll(md5.ComputeHash(stream), b => b.ToString("x2")));
                    }
                    remoteMd5 = Encoding.UTF8.GetString(webClient.DownloadData("https://www.deltaconnected.com/arcdps/x64/d3d9.dll.md5sum"));
                    UpToDate = remoteMd5.Contains(localMd5); 
                    if (UpToDate) Console.WriteLine("ArcDPS is up to date.");
                    else Console.WriteLine("Your ArcDPS is not up to date.");
                }   else Console.WriteLine("You haven't installed ArcDPS yet.");

                if (!UpToDate)
                {
                    webClient.DownloadFile("https://www.deltaconnected.com/arcdps/x64/arcdps.ini", gw2dir + "arcdps.ini");
                    webClient.DownloadFile("https://www.deltaconnected.com/arcdps/x64/d3d9.dll", gw2dir + "d3d9.dll");
                    if (downloadBuildTemplates)
                    {
                        webClient.DownloadFile("https://www.deltaconnected.com/arcdps/x64/buildtemplates/d3d9_arcdps_buildtemplates.dll",
                            gw2dir + "d3d9_arcdps_buildtemplates.dll"); 
                    }
                    Console.WriteLine("\n\nArcdps has been downloaded. Thanks for using the Kasik Lazy Machine.\n" + 
                        "If you have any questions about this program \nfeel free to message me ingame to Bruno.8937"); 
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("\n\nThe program has encountered an error. (1)\n\n" + 
                    "This error can occur if the specified Guild Wars 2 folder doesn't exist.\n"+
                    "Make sure the .xml included with this program has the right address to your GW2\ninstallation folder." + 
                    "\nFeel free to message me ingame to Bruno.8937\nif you're still having issues!\n\n");                
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nThe program has encountered an error. (2)" + 
                    "\nI'm not sure what went wrong here, so..." + 
                    "\nIf the following message doesn't give you enough information\nas to what went wrong" + 
                    $"\nfeel free to message me ingame to Bruno.8937\n\n{ex.Message}");
            }
            
            Console.WriteLine("\nPress Enter to close this window."); 
            Console.ReadLine();
        }
    }
}
