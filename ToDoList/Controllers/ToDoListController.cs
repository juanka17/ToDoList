using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : Controller
    {

        public static List<tareas> Milista = new List<tareas>();
        [HttpGet]
        public ActionResult<IEnumerable<tareas>> Get()
        {
            return Milista;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromBody] tareas nohice)
        {
            Milista.Add(nohice);
            return new string[] { "status", "200" };
        }


        [HttpPut]
        public ActionResult<IEnumerable<string>> Put([FromBody] tareas itemTask)
        {
            int index = 0;
            foreach (tareas item in Milista)
            {
                if (item.id == itemTask.id)
                {
                    Milista[index].nombre = itemTask.nombre;
                    Milista[index].complete = itemTask.complete;
                    return new string[] { "1234", "Actualizado" };
                }
                index++;
            }
            return new string[] { "101", "registro no encontrado" };
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> Delete(string id)
        {
            int index = 0;
            foreach (tareas item in Milista)
            {
                if (item.id == id)
                {
                    Milista.Remove(item);
                    return new string[] { "200", "Tarea Eliminada!!" };
                }
                index++;
            }

            return new string[] { "200", "Tarea eliminadao" };
        }
    }
}