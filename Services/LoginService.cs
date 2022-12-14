using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.Validators;
using VoeAirlines.ViewModels;
using FluentValidation;
namespace VoeAirlines.Services;

public class LoginService
{
    private readonly VoeAirlinesContext _context;

    public LoginService(VoeAirlinesContext context)
    {
        _context = context;
    }

    public DetalhesLoginViewModel AdicionarLogin(AdicionarLoginViewModel dados)
    {
        var login = new Login(dados.Usuario, dados.Senha, dados.DataCriacao);
        _context.Add(login);//adiciona o objeto ao ciclo do EF
        _context.SaveChanges();//salva as mudanças no context

        return new DetalhesLoginViewModel
        (
            login.Id,
            login.Usuario,
            login.Senha,
            login.DataCriacao
        );
    }

    public IEnumerable<ListarLoginViewModel> ListarLogin()
    {
        return _context.Logins.Select(I => new ListarLoginViewModel(I.Id, I.Usuario, I.DataCriacao));
    }

    public ListarLoginIdViewModel? ListarLoginId(int id)
    {
        var login = _context.Logins.Find(id);

        if (login != null)
        {
            return new ListarLoginIdViewModel
            (
                login.Id,
                login.Usuario,
                login.DataCriacao
            );
        }

        return null;
    }

    public DetalhesLoginViewModel? AtualizarLogin(AtualizarLoginViewModel dados)
    {
        //_atualizarLoginValidator.ValidateAndThrow(dados);

        var login = _context.Logins.Find(dados.Id);

        if (login != null)
        {
            login.Id = dados.Id;
            login.Usuario = dados.Usuario;
            login.Senha = dados.Senha;
            login.DataCriacao = dados.DataCriacao;

            _context.Update(login);
            _context.SaveChanges();

            return new DetalhesLoginViewModel(login.Id, login.Usuario, login.Senha, login.DataCriacao);
        }

        return null;
    }

    public void DeletarLogin(int id)
    {
        //_excluirLoginValidator.ValidateAndThrow(id);

        var login = _context.Logins.Find(id);

        if (login != null)
        {
            _context.Remove(login);
            _context.SaveChanges();
        }
    }
}