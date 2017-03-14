using epsi.ViewModels;
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
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }

        // POST: /ShoppingCart/
        [HttpPost]
        public ActionResult Index(InfoOrder info, List<CartItem> cart)
        {
            
            try
            {

                //check not exist account then save account
                //save to order and orderdetail

                //send mail to customer
                //strBody = strBody + "<h2>Thông tin người mua:</h2>Họ và Tên:  " + order.FullName + " <br />Số điện thoại: " + order.Phone + " <br />Email: " + order.Email + " <br />Địa chỉ: " + order.Address + " <br />Thanh toán: " + order.PaymentType + " (Chuyển khoản | Tiền mặt) <br />Ghi chú: " + order.Note + " <br /> <br />";
                //strBody = strBody + "<h3>Đơn hàng số: " + order.OrderId.ToString() + "</h3>";
                //SendEmail(order.Email, strBody);
                //return RedirectToAction("Complete",
                //    new { id = order.OrderId });
                return Json(new { id = 1 });

            }
            catch
            {
                //Invalid - redisplay with errors
                return Json(new { id = "" });
            }
        }
    }
}