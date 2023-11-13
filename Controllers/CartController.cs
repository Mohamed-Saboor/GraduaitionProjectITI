using GraduaitionProjectITI.Models.Entity;
using GraduaitionProjectITI.Reprository.BrandRepository;
using GraduaitionProjectITI.Reprository.CategoryReprositry;
using GraduaitionProjectITI.Reprository.ProductReprository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GraduaitionProjectITI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductReprository reprositry;
        private readonly ICategoryReprositry reprositrycaty;
        private readonly IBrandRepository reprositryBrand;
        public CartController(IProductReprository reprositry, ICategoryReprositry reprositrycaty, IBrandRepository reprositryBrand)
        {
            this.reprositry = reprositry;
            this.reprositrycaty = reprositrycaty;
            this.reprositryBrand = reprositryBrand;
        }

        public IActionResult Index()
        {


            return View();
        }
        public IActionResult Hamada()
        {
            List<int> cart;

            // Check if the cart already exists in cookies
            if (Request.Cookies.TryGetValue("Cart", out var cartCookie))
            {
                cart = JsonConvert.DeserializeObject<List<int>>(cartCookie);
            }
            else
            {
                cart = new List<int>();
            }
            return Json(cart.Count);
        }
        public IActionResult AddToCart(int productId)
        {
            List<int> cart;

            // Check if the cart already exists in cookies
            if (Request.Cookies.TryGetValue("Cart", out var cartCookie))
            {
                cart = JsonConvert.DeserializeObject<List<int>>(cartCookie);
            }
            else
            {
                cart = new List<int>();
            }

            // Add the product ID to the cart
            cart.Add(productId);

            // Save the cart back to cookies
            var serializedCart = JsonConvert.SerializeObject(cart);
            Response.Cookies.Append("Cart", serializedCart, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1) // Set the expiration time for the cookie
            });

            return Json(cart.Count); // Redirect to the desired page after adding to the cart
        }
        public IActionResult ViewCart()
        {
            List<int> cart;

            // Check if the cart already exists in cookies
            if (Request.Cookies.TryGetValue("Cart", out var cartCookie))
            {
                cart = JsonConvert.DeserializeObject<List<int>>(cartCookie);
            }
            else
            {
                cart = new List<int>();
            }

            // Retrieve product details based on the product IDs in the cart
            //var cartProducts = _yourProductRepository.GetProductsByIds(cart);

            return View(cart);
        }
    }
}

