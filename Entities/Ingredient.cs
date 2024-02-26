using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_maui.Entities
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        [Indexed]
        public int CourseId { get; set; }
    }
}
