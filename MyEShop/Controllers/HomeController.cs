using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyEShop.Data;
using MyEShop.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MyEShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEshopContext _context;

        public HomeController(ILogger<HomeController> logger,MyEshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           var list= _context.products.ToList();

            return View(list);
        }
        public IActionResult Detail(int id)
        {
            var res=_context.products.Include(c=>c.Item).SingleOrDefault(c=>c.ProductId==id);
            if (res==null)
            {
                return NotFound();
            }
           
            var categories=_context.products.Where(c=> c.ProductId==id)
                .SelectMany(c=>c.CategoryToProducts)
                .Select(c=>c.Category).ToList();
            var detailViewModel = new DetailsViewModel()
            {
                 product=res,
                  categories=categories

            };
                
            return View(detailViewModel);
        }
        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.products.Include(c => c.Item).SingleOrDefault(c=>c.ItemId==itemId);
            if (product !=null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var orders=_context.orders.FirstOrDefault(c=>c.UserId==userId && !c.IsFinally);
                if (orders!=null)
                {
                    var orderDetail=_context.ordersDetail.FirstOrDefault(o=>o.OrderId==orders.OrderId&&o.ProductId==product.ProductId);
                    if (orderDetail !=null)
                    {
                        orderDetail.Count += 1;

                    }
                    else
                    {
                        _context.ordersDetail.Add(new OrderDetail()
                        {
                            OrderId = orders.OrderId,
                            ProductId = product.ProductId,
                            Price = product.Item.Price,
                            Count = 1

                        });
                    }

                }
                else
                {
                     orders = new Order()
                    {
                         IsFinally = false,
                          UserId = userId,
                           CreateDate = DateTime.Now,   
                    };
                    _context.orders.Add(orders);
                    _context.SaveChanges();
                    _context.ordersDetail.Add(new OrderDetail() 
                    {
                         OrderId=orders.OrderId,
                        ProductId=product.ProductId,
                        Price=product.Item.Price,
                        Count=1
                         
                    });
                }
                _context.SaveChanges();

            }
            return RedirectToAction("ShowCart");

           
        }
        [Authorize]
        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.orders.Where(o => o.UserId == userId && !o.IsFinally)
                .Include(o => o.orderDetails)
                .ThenInclude(o => o.Product).FirstOrDefault();


            return View(order);
        }
        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail=_context.ordersDetail.Find(detailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
