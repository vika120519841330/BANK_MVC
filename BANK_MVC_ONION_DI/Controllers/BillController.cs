using BANK_MVC_ONION_DI.Mappers;
using BANK_MVC_ONION_DI.Models;
using BANK_MVC_ONION_DI.Validation;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace BANK_MVC_ONION_DI.Controllers
{
    [BillModelAttribute]
    public class BillController : Controller
    {
        private readonly IBill billService;
        public BillController(IBill _billService)
        {
            this.billService = _billService;
        }
        [HttpGet]
        public ActionResult ReedAll()
        {
            ViewBag.Title = "ПРОСМОТР ВСЕХ РАСЧЕТНЫХ СЧЕТОВ БАНКА";
            ViewBag.Header = "РАСЧЕТНЫЕ СЧЕТА:";
            var bills = billService.GetAll()
                .Select(_ => _.BillFromDomainToView())
                .OrderBy(t => t.Client_ViewModelId)
                .ToList()
                ;
            return View(bills);
        }

        [HttpGet]
        public ActionResult ReedOne_Get_1()
        {
            ViewBag.Title = "ПОИСК Р/С ПО ID";
            ViewBag.Message = "Поиск расчетного счета по ID:";
            return View();
        }
        [HttpGet]
        public ActionResult ReedOne_Get_2(int id)
        {
            ViewBag.Title = $"ПОИСК Р/С ПО ID № {id}";
            ViewBag.Header = $"Сведения о расчетном счете с идентификатором № {id}:";
            Bill_ViewModel bill = billService.Get(id).BillFromDomainToView();
            if (bill == null)
            {
                ModelState.AddModelError("GetClientById", "Расчетный счет с запрашиваемым  идентификатором не существует!!!");
                ViewBag.Message = ModelState.Values.ToString();
                return new HttpStatusCodeResult(404, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(bill)))
            {
                ModelState.AddModelError("GetBillNotVal", "Запрашиваемые сведения о расчетном счете не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                return View(bill);
            }
        }
        [HttpGet]
        public ActionResult Create_Get()
        {
            ViewBag.Title = "ДОБАВЛЕНИЕ НОВОГО Р/С";
            ViewBag.Message = "Добавление нового расчетного счета для клиента:";
            return View();
        }
        [HttpPost]
        public ActionResult Create_Post(Bill_ViewModel inst)
        {
            ViewBag.Title = "ДОБАВЛЕНИЕ НОВОГО Р/С";
            if (inst == null)
            {
                ModelState.AddModelError("CreateBillNull", "Не указаны данные для создания расчетного счета!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(inst)))
            {
                ModelState.AddModelError("CreateBillNotVal", "Указанные для создания расчетного счета данные не валидны");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                billService.Create(inst.BillFromViewToDomain());
                ViewBag.Message = "Добавление нового расчетного счета для клиента прошло успешно!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update_Get(int id)
        {
            ViewBag.Title = $"ОБНОВЛЕНИЕ СВЕДЕНИЙ О Р/С с ID №{id}";
            Bill_ViewModel bill = billService.Get(id).BillFromDomainToView();
            if (bill == null)
            {
                ModelState.AddModelError("UpdateBillNull", "Не указаны данные для обновления сведений о расчетном счете!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(bill)))
            {
                ModelState.AddModelError("UpdateBillNotVal", "Указанные для обновления расчетного счета данные не валидны");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                return View(bill);
            }
        }
        [HttpPost]
        public ActionResult Update_Put(Bill_ViewModel inst)
        {
            ViewBag.Title = $"ОБНОВЛЕНИЕ СВЕДЕНИЙ О Р/С с ID №{inst.Id}";
            if (inst == null)
            {
                ModelState.AddModelError("UpdateBillNull", "Не указаны данные для обновления сведений о расчетном счете!!!");
                ViewBag.Result = ModelState.Values.ToString();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(inst)))
            {
                ModelState.AddModelError("UpdateBillNotVal", "Указанные для обновления расчетного счета данные не валидны");
                ViewBag.Result = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                ViewBag.Message = $"Обновление сведений по расчетному счету c ID № {inst.Id}:";
                billService.Update(inst.BillFromViewToDomain());
                ViewBag.Result = $"Обновление сведений по расчетному счету c ID № {inst.Id} прошло успешно!";
                return View("~/Views/Bill/Update_Success.cshtml");
            }
        }

        [HttpGet]
        public ActionResult Delete_Get_1()
        {
            ViewBag.Title = "УДАЛЕНИЕ Р/С";
            ViewBag.Message = "Введите идентификационный номер расчетного счета(ID), подлежащего удалению:";
            return View();
        }
        [HttpGet]
        public ActionResult Delete_Get_2(int id)
        {
            ViewBag.Title = $"УДАЛЕНИЕ Р/С с ID №{id}";
            Bill_ViewModel bill = billService.Get(id).BillFromDomainToView();
            if (bill == null)
            {
                ModelState.AddModelError("DelBillById1", $"Расчетный счет с запрашиваемым  идентификатором № {id} не существует!!!");
                return new HttpStatusCodeResult(404, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(bill)))
            {
                ModelState.AddModelError("GetBillNotVal1", $"Сведения о расчетном счете c ID № {id} не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                ViewBag.Message = "Подтвердите удаление расчетного счета :";
                return View(bill);
            }
        }
        [HttpDelete]
        public ActionResult Delete_End(int id)
        {
            ViewBag.Title = $"ПОДТВЕРЖДЕНИЕ УДАЛЕНИЯ Р/С с ID №{id}";
            Bill_ViewModel bill = billService.Get(id).BillFromDomainToView();
            if (bill == null)
            {
                ModelState.AddModelError("GetClientById2", $"Не найден расчетный счет для удаления с указанным идентификатором № {id}!!!");
                return new HttpStatusCodeResult(404, ModelState.Values.ToString());
            }
            if (!(new BillModelAttribute().IsValid(bill)))
            {
                ModelState.AddModelError("GetBillNotVal2", "Сведения о расчетном счете не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                billService.Delete(id);
                ViewBag.Message = $"Удаление расчетного счета c ID № {id} прошло успешно!";
                return View();
            }
        }
    }
}