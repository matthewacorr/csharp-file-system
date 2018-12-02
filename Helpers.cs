using System; // Import system methods
using System.Collections.Generic; // Import Lists
using System.Text.RegularExpressions; // Import Regex

namespace csharp_file_system
{
  class Node
  {
    private string directory;
    private List<string> file;
    private Node leftMostChild;
    private Node rightSibling;

    // Public data members with Get and Set properties.
    public string Directory {set{this.directory=value;} get{return this.directory;}}
    public List<string> File {set{this.File=value;} get{return this.File;}}
    public Node LeftMostChild {set{this.leftMostChild=value;} get{return this.leftMostChild;}}
    public Node RightSibling {set{this.rightSibling=value;} get{return this.rightSibling;}}

    public Node(string directory, List<string> file, Node leftMostChild, Node rightSibling)
    {
      this.directory = directory;
      this.file = file;
      this.leftMostChild = leftMostChild;
      this.rightSibling = rightSibling;
    }
  }

  public class FileSystem
  {
    private Node root;
    public Node test;
    // Creates a file system with a root directory
    public FileSystem()
    {
      this.root = new Node("root", null, null, null); // Contruct the root node (directory)
    }

    // Adds a file at the given address
    // Returns false if the file already exists or the path is undefined true otherwise
    public bool AddFile(string address)
    {
      try{
        Node current = this.root;
        string fileName = "";
        ParseStr(address, current);
        if (current.File == null)
        {
          Console.WriteLine("Please enter the name of the file you would like to add");
          fileName = Console.ReadLine();
          current.File.Add(fileName);
          return true;
        }
        else
        {
          foreach(string item in current.File)
          {
            if (fileName == item)
            {
              return false;
            }
        }
        Console.WriteLine("Please enter the name of the file you would like to add");
        fileName = Console.ReadLine();
        current.File.Add(fileName);
        return true;
        }
      }
      catch {Console.WriteLine("Couldn't add file! (Has the file name already been used in this directory?)"); return false;}
    }

    // Removes the file at the given address
    // Returns false if the file is not found or the path is undefined ; true otherwise
    public bool RemoveFile(string address)
    {
      try
      {
        Node current = this.root;
        ParseStr(address,current);
        string fileName = "";

        if(current.File == null)
        {
          Console.WriteLine("Nothing to remove!");
          return false;
        }
        else
        {
          foreach (string item in current.File)
          {
            if (fileName == item)
            {
              Console.Write("Enter the name of the file you would like to delete: ");
              fileName = Console.ReadLine();
              current.File.Remove(fileName);
              Console.WriteLine("File deleted successfully!");
              return true;
            }
          }
          Console.WriteLine("Couldn't add file!");
          return false;
        }
      }
      catch {Console.WriteLine("Couldn't add file! (Has the file name already been used in this directory?)"); return false;}
    }

    // Adds a directory at the given address
    // Returns false if the directory already exists or the path is undefined; true otherwise
    public bool AddDirectory(string address)
    {
      try
      {
        Node current = this.root;   // Set current node to root
        ParseStr(address, current);
        // Once at the correct node add new node
        if(current.LeftMostChild == null)
        {
          Console.Write("Enter the name of the directory you would like to add: ");
          string dirName = Console.ReadLine();
          current.LeftMostChild = new Node(dirName, null, null, null);
          return true;
        }
        else if(current.RightSibling == null)
        {
          Console.Write("Enter the name of the directory you would like to add: ");
          string dirName = Console.ReadLine();
          current.RightSibling = new Node(dirName, null, null, null);
          return true;
        }
        else{
          return false;
        }
      }
      catch {Console.WriteLine("Couldn't add directory! (Has the folder name already been used?)"); return false;}
    }

    // Removes the directory (and its subdirectories) at the given address
    // Returns false if the directory is not found or the path is undefined; true otherwise
    public bool RemoveDirectory(string address)
    {
    try{
      Node current = this.root;
      ParseStr(address, current);
      Console.WriteLine("Enter the name of the folder you would like to delete");
      string dirName = Console.ReadLine();
      if (current.LeftMostChild.Directory == dirName)
      {
        current.LeftMostChild = null;   // Remove the child
      }
      else if (current.RightSibling.Directory == dirName)
      {
        current.RightSibling = null;   // Remove the child
      }
      return true;
    }
    catch {Console.WriteLine("Couldn't remove file! (Did you use the correct path?)"); return false;}
    }

    // Returns the number of files in the file system
    public int NumberFiles()
    {
      int totalFiles = 0;
      // Need to recursivly go through linked list of nodes and then add up the current.Files.Length to get the amount of items in each list
      return totalFiles;
    }

    // Prints the directories in a pre - order fashion along with their files
    public void PrintFileSystem()
    {
      // Need to Implement
    }

    private Node ParseStr(string address, Node current)
    {
      try
      {
        string[] dirArray = Regex.Split(address, "/");
        if(dirArray.Length != 1)
        {
          foreach (string dir in dirArray)
          {
            if (current.RightSibling.Directory == dir)
            {
              current = current.RightSibling;
            }
            else if (current.LeftMostChild.Directory == dir)
            {
              current = current.LeftMostChild;
            }
          }
          return current;
        }
        else if (current.Directory == "root")
        {
          return null;
        }
        else
        {
          return null;
        }
      }
      catch
      {
        return null;
      }
    }
  }
}
