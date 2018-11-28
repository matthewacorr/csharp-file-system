using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_file_system
{
  class Node
  {
    private string directory;
    private List<string> file;
    private Node leftMostChild;
    private Node rightSibling;
  }

  public class csharp_file_system
  {
    private Node root;

    // Creates a file system with a root directory
    public FileSystem()
    {

    }

    // Adds a file at the given address
    // Returns false if the file already exists or the path is undefined true otherwise
    public bool AddFile(string address)
    {
      return false; // Placeholder
    }

    // Removes the file at the given address
    // Returns false if the file is not found or the path is undefined ; true otherwise
    public bool RemoveFile(string address)
    {
      return false; // Placeholder
    }

    // Adds a directory at the given address
    // Returns false if the directory already exists or the path is undefined; true otherwise
    public bool AddDirectory(string address)
    {
      return false; // Placeholder
    }

    // Removes the directory (and its subdirectories) at the given address
    // Returns false if the directory is not found or the path is undefined; true otherwise
    public bool RemoveDirectory(string address)
    {
      return false; // Placeholder
    }

    // Returns the number of files in the file system
    public int NumberFiles()
    {
      return 0; // Placeholder
    }

    // Prints the directories in a pre - order fashion along with their files
    public void PrintFileSystem( )
    {

    }
  }
}
