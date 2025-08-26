using Rftim3Atlas.Models;
using Rftim3Tracer.Services.Databases.MSSQL;
using Rftim3Tracer.Temp.Services.Databases.TSQL;

namespace Rftim3Tracer.Temp.RftMicrosoft.EntityFrameworkCore
{
    public class RftEFCore
    {
        private static readonly IRftGenericCRUDModelService<RftGenericTestModel> rftService =
            new RftGenericCRUDModelService<RftGenericTestModel>(new RftDbContextFactoryMSSQL());

        public RftEFCore()
        {
            //RftCreate();
            //RftReadOne();
            //RftUpdate();
            //RftDelete();

            RftReadAll();
        }

        private static async void RftCreate()
        {
            await rftService.Create(new());
        }

        private static async void RftReadOne()
        {
            RftGenericTestModel? x = await rftService.ReadOne(1);

            if (x is not null) await Console.Out.WriteLineAsync($"{x.Id}: {x.Name} {x.Surname} {x.Age} {x.Timestamp}");
        }

        private static async void RftReadAll()
        {
            List<RftGenericTestModel>? x = await rftService.ReadAll();

            foreach (RftGenericTestModel item in x)
            {
                await Console.Out.WriteLineAsync($"{item.Id}: {item.Name} {item.Surname} {item.Age} {item.Timestamp}");
            }
        }

        private static async void RftUpdate()
        {
            RftGenericTestModel x = new()
            {
                Name = "io",
                Surname = "tu",
                Age = 99,
                Timestamp = DateTime.Now
            };

            await rftService.Update(2, x);
        }

        private static async void RftDelete()
        {
            await rftService.Delete(5);
        }
    }
}
