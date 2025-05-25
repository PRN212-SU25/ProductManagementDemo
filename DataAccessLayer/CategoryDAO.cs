using BusinessObjects;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            Category beverager = new Category(1, "Beverages");
            Category condiments = new Category(2, "Condiments");
            Category confections = new Category(3, "Confections");
            Category dairy = new Category(4, "Dairy Products");
            Category grains = new Category(5, "Grains/Cereals");
            Category meat = new Category(6, "Meat/Poultry");
            Category produce = new Category(7, "Produce");
            Category seafood = new Category(8, "Seafood");

            var listCatergories = new List<Category>();
            try
            {
                listCatergories.Add(beverager);
                listCatergories.Add(condiments);
                listCatergories.Add(confections);
                listCatergories.Add(dairy);
                listCatergories.Add(grains);
                listCatergories.Add(meat);
                listCatergories.Add(produce);
                listCatergories.Add(seafood);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listCatergories;

        }
    }
}
