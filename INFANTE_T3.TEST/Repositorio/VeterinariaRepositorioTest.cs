using System.Collections.Generic;
using System.Linq;
using INFANTE_T3.TEST.Helpers;
using INFANTE_T3.WEB.DB;
using INFANTE_T3.WEB.Models;
using INFANTE_T3.WEB.Repositorio;
using Moq;
using NUnit.Framework;

namespace INFANTE_T3.TEST.Repositorio;

public class VeterinariaRepositorioTest
{
    private IQueryable<Veterinaria> data;
    private Mock<DBEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<Veterinaria>
        {
            new Veterinaria() {Id = 1, NombreMascota  = "minino", sexo  = "hembra"},
            new Veterinaria() {Id = 2, NombreMascota  = "tokio", sexo  = "macho"},
            new Veterinaria() {Id = 3, NombreMascota  = "slan", sexo  = "hembra"}

        }.AsQueryable();

       var mockDbsetVeterinaria = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
      mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetVeterinaria.Object);
    }
    
 
    
    [Test]

    public void Test_GuardNota1()
    {
        var mockDbsetNota = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetNota.Object);
        var repositorio = new Veterinaria_Repositorio(mockDB.Object);
        repositorio.Guar_Veterinaria(new Veterinaria(){Id = 2,NombreMascota  = "Salena",sexo  = "HEMBRA"});
        
        mockDbsetNota.Verify(o => o.Add(It.IsAny<Veterinaria>()), Times.Once);        
    }
    //--------------------------------
    
    [Test]

    public void Test_ObNotasID2()
    {
        var repositorio = new Veterinaria_Repositorio(mockDB.Object);
        var resultado = repositorio.Not_ID(1);
        
        Assert.AreEqual(1,resultado.Id);
        
    }
    //---------------------------
    
    
    [Test]

    public void Test_Editar3()
    {
        var repositorio = new Veterinaria_Repositorio(mockDB.Object);
        var resultado = repositorio.Not_ID(1);
        
        Assert.AreEqual(1,resultado.Id);
        
    }
    
    [Test]

    public void Test_Elimnar4()
    {
        var mockDbsetNota = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetNota.Object);
        
        var repositorio = new Veterinaria_Repositorio(mockDB.Object);
        repositorio.Elim_Veterinaria(1);
        
        var mockEliminar = data.First(o => o.Id == 1);
        
        mockDbsetNota.Verify(o => o.Remove(mockEliminar), Times.Once());
        
    }
    
    [Test]

    public void Test_ListarNotas5()
    {
        var repositorio = new Veterinaria_Repositorio(mockDB.Object);
        var resultado = repositorio.Listar_Veterinarias();
        
        Assert.IsNotNull(resultado);
        
    }

}