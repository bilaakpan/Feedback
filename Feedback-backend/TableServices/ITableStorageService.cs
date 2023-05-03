using Feedback_backend.TableEntities;

namespace Feedback_backend.TableServices
{
    public interface ITableStorageService
    {
        bool Insert(Feedback entity);
    }
}
