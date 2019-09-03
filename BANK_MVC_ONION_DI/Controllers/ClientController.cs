using BANK_MVC_ONION_DI.Mappers;
using BANK_MVC_ONION_DI.Models;
using BANK_MVC_ONION_DI.Validation;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FluentValidation.Attributes;

namespace BANK_MVC_ONION_DI.Controllers
{
    [Validator(typeof(ClientModelValidator))]
    public class ClientController : Controller
    {
        private readonly IClient clientService;
        public ClientController(IClient _clientService)
        {
            this.clientService = _clientService;
        }

        // Отображение всех клиентов банка
        [HttpGet]
        //[Route("client/all")]
        public ActionResult ReedAll()
        {
            ViewBag.Header = "ПЕРЕЧЕНЬ ВСЕХ КЛИЕНТОВ БАНКА";
            IList<Client_ViewModel> clients = clientService.GetAll()
                .Select(_ => _.ClientFromDomainToView())
                .ToList()
                ;
            return View(clients);
        }

        // Отображение одного запрашиваемого по Id клиента банка
        [HttpGet]
        //[Route("client/one")]
        public ActionResult ReedOne_Get_1()
        {
            ViewBag.Message = "Поиск клиента по ID:";
            return View();
        }
        [HttpGet]
        //[Route("client/one/{id:int}")]
        public ActionResult ReedOne_Get_2(int id)
        {
            Client_ViewModel client = clientService.Get(id).ClientFromDomainToView();
            if (client == null)
            {
                ModelState.AddModelError("GetClientById", "Клиент с запрашиваемым  идентификатором не существует!!!");
                return new HttpStatusCodeResult(404, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("GetClientNotVal", "Сведения о запрашиваемом клиенте не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                ViewBag.Message = $"Сведения о клиенте с ID № {id}:";
                return View(client);
            }
        }

        // Создание нового клиента банка
        [HttpGet]
        //[Route("client/create")]
        public ActionResult Create_Get()
        {
            ViewBag.Message = "Добавление нового клиента:";
            return View();
        }

        [HttpPost]
        //[Route("Client/CreatCreate_Poste_Post")]
        public ActionResult Create_Post(Client_ViewModel inst)
        {
            if (inst == null)
            {
                ModelState.AddModelError("CreateClientNull", "Не указаны данные для создания клиента!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CreateClientNotVal", "Указанные для создания клиента данные не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена! Проверьте введенные сведения на достоверность!";
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ContainsKey("CreateClientNotVal").ToString());
                return View("Create_Get");
            }
            else
            {
                clientService.Create(inst.ClientFromViewToDomain());
                ViewBag.Message = $"Добавление нового клиента успешно завершено !";
                return View();
            }
        }
        // Обновление сведений о клиенте банка
        [HttpGet]
        //[Route("client/update")]
        public ActionResult Update_Get(int id)
        {
            Client_ViewModel client = clientService.Get(id).ClientFromDomainToView();
            if (client == null)
            {
                ModelState.AddModelError("UpdateClientById", "Клиент с запрашиваемым  идентификатором не существует!!!");
                return new HttpStatusCodeResult(404, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("UpdateClientNotVal1", "Указанные для обновления сведения о клиенте не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                ViewBag.Message = $"Обновление сведений о клиенте c ID № {id}:";
                return View(client);
            }
        }
        [HttpPut]
        //[Route("client/update/{id:int}")]
        public ActionResult Update_Put(Client_ViewModel inst)
        {
            if (inst == null)
            {
                ModelState.AddModelError("UpdateClientNull", "Не указаны данные для обновления сведений о клиенте!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("UpdateClientNotVal2", "Указанные для обновления сведения о клиенте не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            else
            {
                clientService.Update(inst.ClientFromViewToDomain());
                ViewBag.Message = $"Обновление сведений о клиенте c ID № {inst.Id} прошло успешно!";
                return View();
            }
        }

        // Удаление клиента 
        [HttpGet]
        //[Route("client/delete")]
        public ActionResult Delete_Get_1()
        {
            ViewBag.Message = "Введите идентификационный номер (ID) клиента, подлежащего удалению:";
            return View();
        }
        [HttpGet]
        //[Route("client/delete/{id:int}")]
        public ActionResult Delete_Get_2(int id)
        {
            Client_ViewModel client = clientService.Get(id).ClientFromDomainToView();
            if (client == null)
            {
                ModelState.AddModelError("DeleteClient1", "Не найден клиент для удаления с указанным идентификатором!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DelClientNotVal1", "Указанные для обновления сведения о клиенте не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            ViewBag.Message = $"Подтвердите удаление клиента c ID № {id}:";
            return View(client);
        }
        [HttpDelete]
        //[Route("client/delete/{id:int}")]
        public ActionResult Delete_End(int id)
        {
            Client_ViewModel temp = clientService.Get(id).ClientFromDomainToView();
            if (temp == null)
            {
                ModelState.AddModelError("DeleteClient2", "Не найден клиент для удаления с указанным идентификатором!!!");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("UpdateClientNotVal2", "Указанные для обновления сведения о клиенте не валидны!!!");
                ViewBag.Message = "Валидация НЕ пройдена";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.ToString());
            }
            clientService.Delete(id);
            ViewBag.Message = $"Удаление клиента c ID № {id} прошло успешно!";
            return View();
        }
    }
}