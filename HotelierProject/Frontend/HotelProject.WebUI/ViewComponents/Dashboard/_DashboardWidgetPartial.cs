using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("http://localhost:32037/api/DashboardWidgets/StaffCount");
            var jsonData = await responceMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var responceMessage2 = await client2.GetAsync("http://localhost:32037/api/DashboardWidgets/BookingCount");
            var jsonData2 = await responceMessage2.Content.ReadAsStringAsync();
            ViewBag.bookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responceMessage3 = await client3.GetAsync("http://localhost:32037/api/DashboardWidgets/AppUserCount");
            var jsonData3 = await responceMessage3.Content.ReadAsStringAsync();
            ViewBag.appUserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var responceMessage4 = await client4.GetAsync("http://localhost:32037/api/DashboardWidgets/RoomCount");
            var jsonData4 = await responceMessage4.Content.ReadAsStringAsync();
            ViewBag.roomCount = jsonData4;
            return View();
        }
    }
}
