using Microsoft.AspNetCore.Mvc;
using Avaliacao3Lp3.ViewModels;

namespace Avaliacao3Lp3.Controllers;

public class LojaController : Controller
{
    private static List<LojaViewModel> lojas = new List<LojaViewModel>{
        new LojaViewModel (1, 1, "Tênis Brasil", "Aqui você encontra os tênis", true, "tenis@email.com"),
        new LojaViewModel (2, 3, "Lembranças Já", "Vem comprar sua lembrança", false, "lemb@email.com"),
        new LojaViewModel (3, 1, "Sorvetinho Gelado", "Sorvetinho Gelado", false, "sorvet@email.com"),
    };

    public IActionResult Index ()
    {
        return View(lojas);
    }

    public IActionResult Detalhes(int id)
    {
        return View(lojas[id-1]);  
    }

    public IActionResult Cadastro ()
    {
        return View();
    }

    public IActionResult Gerente()
    {
        return View(lojas);
    }

    public IActionResult Mensagem ()
    {
        return View();
    }

    public IActionResult GerarLoja(int id, int piso, string nome, string descricao, bool loja, string email)
    {
        foreach (var item in lojas)
        {
            if(nome == item.Nome){
                ViewData["Nome"] = nome;

                return RedirectToAction("Mensagem", TempData["Mensagem"] = "Atenção, já existe uma loja com esse nome!");
            }
        }

        id = lojas.Count + 1;
        lojas.Add(new LojaViewModel(id, piso, nome, descricao, loja, email));

        return RedirectToAction("Mensagem", TempData["Mensagem"]  = "Loja cadastrada com sucesso!");
    }

    public IActionResult ExcluirLoja (int id)
    {
        lojas.RemoveAt(id - 1);

        for(var i = id - 1; i < lojas.Count; i++)
        {
            lojas[i].Id -= 1;
        }

        return RedirectToAction("Mensagem", TempData["Mensagem"] = "Loja removida com sucesso.");
    }
}