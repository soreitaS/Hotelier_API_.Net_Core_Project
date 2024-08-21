using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        
            private readonly IHttpClientFactory _httpClientFactory;

            public _TestimonialPartial(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                var client = _httpClientFactory.CreateClient();
                var responceMessage = await client.GetAsync("http://localhost:32037/api/Testimonial");
                if (responceMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responceMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
        
    }
}
