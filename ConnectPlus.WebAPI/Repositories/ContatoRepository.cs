using ConnectPlus.Interfaces;
using ConnectPlus.WebAPI.BdContextConnect;
using ConnectPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Atualiza os dados de um contato existente
    /// </summary>
    /// <param name="id">Identificador único do contato</param>
    /// <param name="contato">Objeto contendo os novos dados do contato</param>
    public void Atualizar(Guid id, Contato contato)
    {
        Contato? contatoBuscado = _context.Contatos.Find(id);
        if (contatoBuscado == null)
        {
            contatoBuscado.Nome = contato.Nome;
            contatoBuscado.Imagem = contato.Imagem;
            contatoBuscado.FormaContato = contato.FormaContato;
            contatoBuscado.IdTipoContato = contato.IdTipoContato;

            _context.Contatos.Update(contatoBuscado);
            _context.SaveChanges();

        }
    }

    /// <summary>
    /// Busca um contato pelo seu identificador
    /// </summary>
    /// <param name="id">Id único do contato</param>
    /// <returns>Contato encontrado ou nulo caso não exista</returns>
    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Include(e => e.IdTipoContatoNavigation).FirstOrDefault(e => e.IdContato == id)!;

    }
    /// <summary>
    /// Cadastra um tipo de Contato 
    /// </summary>
    /// <param name="novo">Objeto contendo os dados do evento</param>
    public void Cadastrar(Contato novo)
    {
        _context.Contatos.Add(novo);
        _context.SaveChanges();
    }
    /// <summary>
    /// Deleta um contato existente 
    /// </summary>
    /// <param name="id">Id unico do Contato</param>
    public void Deletar(Guid id)
    {
        Contato? contatoBuscado = _context.Contatos.Find(id);
        if (contatoBuscado != null)
        {
            _context.Contatos.Remove(contatoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Lista todos os contatos Cadastrados
    /// </summary>
    /// <returns>Lista de eventos</returns>
    public List<Contato> Listar()
    {
        return _context.Contatos
            .Include(e => e.IdTipoContatoNavigation).ToList();
    }
}