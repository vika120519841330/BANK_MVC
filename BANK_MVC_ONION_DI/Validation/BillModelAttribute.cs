using BANK_MVC_ONION_DI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BANK_MVC_ONION_DI.Validation
{
    public class BillModelAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var bill = value as Bill_ViewModel;
            if (bill != null)
            {
                if (bill.Client_ViewModelId == 0)
                {
                    this.ErrorMessage = "У расчетного счета д.б. задан ID владельца р/с!!!";
                    return false;
                }
                if (bill.BillNumber.Length != 20)
                {
                    this.ErrorMessage = "Длина р/с должна составлять 20 символов!!!";
                    return false;
                }
                if ((bill.BillBalance < 0))
                {
                    this.ErrorMessage = "Баланс расчетного счета должен иметь положительное значение!!!";
                    return false;
                }
                return true;
            }
            else
            {
                this.ErrorMessage = "Запрашиваемый рассчетный счет не существует!!!";
                return false;
            }
        }
    }
}