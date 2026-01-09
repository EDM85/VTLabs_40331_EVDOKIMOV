using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDOKIMOV.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; } // id блюда

        public string Name { get; set; } = string.Empty; // название блюда

        public string Description { get; set; } = string.Empty; // описание блюда

        public int Calories { get; set; } // количество калорий на порцию

        public string Image { get; set; } = string.Empty; // путь к файлу изображения

        // внешний ключ
        public int CategoryId { get; set; }

        // навигационное свойство
        // группа блюд например, супы, вторые блюда, гарниры
        public Category? Category { get; set; }
    }
}
