namespace LeaveManagementApplication.Domain.Common;

public interface IAuditEntity
{
    public DateTime CreatedDate { get; set; }

    public string CreateUserId { get; set; }
    public DateTime ModifyDate { get; set; }

    public string ModifyUserId { get; set; }
    public bool IsActive { get; set; }
    public int StatusId { get; set; }
}

public abstract class AuditEntity<T> : Entity<T>, IAuditEntity
{
    public DateTime CreatedDate { get; set; }

    public string CreateUserId { get; set; }
    public DateTime ModifyDate { get; set; }

    public string ModifyUserId { get; set; }
    public bool IsActive { get; set; } = true;
    public int StatusId { get; set; }
}

public abstract class BaseEntity
{
}

public interface IEntity<T>
{
    T Id { get; set; }
}

public abstract class Entity<T> : BaseEntity, IEntity<T>

{
    public virtual T Id { get; set; }
}