using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject
{//2.Создайте класс контекста данных:
    class EntityContext : DbContext
    {
        public EntityContext(string v) : base("Lab7GKH")
        {
            //5.В конструкторе класса контекста укажите необходимость
            //использования созданного инициализатора БД:
            Database.SetInitializer(new DataBaseInitializer()); 

        }
        public DbSet<Notice> Notices { get; set; }
    }
}
