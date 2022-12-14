using VoeAirlines.Services;
using VoeAirlines.ViewModels;
using Microsoft.AspNetCore.Mvc;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult AdicionarLogin(AdicionarLoginViewModel dados)
    {
        var login = _loginService.AdicionarLogin(dados);
        return Ok(_loginService.ListarLogin());
    }

    [HttpGet]
    public IActionResult ListarLogin()
    {
        return Ok(_loginService.ListarLogin());
    }

    [HttpGet("{id}")]
    public IActionResult ListarLoginPeloId(int id)
    {
        var login = _loginService.ListarLoginId(id);

        if (login != null)
        {
            return Ok(login);
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarLogin(int id, AtualizarLoginViewModel dados)
    {
        if (id != dados.Id)
            return BadRequest("O id informado na URL � diferente do id informado no corpo da requisi��o.");

        var login = _loginService.AtualizarLogin(dados);
        return Ok(login);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarLogin(int id)
    {
        _loginService.DeletarLogin(id);
        return NoContent();
    }
}