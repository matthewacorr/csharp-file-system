using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace csharp_file_system
{
  class Node
  {
    private string directory;
    private List<string> file;
    private Node leftMostChild;
    private Node rightSibling;

    public string Directory{set{this.directory=value;}get{return this.directory;}}
    public List<string> File {set{this.file=value;}get{return this.file;}}
    public Node LeftMostChild {set{this.leftMostChild=value;}get{return this.leftMostChild;}}
    public Node RightSibling {set{this.rightSibling=value;}get{return this.rightSibling;}}

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
    // Creates a file system with a root directory
    public FileSystem()
    {
      this.root = new Node("root", null, null, null); // Create a node called with the name root, no files(list) and no children.
    }

    // Adds a file at the given address
    // Returns false if the file already exists or the path is undefined true otherwise
    public bool AddFile(string address)
    {
      Node current = ParseString(address, this.root);
      try
      {
        string fileName = "";
        if (current.File == null)
        {
          current.File = new List<string>();
          Console.Write("Enter new file name >");
          fileName = Console.ReadLine();
          current.File.Add(fileName);
          return true;
        }
        else
        {
          foreach (string item in current.File)
          {
            if(fileName == item)
            {
              return false;
            }
          }
        Console.Write("Enter new file name > ");
        fileName = Console.ReadLine();
        current.File.Add(fileName);
        return true;
        }
      }
      catch{return false;}
    }

    // Removes the file at the given address
    // Returns false if the file is not found or the path is undefined ; true otherwise
    public bool RemoveFile(string address)
    {
      Node current = ParseString(address, this.root);
      try
      {
        Console.Write("Name of file to be removed > ");
        string fileName = Console.ReadLine();
        if (current.File == null)
        {
          return false;
        }
        else
        {
          foreach (string item in current.File)
          {
            if (fileName == item)
            {
              current.File.Remove(fileName);
              return true;
            }
          }
          return true;
        }
      }
      catch{return false;}
    }

    public bool AddDirectory(string address)
    {
      Node current = ParseString(address, this.root);

      if (current.LeftMostChild == null) // If the left child is empty
      {
        Console.Write("New directory name > ");
        string dirName = Console.ReadLine();
        current.LeftMostChild = new Node(dirName, null, null, null); // Create a new directory at the left child
        return true; // Success
      }
      else if (current.RightSibling == null) // If the left is full and right is empty
      {
        //code needed to add
        Console.Write("New directory name > ");
        string dirName = Console.ReadLine();
        current.RightSibling = new Node(dirName, null, null, null); // Create a new directory at the right child
        return true; // Success
      }
      else {Console.WriteLine("Couldn't add directory, both child nodes are full! Please try another directory");return false;} // If both child nodes are full
    }

    public bool RemoveDirectory(string address)
    {
      try
      {
        Node current = ParseString(address, this.root);
        Console.Write("Name of directory to remove > ");
        string dirName = Console.ReadLine();
        if (current.LeftMostChild.Directory == dirName)
        {
          current.LeftMostChild = null;
          return true;
        }
        else if(current.RightSibling.Directory == dirName)
        {
          current.RightSibling = null;
          return true;
        }
        else{Console.WriteLine("Couldn't remove directory! (Two directories already exist in this node)");return false;} // If both children are full
      }
      catch{Console.WriteLine("Couldn't remove directory! (Did you use the correct path and directory name?)");return false;} // Unknown failure
    }

    // Returns the number of files in the file system
    public int NumberFiles()
    {
      int TotalCount = 0;
      Node current = this.root;
      Counting(current);

      void Counting(Node n)
      {
        if (n.LeftMostChild == null && n.RightSibling == null)
        {
          TotalCount += n.File.Count;
        }

        else
        {
          TotalCount += n.File.Count;
          Counting(n.LeftMostChild);

          if (n.RightSibling != null)
          {
            TotalCount += n.File.Count;
            Counting(n.RightSibling);
          }
        }
      }
      return TotalCount;
    }

    // Prints the directories in a pre - order fashion along with their files
    public void PrintFileSystem()
    {
      Node current = this.root;
      PrintLoop(current);

      void PrintLoop(Node curr)
      {
        if(curr.LeftMostChild == null && curr.RightSibling == null)
        {
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          Console.WriteLine("Directory: {0}", curr.Directory);
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          if (curr.File != null)
          {
            foreach (string file in curr.File)
            {
              Console.WriteLine("\t- {0}", file);
            }
          }
        }
        else
        {
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          Console.WriteLine("Directory: {0}", curr.Directory);
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          if(curr.File != null)
          {
            foreach (string file in curr.File)
            {
              Console.WriteLine("\t- {0}", file);
            }
          }
          PrintLoop(curr.LeftMostChild);

          if(curr.RightSibling != null)
          {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Directory: {0}", curr.Directory);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            if (curr.File != null)
            {
              foreach (string file in curr.File)
              {
                Console.WriteLine("\t- {0}", file);
              }
            }
            PrintLoop(curr.RightSibling);
          }
        }
      }
    }

    private Node ParseString(string address, Node current)
    {
      string[] dirArray = Regex.Split(address, "/");
      int loopCount = 0;

      foreach(string dir in dirArray)
      {
        if(dir == null) // Check if there are any null spaces in dirArray
        {
          current.File.Remove(dir);
        }
      }

      if (current.Directory == "root" && dirArray.Length == 1) //To check if the only directory is root
      {
        return current;
      }

      foreach (string dir in dirArray)
      {
        if (current.Directory != dirArray[dirArray.Length - 1])
        {
          if (current.LeftMostChild == null && current.RightSibling == null)
          {
            loopCount++;
            return current;
          }

          if (loopCount <= dirArray.Length)
          {
            if (current.LeftMostChild != null)
            {
              if (current.LeftMostChild.Directory == dirArray[loopCount + 1])
              {
                current = current.LeftMostChild;
                loopCount++;
              }
              if (current.RightSibling != null)
              {
                if (current.RightSibling.Directory == dirArray[loopCount + 1])
                {
                  current = current.RightSibling;
                  loopCount++;
                }
              }
            }
          }
        }
      }
      return current;
    }
  }
}
