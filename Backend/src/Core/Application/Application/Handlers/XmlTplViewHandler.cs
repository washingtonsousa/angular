using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Xml.Linq;

namespace Core.Application.Handlers
{

  /// <summary>
  /// Classe para criar um mecanismo de template no formato XML com
  /// uso de data binding 
  /// </summary>
  public class XMLTplViewHandler
  {


    public string viewData { get; private set; }
    private string ViewPath;
    private object model;


    /// <summary>
    /// Constrói e inicializa nosso handler de templates XML
    /// </summary>
    /// <param name="ViewPath">Caminho para o template da View, deve seguir o formato XML</param>
    /// <param name="model">Modelo que irá renderiar a view</param>
    public XMLTplViewHandler(string ViewPath, object model)
    {
      this.ViewPath = HostingEnvironment.MapPath("~/Templates") + ViewPath;
      this.model = model;

      initializeComponent();

    }


    /// <summary>
    /// Inicializa o componente lendo o conteúdo do arquivo referenciado no método construtor e passando para a variável viewData
    /// </summary>
    private void initializeComponent()
    {
      using (StreamReader streamReader = new StreamReader(ViewPath))
      {
        viewData = streamReader.ReadToEnd();
      }
      // Remover inserção de linhas ou outras diretrizes de codificação de texto literal para manter o texto limpo
      viewData = Regex.Replace(viewData, @"\t|\n|\r", ""); 
    }


    /// <summary>
    /// Método para gerar a view renderizada a partir do template
    /// Todos as propriedades associadas ao model que forem encontrados interpolados na View serão substituidas pelos seus respectivos valores
    /// </summary>
    /// <returns>viewData</returns>
    private string generateViewData()
    {
      var regexProp = new Regex("\\{{(.*?)\\}}");

      var modelProperties = model.GetType().GetProperties();

      viewData = regexProp.Replace(viewData, (match) => {

        var PropertyName = match.Groups[1]?.Value?.Trim();

        var property = modelProperties.Single(p => p.Name == PropertyName);

        var value = property.GetValue(model);

        return value?.ToString();

      });

      return viewData;
    }


    /// <summary>
    /// Apenas retorna a string literal da view gerada à partir do template
    /// Necessário apenas chamar uma vez, nas demais chame a propriedade viewData diretamente
    /// </summary>
    /// <returns>viewData</returns>
    public string CompileViewstring()
    {
      return generateViewData();
    }


    /// <summary>
    /// Compila a view e retorna um objeto XML que pode ter suas tags chamadas com expressões lambda e linq
    /// </summary>
    /// <returns>XDocument</returns>
    public XDocument CompileXMLLinq()
    {

      return XDocument.Parse(generateViewData());

    }

  }



}
