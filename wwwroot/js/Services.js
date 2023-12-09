//$(document).ready(function () {
//    $('#ProductCategory').change(function () {
//        var selectedCategory = $(this).val();

//        if (selectedCategory) {
//            $.ajax({
//                url: '/Products/GetSubcategory',
//                data: { categoryName: selectedCategory },
//                type: 'GET',
//                success: function (response) {
//                    var subcategoryDropdown = $('#SubCategory');
//                    subcategoryDropdown.empty();
//                    subcategoryDropdown.append($('<option>').text('Select a subcategory'));

//                    $.each(response.subCategory, function (index, Item) {
//                        subcategoryDropdown.append($('<option>').text(Item.subCategory).val(Item.subCategory));
//                        console.log(Item.subCategory); // Log individual subcategory names
//                    });
//                },
//                error: function () {
//                    // Handle error if any
//                }
//            });
//        } else {
//            $('#SubCategory').empty();
//        }
//    });
//});

function populateDropdown(sourceSelector, targetSelector, categoryType) {
    $(sourceSelector).change(function () {
        var selectedCategory = $(sourceSelector).val();
        var selectedSubCategory = $(targetSelector).val(); // Get the selected subcategory

        if (selectedCategory) {
            var url = '/Products/Get' + categoryType;

            // If both category and subcategory are selected, update the URL and data
            if (selectedSubCategory) {
                url += 'ForCategoryAndSubcategory';
            }

            $.ajax({
                url: url,
                data: {
                    categoryName: selectedCategory,
                    subCategory: selectedSubCategory
                },
                type: 'GET',
                success: function (response) {
                    var dropdown = $(targetSelector);
                    dropdown.empty();
                    dropdown.append($('<option>').text('Select a ' + categoryType.toLowerCase()));

                    $.each(response[categoryType], function (index, item) {
                        dropdown.append($('<option>').text(item[categoryType]).val(item[categoryType]));
                        console.log(item[categoryType]); // Log individual category type names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            $(targetSelector).empty();
        }
    });
}

// Usage for Category and SubCategory
$(document).ready(function () {
    populateDropdown('#ProductCategory', '#SubCategory', 'subCategory');
});

// Usage for Category, SubCategory, and SubSubCategory
$(document).ready(function () {
    populateDropdown('#SubCategory', '#SubSubCategory', 'subSubCategory');
});

function sellProduct(productId) {
    event.preventDefault();

    $.ajax({
        type: "POST",
        url: "/Products/Sell",
        data: { id: productId },
        success: function (response) {
            if (response.success) {
                alert("Product sold successfully!");
               
                window.location.href = "/Products/Index";
            } else {
                alert("Error: " + response.errorMessage);
            }
        },
        error: function (xhr, status, error) {
            
            alert("Error: Unable to sell the product.");
        }
    });
}