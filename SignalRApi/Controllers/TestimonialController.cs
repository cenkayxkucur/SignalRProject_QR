using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialName = createTestimonialDto.TestimonialName,
                TestimonialTitle = createTestimonialDto.TestimonialTitle,
                TestimonialComment = createTestimonialDto.TestimonialComment,
                TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
                TestimonialStatus = createTestimonialDto.TestimonialStatus

            });
            return Ok("Testimonial created successfully.");

        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok(value);
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _mapper.Map<ResultTestimonialDto>(_testimonialService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                TestimonialName = updateTestimonialDto.TestimonialName,
                TestimonialTitle = updateTestimonialDto.TestimonialTitle,
                TestimonialComment = updateTestimonialDto.TestimonialComment,
                TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus

            });

            return Ok("Testimonial updated successfully.");
        }
    }
}
