﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                SocialMediaTitle = createSocialMediaDto.SocialMediaTitle,
                SocialMediaIconUrl = createSocialMediaDto.SocialMediaIconUrl,
                SocialMediaUrl = createSocialMediaDto.SocialMediaUrl
                
            });
            return Ok("SocialMedia created successfully.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _mapper.Map<ResultSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                SocialMediaTitle = updateSocialMediaDto.SocialMediaTitle,
                SocialMediaIconUrl = updateSocialMediaDto.SocialMediaIconUrl,
                SocialMediaUrl = updateSocialMediaDto.SocialMediaUrl
            });

            return Ok("SocialMedia updated successfully.");
        }
    }
}
