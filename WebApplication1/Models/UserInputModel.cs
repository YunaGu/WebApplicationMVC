using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class UserInputModel
{
    [Key]
    public int MsgId
    {
        get;
        set;
    }
    
    [Required]
    public string UserInput
    {
        get;
        set;
    }

    public DateTime InputTime 
    {
        get;
        set;
    } = DateTime.Now;
}