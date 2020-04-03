using Ninject;

namespace Core.Shared.Kernel.Abstractions
{
  public interface IModule
  {
    void InjectAll(IKernel kernel);
  }
}
