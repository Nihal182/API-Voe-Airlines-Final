using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;

namespace VoeAirlines.Services;

public class LoginService 
{

    private readonly VoeAirlinesContext _context;

    public LoginService(VoeAirlinesContext context){

        _context = context;

    }

    public DetalhesLoginViewModel AdicionarLogin(AdicionarLoginViewModel dados) 
    {
        var login = new Login (dados.Usuario, dados.Senha, dados.DataCriacao);

        _context.Add(login); //Adicionar o objeto no ciclo de vida do Entity Framework
        _context.SaveChanges(); //Salva as mudanças no contexto

        return new DetalhesLoginViewModel
        (
            login.Id,
            login.Usuario,
            login.DataCriacao
        );
    }

    public IEnumerable<ListarLoginViewModel> ListarLogin()
    {
        return _context.Logins.Select(l => new ListarLoginViewModel(l.Usuario, l.DataCriacao));
    }


}