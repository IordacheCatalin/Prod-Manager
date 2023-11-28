$(document).ready(function () {
    $('#ProductCategory').change(function () {
        var selectedCategory = $(this).val();

        if (selectedCategory) {
            $.ajax({
                url: '/Products/GetSubcategory1',
                data: { categoryName: selectedCategory },
                type: 'GET',
                success: function (response) {
                    var subcategoryDropdown = $('#SubCategory1');
                    subcategoryDropdown.empty();
                    subcategoryDropdown.append($('<option>').text('Select a subcategory'));

                    $.each(response.subCategory1, function (index, subCategory) {
                        subcategoryDropdown.append($('<option>').text(subCategory.subCategory1).val(subCategory.subCategory1));
                        console.log(subCategory.subCategory1); // Log individual subcategory names
                    });
                },
                error: function () {
                    // Handle error if any
                }
            });
        } else {
            $('#SubCategory1').empty();
        }
    });
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