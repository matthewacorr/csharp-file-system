using System;

namespace csharp_file_system
{
  class Driver
  {
    static void Main(string[] args)
    {
      try{
        FileSystem FolderFun = new FileSystem();
        Console.WriteLine("C# File System (Enter \"help\" for all possible commands)\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        while(true)
        {
          Console.Write("> ");
          string input = Console.ReadLine();
          Console.WriteLine(" ");
          switch(input)
          {
            case "print":
              FolderFun.PrintFileSystem();
            break;

            case "numfile":
              Console.WriteLine("There are {0} files in the system", FolderFun.NumberFiles());
            break;

            case "addfile":
              Console.Write("Enter the path you wish to add the file too (ex: root/home)\n> ");
              if(FolderFun.AddFile(Console.ReadLine()) == true){Console.WriteLine("File Added!");}
              else{Console.WriteLine("Couldn't add file! (Did you use the right path?)");}
            break;

            case "remfile":
              Console.Write("Enter the path you wish to delete the file from (ex: root/home)\n> ");
              if(FolderFun.RemoveFile(Console.ReadLine()) == true) {Console.WriteLine("File Removed!");}
              else{Console.WriteLine("Couldn't remove file! (Did you use the right path?)");}
            break;

            case "addfolder":
            Console.Write("Enter the path you wish to add the folder too (ex: root/home)\n> ");
            if(FolderFun.AddDirectory(Console.ReadLine()) == true) {Console.WriteLine("Directory Created!");}
            else{Console.WriteLine("Couldn't add folder! (Does the folder already exist?)");}
            break;

            case "remfolder":
            Console.Write("Enter the path you wish to delete the folder from (ex: root/home)\n> ");
            if(FolderFun.RemoveDirectory(Console.ReadLine()) == true) {Console.WriteLine("Directory Removed!");}
            else{Console.WriteLine("Couldn't remove folder! (Does the folder already exist?)");}
            break;

            case "help":
              Console.WriteLine("Possible Commands: ");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine("addfolder  -  Adds a directory to a specified path");
              Console.WriteLine("remfolder  -  Removes a directory from a specified path");
              Console.WriteLine("addfile    -  Adds a file to a specified path");
              Console.WriteLine("remfile    -  Removes a file to a specified path");
              Console.WriteLine("print      -  Prints all folders and files in the File System");
              Console.WriteLine("numfile    -  Returns the amount of files in the File System");
              Console.WriteLine("help       -  Prints this dialog");
              Console.WriteLine("clear      -  Clears the console output");
              Console.WriteLine("exit       -  Exits the program");
            break;

            case "clear":
              Console.WriteLine("Clearing Screen...");
              Console.Clear();
            break;

            case "exit":
              Console.WriteLine("Exiting...");
              Environment.Exit(0);
            break;

            default:
              Console.WriteLine("Not a recognized command (Enter \"help\" for a list of possible commands)");
            break;
          }
        }
      }
      catch{
        Console.WriteLine("Not a valid command!");
      }
    }
  }
}
