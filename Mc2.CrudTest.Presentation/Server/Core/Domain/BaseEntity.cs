namespace Mc2.CrudTest.Presentation.Server.Core.Domain;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? LastModified { get; set; }
}

