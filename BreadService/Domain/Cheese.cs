using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BreadService.Domain
{
    public class Cheese
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
    }
}