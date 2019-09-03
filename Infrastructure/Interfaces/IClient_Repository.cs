using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IClient_Repository
    {
        IList<Client_InfraModel> GetAllCl(); // получение всех объектов
        Client_InfraModel GetCl(int id); // получение одного объекта по id
        void CreateCl(Client_InfraModel item); // создание объекта
        void UpdateCl(Client_InfraModel item); // обновление объекта
        void DeleteCl(int id); // удаление объекта по id
    }
}
