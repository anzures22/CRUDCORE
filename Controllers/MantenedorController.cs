using CRUDCORE.Datos;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        AlumnoDatos _AlumnoDatos = new AlumnoDatos();

        public IActionResult Listar()
        {
            // LA VISTA MOSTRARÁ UNA LISTA DE ALUMNOS
            var oLista = _AlumnoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // MÉTODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(AlumnoModel oAlumno)
        {
            // MÉTODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AlumnoDatos.Guardar(oAlumno);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(string Matricula)
        {
            // MÉTODO SOLO DEVUELVE LA VISTA
            var oAlumno = _AlumnoDatos.Obtener(Matricula);
            return View(oAlumno);
        }

        [HttpPost]
        public IActionResult Editar(AlumnoModel oAlumno)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AlumnoDatos.Editar(oAlumno);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(string Matricula)
        {
            // MÉTODO SOLO DEVUELVE LA VISTA
            var oAlumno = _AlumnoDatos.Obtener(Matricula);
            return View(oAlumno);
        }

        [HttpPost]
        public IActionResult Eliminar(AlumnoModel oAlumno)
        {
            var respuesta = _AlumnoDatos.Eliminar(oAlumno.Matricula);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
