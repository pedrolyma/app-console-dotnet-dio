using System.Collections.Generic;

namespace dio.series.Interfaces {
    public interface IRepositorio<T> {
        List<T> lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Atualiza(int id, T entidade);
        int ProximoId();
        void Exclui(int id);
    }
}