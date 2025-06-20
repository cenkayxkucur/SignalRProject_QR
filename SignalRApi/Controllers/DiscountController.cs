using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                DiscountTitle = createDiscountDto.DiscountTitle,
                DiscountDescription = createDiscountDto.DiscountDescription,
                DiscountAmount = createDiscountDto.DiscountAmount,
                DiscountImageUrl = createDiscountDto.DiscountImageUrl
            });
            return Ok("Discount created successfully.");

        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok(value);
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _mapper.Map<ResultDiscountDto>(_discountService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                DiscountTitle = updateDiscountDto.DiscountTitle,
                DiscountDescription = updateDiscountDto.DiscountDescription,
                DiscountAmount = updateDiscountDto.DiscountAmount,
                DiscountImageUrl = updateDiscountDto.DiscountImageUrl

            });

            return Ok("Discount updated successfully.");
        }
    }
}
