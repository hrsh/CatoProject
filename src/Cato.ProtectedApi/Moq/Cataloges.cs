using System.Collections.Generic;
using System.Linq;

namespace Cato.ProtectedApi.Moq
{
    public class Catalog
    {
        public Catalog(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public int Id { get; }

        public string Title { get; }

        public int Price { get; }
    }

    public class CatalogStore
    {
        public static IEnumerable<Catalog> List =>
            new List<Catalog>
            {
                new Catalog(1, "Catalog 1", 1000),
                new Catalog(2, "Catalog 2", 2000),
                new Catalog(3, "Catalog 3", 3000),
                new Catalog(4, "Catalog 4", 4000),
            };

        public static Catalog Find(int id) =>
            List.FirstOrDefault(a => a.Id == id);
    }
}
