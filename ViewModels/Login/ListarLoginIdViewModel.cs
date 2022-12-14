using System;

namespace VoeAirlines.ViewModels;

public class ListarLoginIdViewModel
{
    public ListarLoginIdViewModel(int id, string? usuario, DateTime? dataCriacao)
    {
        Id = id;
        Usuario = usuario;
        DataCriacao = dataCriacao;
    }
    public int Id { get; set; }
    public string? Usuario { get; set; }
    public DateTime? DataCriacao { get; set; }
}