namespace Prod_Manger.Models.Domain
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SubCategory { get; set; }
        public string? SubSubCategory { get; set; }
        public string? SubSubSubCategory { get; set; }
        public string? SubSubSubSubCategory { get; set; }
    }
}
