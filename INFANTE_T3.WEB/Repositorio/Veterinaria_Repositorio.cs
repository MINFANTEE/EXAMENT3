using INFANTE_T3.WEB.DB;
using INFANTE_T3.WEB.Models;

namespace INFANTE_T3.WEB.Repositorio;

public interface IVeterinariaRepositorio
{

    List<Veterinaria> Listar_Veterinarias();

    void Elim_Veterinaria(int id);

    void Edit_Veterinaria(Veterinaria veterinaria);

    Veterinaria Not_ID(int id);

    void Guar_Veterinaria(Veterinaria veterinaria);

}


public class Veterinaria_Repositorio: IVeterinariaRepositorio
{
    private DBEntities _dbEntities;

    public Veterinaria_Repositorio(DBEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }

    public void Guar_Veterinaria(Veterinaria veterinaria)
    {
        _dbEntities.Veterinarias.Add(veterinaria);
        _dbEntities.SaveChanges();
    }
    
    public Veterinaria Not_ID(int id)
    {
        var result=_dbEntities.Veterinarias.First(o => o.Id == id);
        return result;
    }
    
    public void Edit_Veterinaria(Veterinaria veterinaria)
    {
        var result = _dbEntities.Veterinarias.First(o => o.NombreMascota == veterinaria.NombreMascota );
        result.NombreMascota = veterinaria.NombreMascota ;
        result.sexo  = veterinaria.sexo ;
        _dbEntities.SaveChanges();
    }
    
    public void Elim_Veterinaria(int id)
    {
        var result = _dbEntities.Veterinarias.First(o => o.Id == id);
        _dbEntities.Veterinarias.Remove(result);
        _dbEntities.SaveChanges();
    }
    
    public List<Veterinaria> Listar_Veterinarias()
    {
        var result= _dbEntities.Veterinarias.ToList();
        return result;

    }
}