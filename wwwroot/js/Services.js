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

function populateDropdown(categorySelector, subcategorySelector, categoryType) {
    $(categorySelector).change(function () {
        var selectedCategory = $(this).val();
        debugger
        if (selectedCategory) {
            $.ajax({
                url: '/Products/Get' + categoryType, // Dynamically change the URL based on category type
                data: { categoryName: selectedCategory },
                type: 'GET',
                success: function (response) {
                    var subcategoryDropdown = $(subcategorySelector);
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a ' + categoryType.toLowerCase()));

                    $.each(response[categoryType], function (index, Item) {
                        subcategoryDropdown.append($('<option>').text(Item[categoryType]).val(Item[categoryType]));
                        console.log(Item[categoryType]); // Log individual category type names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            $(subcategorySelector).empty();
        }
    });
}

// Usage for ProductCategory and SubCategory
$(document).ready(function () {
    populateDropdown('#ProductCategory', '#SubCategory', 'subCategory');
});

// Usage for SubCategory and SubSubCategory
$(document).ready(function () {
    populateDropdown('#SubCategory', '#SubSubCategory', 'SubSubCategory');
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