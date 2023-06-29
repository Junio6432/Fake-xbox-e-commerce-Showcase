$(document).on('click', '#RemoveProduct', function () {
    var productId = $(this).closest('a').data('product-id');
    
    $.ajax({
        url: '/ShoppingCart/RemoveShoppingCart',
        dataType: 'JSON',
        data: { productId: productId },
        type: 'GET',
        contentType: 'application/json',
        success: function () {
            $.get('/ShoppingCart/ShoppingCartPartial', function (data) {
                $('#ShoppingCartPage').html(data);
            });
            $.get('/ShoppingCart/GetItemsQuantity', function (data) {
                $('#ShoppingCartComponent').html(data);
            });
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
});

$(document).on('click', '#AddAnotherProduct', function () {
    var productId = $(this).closest('a').data('product-id');

    $.ajax({
        url: '/ShoppingCart/AddToShoppingCart',
        dataType: 'JSON',
        data: { productId: productId },
        type: 'GET',
        contentType: 'application/json',
        success: function () {
            $.get('/ShoppingCart/ShoppingCartPartial', function (data) {
                $('#ShoppingCartPage').html(data);
            });
            $.get('/ShoppingCart/GetItemsQuantity', function (data) {
                $('#ShoppingCartComponent').html(data);
            });
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
});

$(document).on('click', '#CleanAll', function () {
    $.ajax({
        url: '/ShoppingCart/ClearShoppingCart',
        dataType: 'JSON',
        type: 'GET',
        contentType: 'application/json',
        success: function () {
            $.get('/ShoppingCart/ShoppingCartPartial', function (data) {
                $('#ShoppingCartPage').html(data);
            });
            $.get('/ShoppingCart/GetItemsQuantity', function (data) {
                $('#ShoppingCartComponent').html(data);
            });
        },
        error: function (xhr) {
            console.log(xhr)
        }
    });
});