using System; // Import system methods

//
//  C# File System
//  Dec 02 2018
//
//  Description: This is a program which uses nodes and lists to create a virtual filesystem with the
//               ability to add and delete files and directories. The driver.cs file runs the user input
//               and the helpers.cs is what holds the FileSystem and all of it's methods
//
//  Made by: Matthew Corr (0626013)
//           Trevor Hill
//

namespace csharp_file_system
{
  class Driver
  {
    static void Main(string[] args)
    {
      try{
        FileSystem FolderFun = new FileSystem(); // Create the new filesystem
        Console.ForegroundColor = ConsoleColor.White; // Set the foreground color to white
        Console.WriteLine("C# File System\n(Enter \"help\" for a list possible commands/inputs)\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); // Title Prompt
        while(true) // Loop runs until exit is entered or Ctrl + C is pressed
        {
          Console.Write("> "); // Command prompt
          string input = Console.ReadLine(); // Take user input
          Console.WriteLine(" "); // Whitespace for terminal formatting

          // This switch statement contains all the functions of the program that the user can enter
          switch(input)
          {
            case "print":
              FolderFun.PrintFileSystem(); // Uses the PrintFileSystem method to print the contents of the entire file system
            break;

            case "numfile":
              Console.WriteLine("There are {0} files in the system", FolderFun.NumberFiles()); // Uses the NumberFiles method to return the total amount of files in the system
            break;

            case "newfile":
              Console.Write("Enter the path you wish to add the file too > "); // Prompt user for the path
              if(FolderFun.AddFile(Console.ReadLine()) == true){Console.WriteLine("File Added!\n");} // Call AddFile and send the user input
              else{Console.WriteLine("Couldn't add file! (Did you use the right path?)");} // If the file can't be added
            break;

            case "delfile":
              Console.Write("Enter the path you wish to delete the file from > "); // Prompt user for the path
              if(FolderFun.RemoveFile(Console.ReadLine()) == true) {Console.WriteLine("File Removed!\n");} // Call RemoveFile and send the user input
              else{Console.WriteLine("Couldn't remove file! (Did you use the right path?)");} // If the file can't be removed
            break;

            case "newdir":
            Console.Write("Enter the path to the directory which will contain the new folder > "); // Prompt user for the path
            if(FolderFun.AddDirectory(Console.ReadLine()) == true) {Console.WriteLine("Directory Created!\n");} // Call AddDirectory with the user input
            else{Console.WriteLine("Couldn't add folder! (Does the folder already exist?)");} // If the directory couldn't be added
            break;

            case "deldir":
            Console.Write("Enter the path to the directory whichs contains the folder to be deleted > "); // Prompt user for the path
            if(FolderFun.RemoveDirectory(Console.ReadLine()) == true) {Console.WriteLine("Directory Removed!\n");} // Call RemoveDirectory with the user input
            else{Console.WriteLine("Couldn't remove folder! (Does the folder already exist?)");} // If the directory cannont be removed
            break;

            case "help": // List of all possible commands and valid file paths
              Console.WriteLine("Help: ");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
              Console.WriteLine("NOTE: Valid file paths can have leading and ending \"/\" characters");
              Console.WriteLine("      for example (/root/home/) and (root/home) are both valid\n");
              Console.WriteLine("newdir     -  Adds a directory to a specified path");
              Console.WriteLine("deldir     -  Removes a directory from a specified path");
              Console.WriteLine("newfile    -  Adds a file to a specified path");
              Console.WriteLine("delfile    -  Removes a file to a specified path");
              Console.WriteLine("print      -  Prints all folders and files in the File System");
              Console.WriteLine("numfile    -  Returns the amount of files in the File System");
              Console.WriteLine("help       -  Prints this dialog");
              Console.WriteLine("clear      -  Clears the console output");
              Console.WriteLine("exit       -  Exits the program");
              Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            break;

            case "clear": // Clears the terminal output if you are adding a lot of directories/files
              Console.WriteLine("Clearing Screen...");
              Console.Clear();
            break;

            case "exit": // Exit the program
              Console.WriteLine("Exiting...");
              Environment.Exit(0); // Send the terminal exit code 0 (Successful Exit)
            break;

            default: // Output if an invalid command is entered
              Console.ForegroundColor = ConsoleColor.Red; // Alert color
              Console.WriteLine("Not a recognized command (Enter \"help\" for a list of possible commands)");
              Console.ForegroundColor = ConsoleColor.White; // Reset foreground color:w
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
