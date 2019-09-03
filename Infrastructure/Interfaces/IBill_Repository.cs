using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBill_Repository
    {
        IList<Bill_InfraModel> GetAllBills(); // получение всех объектов
        Bill_InfraModel GetBill(int id); // получение одного объекта по id
        void CreateBill(Bill_InfraModel item); // создание объекта
        void UpdateBill(Bill_InfraModel item); // обновление объекта
        void DeleteBill(int id); // удаление объекта по id
    }
}
