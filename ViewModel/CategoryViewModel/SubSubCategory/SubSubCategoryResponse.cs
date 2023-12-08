using Prod_Manger.ViewModel.CategoryViewModel.SubCategory1;

namespace Prod_Manger.ViewModel.CategoryViewModel.SubSubCategory
{
    public class SubSubCategoryResponse
    {
        public SubSubCategoryResponse()
        {
            subSubCategory = new List<SubSubCategoryViewModel>();
        }

        public List<SubSubCategoryViewModel> subSubCategory { get; set; }

    }
}
