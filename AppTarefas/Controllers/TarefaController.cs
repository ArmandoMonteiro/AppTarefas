using AppTarefas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefaController : Controller
    {

        
        public ActionResult ListarTarefas()
        {
            Tarefa objTarefa = new Tarefa();

            return View(objTarefa.ListarTarefas());
        }

        
        public ActionResult Create()
        {
            
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Tarefa objTarefa)
        {
            try
            {
                objTarefa.CriarTarefa(objTarefa);

                return RedirectToAction("ListarTarefas");
            }
            catch
            {
                return View();
            }
        }

        
        
        public ActionResult Delete(int id)
        {
            Tarefa objTarefa = new Tarefa();
            objTarefa.ApagarTarefa(id);
            return RedirectToAction("ListarTarefas");
        }

        public ActionResult Update(int Id)
        {
            Tarefa objTarefa = new Tarefa();
            objTarefa = objTarefa.BuscarTarefa(Id);

            Status ObjStatus = new Status();
            List<Status> dadosStatus = ObjStatus.ListarStatus();
            SelectList lista = new SelectList(dadosStatus, "IdStatus", "DescStatus");
            ViewBag.ListaStatus = lista;

            return View(objTarefa);
        }

        [HttpPost]
        public ActionResult Update(int id, int IdStatus)
        {
            Tarefa objTarefa = new Tarefa();
            objTarefa.AlterarTarefa(id,IdStatus);
            return RedirectToAction("ListarTarefas");
        }
    }
}
