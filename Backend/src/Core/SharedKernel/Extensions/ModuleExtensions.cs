using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Shared.Kernel.Extensions
{
  public static class ModuleExtensions
  {

    public static bool IsModuleDll(this string DllName) { 
    
      bool isModuleDll = (DllName.Substring(0, 6) == "Module" && DllName.IsDll());
      return isModuleDll;

    }

    public static string GetModuleRealName(this string ModuleName)
    {

      string moduleName = ModuleName.Substring(0, ModuleName.Length - 4);
      moduleName = moduleName.Substring(7, moduleName.Length - 7);

      return moduleName;

    }

    public static string GetModuleMainClassName(this string ModuleName)
    {

      string moduleName = ModuleName.Substring(0, ModuleName.Length - 4);
      moduleName = moduleName.Substring(7, moduleName.Length - 7);
      moduleName += "Module";

      return moduleName;

    }

  }
}
