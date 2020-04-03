using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Shared.Kernel.Extensions
{
  public static class KernelExtensions
  {
    public static bool IsDll(this string Name)
    {

      bool isModuleDll = (Name.Split(".".ToCharArray()).Last() == "dll");
      return isModuleDll;

    }
  }
}
