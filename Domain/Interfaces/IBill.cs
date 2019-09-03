using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBill
    {
        IList<Bill_DomainModel> GetAll(); // получение всех объектов
        Bill_DomainModel Get(int id); // получение одного объекта по id
        void Create(Bill_DomainModel item); // создание объекта
        void Update(Bill_DomainModel item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
