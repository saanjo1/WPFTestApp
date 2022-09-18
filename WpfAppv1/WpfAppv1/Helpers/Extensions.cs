using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppv1.Models;

namespace WpfAppv1.Helpers
{
    public class Extensions
    {
       private static possectorContext appContext = new possectorContext();

        public static Guid ManageSubcategory(string gender)
        {
            var x = appContext.SubCategories.Where(x => x.Name == gender).FirstOrDefault();
            if (x == null)
            {
                SubCategory subCategory = new SubCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = gender,
                    Deleted = false,
                    CategoryId = new Guid("59f06472-79f7-4fda-a2d4-f24f1eae6e1b")
                };
                var id = subCategory.Id;
                appContext.SubCategories.Add(subCategory);
                appContext.SaveChanges();
                return id;
            }
            else
            {
                return x.Id;
            }
        }
    }
}
