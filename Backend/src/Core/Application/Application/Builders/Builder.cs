namespace Core.Application.Builders
{
  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe pai dos construtores
  /// 
  /// Deve ser herdada por uma classe de construção de um objeto/model
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>


  abstract public class Builder
    {

        abstract public object Build();

    }
}