using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace svn_del
{
  class Program
  {
    static bool IsSvn (string path)
    {
      return Path.GetFileName (path) == ".svn";
    }

    static void EmptyFiles (string path)
    {
      foreach (var fileName in Directory.GetFiles (path))
      {
        Console.WriteLine (fileName);
        File.SetAttributes (fileName, FileAttributes.Normal);
        File.Delete (fileName);
      }
    }

    static void DeleteDirectories (string path)
    {
      foreach (var dirName in Directory.GetDirectories (path))
      {
        Console.WriteLine (dirName);
        EmptyFiles (dirName);
        DeleteDirectories (dirName);
        Directory.Delete (dirName);
      }
    }

    static void SvnEmpty (string path)
    {
      if (IsSvn (path))
      {
        EmptyFiles (path);
        DeleteDirectories (path);
      }
      else
      {
        throw new ArgumentException (String.Format ("Internal error: non-svn directory passed to SvnEmpty (should never happen): {0}", path));
      }
    }

    static void SvnDelete (string path)
    {
      if (IsSvn (path))
      {
        Directory.Delete (path);
      }
      else
      {
        throw new ArgumentException (String.Format("Internal error: non-svn directory passed to SvnDelete (should never happen): {0}", path));
      }
    }

    static void SvnEmptyDelete (string path)
    {
      if (IsSvn (path))
      {
        SvnEmpty (path);
        SvnDelete (path);
      }
    }

    static List<string> CollectSvns (string path, List<string> accu)
    {
      foreach (var dirName in Directory.GetDirectories (path))
      {
        if (IsSvn (Path.GetFileName (dirName)))
        {
          accu.Add (dirName);
        }
        else
        {
          CollectSvns (dirName, accu);
        }
      }
      return accu;
    }

    static void Main (string[] args)
    {
      if (!(args.Length == 1))
      {
        Console.WriteLine ("use like this: svn-del <root-directory>");
        Console.WriteLine ("WILL REMOVE ALL .svn-DIRECTORIES IN THE TREE");
        return;
      }

      var path = args[0];
      if (Path.GetFullPath (path).StartsWith (@"C:\Development"))
      {
        throw new ArgumentException (String.Format("You must be crazy! That .svn is your development tree! ({0})", path));
      }

      if (Path.GetFullPath (path).StartsWith (@"C:\"))
      {
        throw new ArgumentException (@"You can't do that: using '\' as the root");
      }

      var accu = CollectSvns (args[0], new List<string> ());
      foreach (var iter in accu)
      {
        Console.WriteLine (iter);
      }

      foreach (var iter in accu)
      {
        SvnEmptyDelete (iter);
      }
    }
  }
}
