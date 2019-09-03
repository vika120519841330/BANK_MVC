using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClient
    {
        IList<Client_DomainModel> GetAll(); // получение всех объектов
        Client_DomainModel Get(int id); // получение одного объекта по id
        void Create(Client_DomainModel item); // создание объекта
        void Update(Client_DomainModel item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
