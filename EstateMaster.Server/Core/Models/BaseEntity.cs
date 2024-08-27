using System.ComponentModel.DataAnnotations;

public abstract class BaseEntity
{
    public int id { get; set; }

    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
