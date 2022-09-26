namespace Avaliacao3Lp3.ViewModels;

public class LojaViewModel
{
    public int Id { get; set; }
    public int Piso { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Loja { get; set; }
    public string Email { get; set; }

    public LojaViewModel(int id, int piso, string nome, string descricao, bool loja, string email)
    {
        Id = id;
        Piso = piso;
        Nome = nome; 
        Descricao = descricao;
        Loja = loja;
        Email = email;
    }
}