using INFANTE_T3.WEB.DB;
using INFANTE_T3.WEB.Models;
using INFANTE_T3.WEB.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace INFANTE_T3.WEB.Controllers;

public class VeterinariaController : Controller
{
    private readonly IVeterinariaRepositorio _veterinariaRepositorio;

    private DBEntities _dbEntities;

    public VeterinariaController(IVeterinariaRepositorio veterinariaRepositorio, DBEntities dbEntities)
    {
        _veterinariaRepositorio = veterinariaRepositorio;
        _dbEntities = dbEntities;
    }
    
    
    public IActionResult Index()
    {
        var result = _veterinariaRepositorio.Listar_Veterinarias().ToList();
        //return View(NOTAS);
        return View(result);
    }

    public IActionResult Crear( int id)
    {
        ViewBag.Id = id;
        return View(new Veterinaria());
    }

    public IActionResult Guardar(Veterinaria veterinaria)
    {
        _veterinariaRepositorio.Guar_Veterinaria(veterinaria);
        return RedirectToAction("Index");
        
    }
    
    public IActionResult Delete(int id)
    {
        _veterinariaRepositorio.Elim_Veterinaria(id);
        return RedirectToAction("Index");
    }
    
    public IActionResult Editar(int id)
    {
        var result = _veterinariaRepositorio.Not_ID(id);
        return View(result);
    }

    public IActionResult Refresh(Veterinaria veterinaria)
    {
        _veterinariaRepositorio.Edit_Veterinaria(veterinaria);
        return RedirectToAction("Index");
    }
       
}