using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _boolingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService boolingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _boolingService = boolingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _boolingService.TGetBookingCount(); 
            return Ok(value);
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }
    }
}
