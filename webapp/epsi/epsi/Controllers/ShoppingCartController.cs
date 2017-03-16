using epsi.Helper;
using epsi.Models;
using epsi.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace epsi.Controllers
{
    public class ShoppingCartController : Controller
    {
        Biz4Db db = new Biz4Db();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if(user == null)
            {
                user = new ApplicationUser();
            }
            return View(user);
        }

        // POST: /ShoppingCart/
        [HttpPost]
        public ActionResult Index(InfoOrder info, List<CartItem> cart)
        {
            
            try
            {

                //check not exist account then save account


                //save to order and orderdetail
                var order = new Order();
                order.FullName = info.FullName;
                order.Email = info.Email;
                order.Address = info.Address;
                order.Phone = info.Phone;
                order.Note = info.Note;
                order.Total = 0;
                order.PaymentType = info.PaymentType;
                order.OrderStatusId = 1;
                order.OrderDate = DateTime.Now;
                order.OrderCode = UtilHelper.GetUniqueKey(8);
                //Save Order
                db.Orders.Add(order);
                db.SaveChanges();

                decimal orderTotal = 0;

                // adding the order details for each
                foreach (var item in cart)
                {
                    var productitem = db.Products.Where(p => p.ProductId == item.id).FirstOrDefault();
                    var productprice = item.price;
                    if (productitem != null)
                    {
                        productprice = productitem.Price;
                    }
                    var orderDetail = new OrderDetail
                    {
                        ProductId = item.id,
                        OrderId = order.OrderId,
                        UnitPrice = productprice,
                        Quantity = item.count
                    };
                    // Set the order total of the shopping cart
                    orderTotal += (item.count * productprice);
                    db.OrderDetails.Add(orderDetail);
                }
                order.Total = orderTotal;
                db.SaveChanges();

                //send mail to customer
                var strBody = "";
                var spayment = "Tiền mặt";
                if (order.PaymentType == 2)
                {
                    spayment = "Chuyển khoản";
                }
                strBody = strBody + "<h2>Cảm ơn quý khách đã đặt hàng. Chúng tôi sẽ sớm xử lý đơn hàng của quý khách.</h2> <br />";
                strBody = strBody + "<h3>Mã số đơn hàng của quý khách : " + order.OrderCode + "</h3>";
                var subject = "Thông tin đơn hàng từ epsi.vn";
                try
                {
                    UtilHelper.SendEmail(order.Email, subject, strBody);
                }
                catch
                {

                }

                return Json(new { id = order.OrderCode });

            }
            catch
            {
                //Invalid - redisplay with errors
                return Json(new { id = "" });
            }
        }
    }
}