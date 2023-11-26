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