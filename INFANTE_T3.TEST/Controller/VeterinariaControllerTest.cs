using System.Collections.Generic;
using INFANTE_T3.WEB.Controllers;
using INFANTE_T3.WEB.Models;
using INFANTE_T3.WEB.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace INFANTE_T3.TEST.Controller;

public class VeterinariaControllerTest
{
     [Test]
    public void Test_Index1()
    {

        var mockIndex = new Mock<IVeterinariaRepositorio>();
        mockIndex.Setup(o => o.Listar_Veterinarias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockIndex.Object, null);
        var result = controller.Index();
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ViewResult>(result);

    }
    
    [Test]
    public void Test_Crear2()
    {

        var mockCrear = new Mock<IVeterinariaRepositorio>();
        mockCrear.Setup(o => o.Listar_Veterinarias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockCrear.Object, null);
        var result = controller.Crear(2);
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public void Test_Guardar3()
    {

        var mockGuardar = new Mock<IVeterinariaRepositorio>();
        mockGuardar.Setup(o => o.Listar_Veterinarias()).Returns(new List<Veterinaria>());

        var controller = new VeterinariaController(mockGuardar.Object, null);
        var result = controller.Guardar(new Veterinaria(){Id=1, NombreMascota  = "minino", sexo  ="hembra" });
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void Test_Eliminar6()
    {

        var mockEliminar = new Mock<IVeterinariaRepositorio>();

        var controller = new VeterinariaController(mockEliminar.Object, null);
        var result = controller.Delete(2);
        
        Assert.IsNotNull(result);
    }

    [Test]
    public void Test_Editar_Get5()
    {

        var mockEditar_Get = new Mock<IVeterinariaRepositorio>();
        mockEditar_Get.Setup(o => o.Not_ID(2))
            .Returns(new Veterinaria() {Id = 3, NombreMascota = "Saltar", sexo  = "Por las tardes"});

        var controller = new VeterinariaController(mockEditar_Get.Object, null);
        var result = controller.Editar(2);
        
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Test_Refresh4()
    {

        var mockRefresh= new Mock<IVeterinariaRepositorio>();

        var controller = new VeterinariaController(mockRefresh.Object, null);
        var result = controller.Refresh(new Veterinaria());
        
        Assert.IsNotNull(result);
    }
    
}