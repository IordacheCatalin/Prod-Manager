namespace Prod_Manger.ViewModel.CategoryViewModel.Primarycategory
{
    public class PrimaryCategoryResponse
    {
        public PrimaryCategoryResponse()
        {
            CategoryName = new List<CategoryViewModel>();
        }

        public List<CategoryViewModel> CategoryName { get; set; }
    }
}
