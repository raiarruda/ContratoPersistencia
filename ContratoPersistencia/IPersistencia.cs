namespace ContratoPersistencia;

public interface IPersistencia
{
    void Incluir(IEntidade entidade);
    void Atualizar(IEntidade entidade);
    List<IEntidade> Buscar(Type tipoEntidade);
    void Apagar(IEntidade entidade);
}