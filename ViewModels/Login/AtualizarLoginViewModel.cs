namespace VoeAirlines.ViewModels;

public class AtualizarLoginViewModel
{
    public AtualizarLoginViewModel(int id, string usuario, string senha)
    {
        Id = id;
        Usuario = usuario;
        Senha = senha;
    }

    public int Id { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public DateTime DataCriacao { get; internal set; }
}