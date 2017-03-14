using epsi.Helper;
using epsi.Models;
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
        Biz4Db db = new Biz4Db();
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
                //strBody = strBody + "<h2>Thông tin người mua:</h2>Họ và Tên:  " + order.FullName + " <br />Số điện thoại: " + order.Phone + " <br />Email: " + order.Email + " <br />Địa chỉ: " + order.Address + " <br />Thanh toán: " + order.PaymentType + " (Chuyển khoản | Tiền mặt) <br />Ghi chú: " + order.Note + " <br /> <br />";
                //strBody = strBody + "<h3>Đơn hàng số: " + order.OrderId.ToString() + "</h3>";
                //SendEmail(order.Email, strBody);
              
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