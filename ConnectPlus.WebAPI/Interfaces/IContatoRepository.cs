using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.Interfaces;

public interface IContatoRepository
{
    List<Contato> Listar();
    void Cadastrar(Contato novoContato);
    void Atualizar(Guid id, Contato novoContato);
    Contato BuscarPorId(Guid id);
    void Deletar(Guid id);
}