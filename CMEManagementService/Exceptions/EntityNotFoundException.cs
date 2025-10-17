using System.Net;

namespace CMEManagementService.Exceptions
{
    public class EntityNotFoundException : ServiceException
    {
        public string EntityType { get; }
        public object EntityId { get; }
        
        public EntityNotFoundException(string entityType, object entityId)
            : base($"{entityType} with ID '{entityId}' was not found", HttpStatusCode.NotFound)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}