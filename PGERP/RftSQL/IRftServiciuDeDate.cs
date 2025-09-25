using System.Collections.Generic;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    public interface IRftServiciuDeDate<T>
    {
        Task<IEnumerable<T>> RftReturnareObiecte();

        Task<T> RftReturnareObiectId(int id);

        Task<T> RftAdaugareObiect(T obiect);

        Task<bool> RftStergereObiect(int id);

        Task<T> RftActualizareObiect(int id, T obiect);

    }
}
