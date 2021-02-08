using System.Threading.Tasks;
namespace PokeLexApi.Interfaces
{
    public interface ILoadDataService
    {
        Task LoadData();
        Task DeleteData();

    }
}
