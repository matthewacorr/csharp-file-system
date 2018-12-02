using System;
using System.Collections.Generic;

namespace csharp_file_system
{
class Driver
{
static void Main(string[] args)
{
        FileSystem FolderFun = new FileSystem(); // Create new file system
        Console.WriteLine("C# File System\n---------------------\nPress Ctrl+C to exit");

        while(true)
        {
                string usrInput = Console.ReadLine(); // Take user input for switch statement
                switch(usrInput)
                {

                case "print":
                        FolderFun.PrintFileSystem();
                        break;

                case "numfile":
                        Console.WriteLine("There are {0} files in the entire file system", FolderFun.NumberFiles());
                        break;

                case "addfile":
                        Console.WriteLine("Please enter the path to the directory that you would like to add a file to (Example: root/home/matt/)");
                        string input = Console.ReadLine();
                        FolderFun.AddFile(input);
                        break;

                case "delfile":
                        Console.WriteLine("Please enter the path you want to delete a file from (Example: root/home/matt/)");
                        input = Console.ReadLine();
                        FolderFun.RemoveFile(input);
                        break;

                case "addfolder":
                        Console.WriteLine("Please enter the path you want to add the folder to (Example: root/home/matt/FOLDERNAME)");
                        input = Console.ReadLine();
                        FolderFun.AddDirectory(input);
                        break;

                case "delfolder":
                        Console.WriteLine("Please enter the path of the directory you would like to remove (Example: root/home/matt would delete the folder\"matt\"");
                        input = Console.ReadLine();
                        FolderFun.RemoveDirectory(input);
                        break;

                case "help":
                        Console.WriteLine("Possible Commands\n-----------------");
                        Console.WriteLine("");
                        break;
                }
        }
}
}
}
