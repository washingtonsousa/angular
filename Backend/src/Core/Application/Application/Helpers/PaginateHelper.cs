namespace Core.Application.Helpers
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe usada para facilitar a paginação de resultados de pesquisa
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>

  public class PaginateHelper
    {
        private int offset;

        public int GetAbsolutePage(int page, int limit)
        {

            if (page > 1)
            {
                this.offset = (page * limit) - limit;

            }
            else
            {
                 this.offset = 0;

            }

            return this.offset;
        }

    }
}