using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Common.Contracts
{
    public interface IIdentifiableEntity
    {
        int Id { get; set; }
    }

}