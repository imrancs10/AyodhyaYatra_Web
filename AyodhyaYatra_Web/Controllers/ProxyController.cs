using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AyodhyaYatra_Web.Controllers
{
    public class ProxyController : Controller
    {
        public async Task<ActionResult> GetImage(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var contentType = response.Content.Headers.ContentType.ToString();
                var content = await response.Content.ReadAsByteArrayAsync();
                return File(content, contentType);
            }
        }
    }
}