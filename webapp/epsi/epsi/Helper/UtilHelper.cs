﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace epsi.Helper
{
    public static class UtilHelper
    {
        public static string GetOrderStatus(int st)
        {
            var ms = "";
            switch (st)
            {
                case 1:
                    ms = "Đặt hàng thành công";
                    break;
                case 2:
                    ms = "Đã tiếp nhận đơn hàng";
                    break;
                case 3:
                    ms = "Đang đóng gói";
                    break;
                case 4:
                    ms = "Đang vận chuyển";
                    break;
                case 5:
                    ms = "Giao hàng thành công";
                    break;
                default:
                    break;
            }
            return ms;
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        public static bool SendEmail(string toEmail, string subject, string strBody)
        {


            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            //message.To.Add("sale@sqshops.com"); //recipient
            message.To.Add("duthu.vn@gmail.com");
            message.To.Add(toEmail);
            message.Subject = subject;
            message.From = new System.Net.Mail.MailAddress("duthu.vn@gmail.com"); //from email
            message.Body = strBody;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");// you need an smtp server address to send emails
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("duthu.vn@gmail.com", "0984358352");

            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(message);

            return true;


        }

    }

}
