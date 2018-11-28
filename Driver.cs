using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_file_system
{
  class Driver
  {
    static void Main(string[] args)
    {
      FileSystem FolderFun = new FileSystem();
      Console.WriteLine("C# File System");
      Console.WriteLine("---------------------");
      string input = Console.ReadLine();
      switch(input)
      {
      case "ls":
        // Lists Current directory
      break;

      case "numfile":
        // Return number of files in the file system
      break;

      case "addfile":
        // Add a file
      break;

      case "addfolder":
        // Add a file
      break;

      case "deldir":
        // Deletes directory
      break;

      case "delfile":
        // Deletes file
      break;

      case "help":
        // Prints out a list of all possible commands
      break;
      }
    }
  }
}
