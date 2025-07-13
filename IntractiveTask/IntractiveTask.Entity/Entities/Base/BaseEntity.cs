using IntractiveTask.Entity.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Entities.Base;

/// <summary>
/// Will use for all entities in the project.
/// </summary>
public class BaseEntity : ISoftDelete
{
    public BaseEntity()
    {
        IsActive = true;
        IsDeleted = false;
        CreatedDate = DateTime.Now;

    }
    [Key]
    public int Id { get; set; }
    public int? CreatedById { get; set; }
    public int? UpdatedById { get; set; }
    public int? DeletedById { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
