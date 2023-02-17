using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BreadService.Domain
{
    public class Bread 
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int CheeseId { get; set; }
        public Cheese Cheese { get; set; }
    }
}