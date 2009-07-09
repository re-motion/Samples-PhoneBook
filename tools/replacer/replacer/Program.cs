using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace replacer
{
  class Program
  {
    static void Main(string[] args)
    {
      File.WriteAllText (args[0], File.ReadAllText (args[0]).Replace (args[1], args[2]));
    }
  }
}
