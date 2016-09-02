using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace Hash.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetHash(string textToHash, string encoding)
        {
            Encoding hashEncoding;

            switch (encoding)
            {
                case "UTF8":
                    hashEncoding = Encoding.UTF8;
                    break;
                case "Unicode":
                    hashEncoding = Encoding.Unicode;
                    break;
                default:
                    hashEncoding = Encoding.UTF8;
                    break;
            }

            var hash = ComputeHash(textToHash, hashEncoding);

            return Content(hash);
        }

        /// <summary>
        /// Computes a hash given the value to hash and the encoding.
        /// </summary>
        /// <param name="value">The value to hash.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        private string ComputeHash(string value, Encoding encoding)
        {
            SHA256 crypt = SHA256.Create();

            string hash = String.Empty;
            byte[] hashBytes = crypt.ComputeHash(encoding.GetBytes(value));

            foreach (byte theByte in hashBytes)
            {
                hash += theByte.ToString("X2");
            }
            return hash;
        }
    }
}
