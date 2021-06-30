using waSeguros.Models;

namespace waSeguros
{
    public abstract class LogicInit<T> where T : class
    {
        internal abstract void init(SegurosContext _db);
    }
}