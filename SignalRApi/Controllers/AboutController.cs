using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About
            {
                AboutTitle = createAboutDto.AboutTitle,
                AboutDescription = createAboutDto.AboutDescription,
                AboutImageUrl = createAboutDto.AboutImageUrl
            };
            _aboutService.TAdd(about);
            return Ok("About created successfully.");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("About deleted successfully.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About
            {
                AboutID = updateAboutDto.AboutID,
                AboutTitle = updateAboutDto.AboutTitle,
                AboutDescription = updateAboutDto.AboutDescription,
                AboutImageUrl = updateAboutDto.AboutImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("About updated successfully.");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
