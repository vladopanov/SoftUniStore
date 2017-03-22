using SoftUniStore.Data;

namespace SoftUniStore.Services
{
    public abstract class Service
    {
        protected readonly UnitOfWork data;

        protected Service(UnitOfWork data)
        {
            this.data = data;
        }
    }
}
