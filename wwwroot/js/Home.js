function navigateToProduct(id) {
    var productUrl = `/Product/GetProduct/${id}`;
    window.location.href = productUrl;
}



//function navigateToCart(id) {
//    var CarttUrl = `/Cart/${id}`;
//    window.location.href = CarttUrl;
//}


window.onload = function () {



    //var cartItemsString = getCookie('Cart');
    //var cartItems = cartItemsString ? JSON.parse(cartItemsString) : [];
    //document.getElementById("CartIcon").innerHTML = `${cartItems.length}`;
}






















//////////[ Loading Image ]////////////

var imgElement = document.getElementById("prodIMG");

imgElement.addEventListener("load", function () {
    console.log("Image loaded successfully.");
    // Perform actions when the image is loaded
});

imgElement.addEventListener("error", function () {
    console.log("Error loading the image.");
    var loadingDIV = document.getElementById("loading");
    loadingDIV.innerHTML = '<div class="spinner-border text-warning" role="status"><span class="visually-hidden">Loading...</span></div>';
    // Perform actions when there's an error loading the image
});









