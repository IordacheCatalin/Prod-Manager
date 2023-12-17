$(document).ready(function () {
    $('#ProductCategory').change(function () {
        const selectedCategory = $(this).val();
        const subcategoryShow = $('#subcategory');
        if (selectedCategory) {
            $.ajax({
                url: '/Products/GetSubcategory',
                data: { categoryName: selectedCategory },
                type: 'GET',
                success: function (response) {
                    var subcategoryDropdown = $('#SubCategory');
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a SubCategory'));
                    subcategoryShow.show();

                    $.each(response.subCategory, function (index, Item) {
                        subcategoryDropdown.append($('<option>').text(Item.subCategory).val(Item.subCategory));
                        console.log(Item.subCategory); // Log individual subcategory names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            $('#SubCategory').empty();
        }
    });

    $('#SubCategory').change(function () {
        const selectedCategory = $('#ProductCategory').val(); // Assuming #Category is the ID of your category dropdown
        const selectedSubCategory = $('#SubCategory').val();
        const subcategoryDropdown = $('#SubSubCategory');
        const subsubcategoryShow = $('#subsubcategory');

        if (selectedCategory && selectedSubCategory) {
            $.ajax({
                url: '/Products/GetSubSubCategory',
                data: { categoryName: selectedCategory, subCategory: selectedSubCategory }, // Send both category and subcategory
                type: 'GET',
                success: function (response) {
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a SubSubCategory'));
                    subsubcategoryShow.show();
                    $.each(response.subSubCategory, function (index, Item) {
                        subcategoryDropdown.append($('<option>').text(Item.subSubCategory).val(Item.subSubCategory));
                        console.log(Item.subSubCategory); // Log individual subcategory names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            subcategoryDropdown.empty();
            subcategoryDropdown.append($('<option>').text('Select both category and subcategory'));
        }
    });

    $('#SubSubCategory').change(function () {
        const selectedCategory = $('#ProductCategory').val(); // Assuming #Category is the ID of your category dropdown
        const selectedSubCategory = $('#SubCategory').val();
        const selectedSubSubCategory = $('#SubSubCategory').val();
        const subcategoryDropdown = $('#SubSubSubCategory');
        const subsubsubcategoryShow = $('#subsubsubcategory');

        if (selectedCategory && selectedSubCategory) {
            $.ajax({
                url: '/Products/GetSubSubSubCategory',
                data: { categoryName: selectedCategory, subCategory: selectedSubCategory, subSubCategory: selectedSubSubCategory }, // Send both category and subcategory
                type: 'GET',
                success: function (response) {
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a SubSubSubCategory'));
                    subsubsubcategoryShow.show();
                    $.each(response.subSubSubCategory, function (index, Item) {
                        subcategoryDropdown.append($('<option>').text(Item.subSubSubCategory).val(Item.subSubSubCategory));
                        console.log(Item.subSubSubCategory); // Log individual subcategory names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            subcategoryDropdown.empty();
            subcategoryDropdown.append($('<option>').text('Select first category, subcategory, subsubcategory'));
        }
    });

    $('#SubSubSubCategory').change(function () {
        const selectedCategory = $('#ProductCategory').val(); // Assuming #Category is the ID of your category dropdown
        const selectedSubCategory = $('#SubCategory').val();
        const selectedSubSubCategory = $('#SubSubCategory').val();
        const selectedSubSubSubCategory = $('#SubSubSubCategory').val();
        const subcategoryDropdown = $('#SubSubSubSubCategory');
        const subsubsubsubcategoryShow = $('#subsubsubsubcategory');

        if (selectedCategory && selectedSubCategory) {
            $.ajax({
                url: '/Products/GetSubSubSubSubCategory',
                data: { categoryName: selectedCategory, subCategory: selectedSubCategory, subSubCategory: selectedSubSubCategory, subSubSubCategory: selectedSubSubSubCategory }, // Send both category and subcategory
                type: 'GET',
                success: function (response) {
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a SubSubSubSubCategory'));
                    subsubsubsubcategoryShow.show();
                    $.each(response.subSubSubSubCategory, function (index, Item) {
                        subcategoryDropdown.append($('<option>').text(Item.subSubSubSubCategory).val(Item.subSubSubSubCategory));
                        console.log(Item.subSubSubSubCategory); // Log individual subcategory names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            subcategoryDropdown.empty();
            subcategoryDropdown.append($('<option>').text('Select first category, subcategory, subsubcategory, subsubsubcategory'));
        }
    });

    $('#sell-item-form').on('submit', function (event) {
        console.log('submit')
        event.preventDefault();
        let productId = document.getElementById("productId").value;
        let ItemQuantity = document.getElementById("ItemQuantity_" + productId).value;
       
        sellProduct(productId, ItemQuantity); // Execute the sellProduct function
    });    
});

function sellProduct(productId, ItemQuantity) {
    $.ajax({
        type: "POST",
        url: "/Products/Sell",
        data: { id: productId, ItemQuantity: ItemQuantity },
        success: function (response) {
            if (response.success) {
                let quantity = document.getElementById("ItemQuantity_" + productId).value;
                alert(`Product sold successfully! ${quantity} pcs`);
                window.location.href = "/Products/Index"; // Redirect on success
            } else {
                alert("Error: " + response.errorMessage);
            }
        },
        error: function (xhr, status, error) {
            alert("Error: Unable to sell the product.");
        }
    });
}