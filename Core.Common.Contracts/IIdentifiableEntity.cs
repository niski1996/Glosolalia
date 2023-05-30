using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Common.Contracts
{
    public interface IIdentifiableEntity
    {
        [NotMapped]
        int Id { get; set; }
    }

}