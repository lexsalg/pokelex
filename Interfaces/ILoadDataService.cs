using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface ILoadDataService
    {
        Task LoadData();
        Task DeleteData();

    }
}
