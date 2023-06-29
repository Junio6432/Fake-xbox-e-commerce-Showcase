$(document).ready(function () {
    $("#txtProductName").on("keydown", function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            search();
        }
    });
});

search = function () {
    var searchQuery = $.trim($("#txtProductName").val());
    $.ajax({
        type: "GET",
        url: "/api/Search/" + encodeURIComponent(searchQuery),
        data: "\"" + searchQuery + "\"",
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (result) {
            $('content').html(result);         
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
}


var completedRequests = 0;
$(document).on('click', '#AddToCartLink', function () {    
    var productId = $(this).closest('a').data('product-id');

    //var cartQuantity = $('#cartQuantity');
    //var svgCart = $('#svgCart');
    //var loadingSpinner = $('#loadingSpinner');

    //var myElement = document.getElementById('#loadingSpinner');
    //myElement.classList.remove('.dontShow');
    //cartQuantity.fadeOut(250);
    //svgCart.fadeOut(250);
    //loadingSpinner.fadeIn(250);

    /*$('#loadingSpinner').show();*/
    //$('#cartQuantity').hide();
    //$('#svgCart').hide();



    var requests = [];

    var request = $.ajax({
        url: '/ShoppingCart/AddToShoppingCart',
        dataType: 'JSON',
        data: { productId: productId },
        type: 'GET',
        contentType: 'application/json',
        success: function () {
            $.get('/ShoppingCart/GetItemsQuantity', function (data) {
            $('#ShoppingCartComponent').html(data);
            });
        },
        error: function (xhr) {
            console.log(xhr);
            requests.push(request);
        },
        complete: function () {
            completedRequests++;
            requests.push(request);
            if (completedRequests === requests.length) {
                
                
                //cartQuantity.fadeIn(250);
                //svgCart.fadeIn(250);
                //loadingSpinner.fadeOut(250);
                //$('#loadingSpinner').hide();
                //$('#cartQuantity').show();
                //$('#svgCart').show();

                //var totalProducts = $('#cartQuantity').data('total-products');
                //$('#cartQuantity').text(totalProducts);

                //setTimeout(function () {
                //    var totalProducts = $('#cartQuantity').data('total-products');
                //    console.log(totalProducts);
                //    $('#cartQuantity').text(totalProducts);
                //    $('#cartQuantity').show();
                //}, 100);
            }
        }
    });

    
        //success: function () {
        //    $.get('/ShoppingCart/GetItemsQuantity', function (data) {
        //        $('#ShoppingCartComponent').html(data);
        //    });
        //    $('#loadingSpinner').hide();
        //    $('#cartQuantityContainer').show();
        //    $('#svgCart').show();
        //},
        //error: function (xhr) {
        //    $('#loadingSpinner').hide();
        //    $('#cartQuantityContainer').show();
        //    $('#svgCart').show();
        //    console.log(xhr)
        //}
});


$(document).on('click', '#DeleteGame', function () {
    var productId = $(this).closest('a').data('product-id');

        $.ajax({
        url: '/Products/DeleteProduct',
        dataType: 'JSON',
        data: { productId: productId },
        type: 'GET',
        contentType: 'application/json',
        success: function () {
            $.get('/Home/IndexPartial', function (data) {
                $('#Index').html(data);
            });
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });

});







