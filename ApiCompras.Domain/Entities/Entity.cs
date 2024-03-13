using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCompras.Domain.Entities;

public abstract class Entity
{
    public int Id { get; private set; }
    public DateTime CreateDate { get; private set; } = DateTime.Now;
    public DateTime? UpdateDate { get; private set; }

    public void Update()
        => UpdateDate = DateTime.Now;
    public void UpdateId(int id) => Id = id;

}
