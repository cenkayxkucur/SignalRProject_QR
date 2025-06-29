﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                ContactLocation = createContactDto.ContactLocation,
                ContactPhone = createContactDto.ContactPhone,
                ContactMail = createContactDto.ContactMail,
                ContactFooterDescription = createContactDto.ContactFooterDescription
            });
            return Ok("Contact created successfully.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _mapper.Map<ResultContactDto>(_contactService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                ContactLocation = updateContactDto.ContactLocation,
                ContactPhone = updateContactDto.ContactPhone,
                ContactMail = updateContactDto.ContactMail,
                ContactFooterDescription = updateContactDto.ContactFooterDescription
            });

            return Ok("Contact updated successfully.");
        }
    }
}
