using System; // Import system methods
using System.Collections.Generic; // Import Lists
using System.Text.RegularExpressions; // Import Regular Expressions

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
  class Node
  {
    // Private Node data members
    private string directory;
    private List<string> file;
    private Node leftMostChild;
    private Node rightSibling;

    // Public Node data members
    public string Directory{set{this.directory=value;}get{return this.directory;}}
    public List<string> File {set{this.file=value;}get{return this.file;}}
    public Node LeftMostChild {set{this.leftMostChild=value;}get{return this.leftMostChild;}}
    public Node RightSibling {set{this.rightSibling=value;}get{return this.rightSibling;}}

    // Constructor for node
    public Node(string directory, List<string> file, Node leftMostChild, Node rightSibling)
    {
      this.Directory = directory;
      this.File = file;
      this.LeftMostChild = leftMostChild;
      this.RightSibling = rightSibling;
    }
  }

  public class FileSystem
  {
    private Node root; // Create a root node

    // Creates a file system with a root directory
    public FileSystem()
    {
      this.root = new Node("root", null, null, null); // Create a node called with the name root, no files(list) and no children.
    }

    // Adds a file at the given address
    // Returns false if the file already exists or the path is undefined true otherwise
    public bool AddFile(string address)
    {
      Node current = ParseString(address, this.root); // Sends the directory path and node to ParseString

      try{
        string fileName = ""; // This string is used to take the users name for the file to be added

        if (current.File == null) // If there is no list inside of the node
        {
          current.File = new List<string>(); // Create a new list called File
          Console.Write("Enter a name for the new file > "); // Take user input
          fileName = Console.ReadLine();
          current.File.Add(fileName); // Add that file to the list
          return true; // Successful
        }
        else // If there is already a list of files inside the current node
        {
          foreach (string file in current.File) // For every file inside of the list
          {
            if(fileName == file) // If there is already a file that exists with the same name
            {
              Console.WriteLine("A file with that name already exists in this directory");
              return false; // Failed
            }
          }
        Console.Write("Enter a name for the new file > "); // Take user input
        fileName = Console.ReadLine();
        current.File.Add(fileName); // Add the file to the list
        return true; // Success
        }
      }
      catch{Console.WriteLine("Couldn't add file! (Did you enter the wrong path?)");return false;} // Catch for invalid names
    }

    // Removes the file at the given address
    // Returns false if the file is not found or the path is undefined ; true otherwise
    public bool RemoveFile(string address)
    {
      Node current = ParseString(address, this.root); // Sends the directory path and node to ParseString

      try{
        Console.Write("Enter the name of the file to remove > "); // Take user input
        string fileName = Console.ReadLine();
        if (current.File == null) // If there is no list in the node
        {
          return false; // Job Failed
        }
        else // If the list exists
        {
          foreach (string item in current.File) // For each file in the file list
          {
            if (fileName == item) // If the name of the file you want to delete matches the name of the file in the File list.
            {
              current.File.Remove(fileName); // Remove the item
              return true; // Success
            }
          }
          return true; // Success
        }
      }
      catch{Console.WriteLine("Couldn't remove the item! (Did you enter the correct path and/or file name?)");return false;}
    }

    public bool AddDirectory(string address)
    {
      Node current = ParseString(address, this.root); // Sends the directory path and node to ParseString

      if (current.LeftMostChild == null) // If the left child is empty
      {
        Console.Write("Enter a name for the new directory > "); // Take user input
        string dirName = Console.ReadLine();
        current.LeftMostChild = new Node(dirName, null, null, null); // Create a new directory at the left child
        return true; // Success
      }
      else if (current.RightSibling == null) // If the left is full and right is empty
      {
        Console.Write("Enter a name for the new directory > "); // Take user input
        string dirName = Console.ReadLine();
        current.RightSibling = new Node(dirName, null, null, null); // Create a new directory at the right child
        return true; // Success
      }
      else {Console.WriteLine("Couldn't add directory, both child nodes are full! Please try another directory");return false;} // If both child nodes are full
    }

    // This method deletes a directory
    public bool RemoveDirectory(string address)
    {
      try{
        Node current = ParseString(address, this.root); // Sends the directory path and node to ParseString

        Console.Write("Enter the name of the directory to remove > "); // Take user input
        string dirName = Console.ReadLine();
        if (current.LeftMostChild.Directory == dirName) // If the name of the directory on the left child matches the directory to be removed
        {
          current.LeftMostChild = null; // Set that child to null
          return true; // Success
        }
        else if(current.RightSibling.Directory == dirName) // If the name of the directory on the right child matches the directory to be removed
        {
          current.RightSibling = null; // Set that child to null
          return true; // Success
        }
        else{Console.WriteLine("Couldn't remove directory! (Two directories already exist in this node)");return false;} // If both children are full
      }
      catch{Console.WriteLine("Couldn't remove directory! (Did you use the correct path and directory name?)");return false;} // Unknown failure
    }

    // Returns the number of files in the file system
    public int NumberFiles()
    {
      int TotalCount = 0; // This in keeps track of the total amount of files in each list
      Node current = this.root; // Set current node to root
      Counting(current); // Send the node current to the recursive method

      // This is a recursive method used to count the amount of total files in the file system
      void Counting(Node n)
      {
        if (n.LeftMostChild == null && n.RightSibling == null) // If the current node has no children (leaf node)
        {
          if (n.File != null) // If the list exists
          {
            TotalCount += n.File.Count; // Add the amount of files in the list to TotalCount
          }
        }

        else
        {
          if(n.File != null) // If the list exists
          {
            TotalCount += n.File.Count; // Add the amount of files in the list to TotalCount
          }
          Counting(n.LeftMostChild); // Start the method with the leftMostChild being passed

          if (n.RightSibling != null) // If the right sibling exists
          {
            if(n.File != null) // If the list exists
            {
              TotalCount += n.File.Count; // Add the amount of files in the list to TotalCount
            }
            Counting(n.RightSibling); // Start the method with the rightSibling being passed
          }
        }
      }
      return TotalCount; // Return the totalCount of files
    }

    // Prints the directories in a pre - order fashion along with their files
    public void PrintFileSystem()
    {
      Node current = this.root; // Set the current node to root
      PrintLoop(current); // Send the current node to the PrintLoop method

      // This method navigates through the filesystem and prints each directory with its file list
      void PrintLoop(Node curr)
      {
        if(curr.LeftMostChild == null && curr.RightSibling == null) // If the current node is a leaf node
        {
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          Console.WriteLine("Directory: {0}", curr.Directory); // Print the name of the directory
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          if (curr.File != null) // If the current node has a list with atleast one file
          {
            foreach (string file in curr.File) // For each file in the list
            {
              Console.WriteLine("\t- {0}", file); // Print out the file name
            }
          }
        }
        else // If the current node is not a leaf node
        {
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          Console.WriteLine("Directory: {0}", curr.Directory); // Print the name of the directory
          Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
          if(curr.File != null) // If the current node has a list with atleast one file
          {
            foreach (string file in curr.File) // For each file in the list
            {
              Console.WriteLine("\t- {0}", file); // Print out the file name
            }
          }
          PrintLoop(curr.LeftMostChild); // Run the method again with the Left child

          if(curr.RightSibling != null) // If the current rightSibling exists
          {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Directory: {0}", curr.Directory); // Print out the directory name
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            if (curr.File != null) // If the current node has a list
            {
              foreach (string file in curr.File) // Cycle through each item in the list
              {
                Console.WriteLine("\t- {0}", file); // Print out the file name
              }
            }
            PrintLoop(curr.RightSibling); // Run the method again with the right sibling
          }
        }
      }
    }

    // This method parses the path that the user provides in the Driver
    // It is passed the full path (address) and the current node
    private Node ParseString(string address, Node current)
    {
      string[] dirArray = Regex.Split(address, "/"); // Use regular expressions to split the path and put each value into an array in sequential order
      int loopCount = 0; // loopCount keeps tally of how many times ParseString has run.

      foreach(string dir in dirArray) // This foreach loop cleans the output from Regex (When / is put at the end of a path Regex a null string is made)
      {
        if(dir == null) // Check if there are any null spaces in dirArray
        {
          current.File.Remove(dir); // Remove the null string
        }
      }

      if (current.Directory == "root" && dirArray.Length == 1) //To check if the only directory is root
      {
        return current; // If there is only a root node, return root
      }

      foreach (string dir in dirArray) // Main loop to cycle through directories in the path provided by Driver
      {
        if (current.Directory != dirArray[dirArray.Length - 1]) // This line checks if you are in the last directory in the path if not, continue
        {
          if (current.LeftMostChild == null && current.RightSibling == null) // If on leaf node
          {
            loopCount++; // Increase loopCount
            return current; // Returns current node
          }

          if (loopCount <= dirArray.Length) // Checks that the loop hasnt run more times than the length of the array
          {
            if (current.LeftMostChild != null) // Make sure that the left child has a node
            {
              if (current.LeftMostChild.Directory == dirArray[loopCount + 1]) // Checks if the left child has the same name as the next item in the array
              {
                current = current.LeftMostChild; // Set the left child to the current
                loopCount++; // Increase loop count
              }
              if (current.RightSibling != null) // Checks if the right sibling has a directory in it
              {
                if (current.RightSibling.Directory == dirArray[loopCount + 1]) // Checks if the right child has the same name as the next item in the array
                {
                  current = current.RightSibling; // Set the right child to the current
                  loopCount++; // Increase loop count
                }
              }
            }
          }
        }
      }
      return current; // Return current node
    }
  }
}
