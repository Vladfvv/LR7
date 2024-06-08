using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject
{
    //3.Для того, чтобы новая база данных при создании заполнялась
    // исходными данными, создайте класс инициализации базы данных
    class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {//4.В созданном классе переопределите метод
        //Seed для инициализации начальных значений :
        protected override void Seed(EntityContext context)
        {
            context.Notices.AddRange(new Notice[] {
                new Notice { Date="2024-06-07", AccountNumber="157287", Client="Ivanov", Summa=2000.0 },
                new Notice { Date="2024-05-01", AccountNumber="253874", Client="Smirnov", Summa=1800.50 },
                new Notice { Date="2024-04-10", AccountNumber="553377", Client="Petrov", Summa=1500.10 },
                new Notice { Date="2024-04-03", AccountNumber="123456", Client="Sidorov", Summa=3000.55 },
 });
        }
    }
}
