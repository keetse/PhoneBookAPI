using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Data;
using PhoneBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase

    
    {
        private readonly IContactRepository _repository;
        public readonly IMapper _mapper;

        public ContactDetailsController(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<ContactDetailsController>
        [HttpGet]
        public async Task<ActionResult<ContactDetails[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllContactsAsync();

                return _mapper.Map<ContactDetails[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // GET api/<ContactDetailsController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<ContactDetails>> Get(string name)
        {
            try
            {
                var result = await _repository.GetContactByNameAsync(name);
                if (result == null) return NotFound();
                return _mapper.Map<ContactDetails>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");

            }
        }

        // POST api/<ContactDetailsController>
        [HttpPost]
        public async Task<ActionResult<ContactDetails>> Post( ContactDetails contactDetail)
        {
            try
            {
                _repository.Add(contactDetail);
                if (await _repository.SaveChangesAsync()) {
                    return CreatedAtAction(nameof(Get), new { id = contactDetail.ContactID }, contactDetail);
                }
                else
                {
                    return BadRequest("Failed to save Contact Details");
                }
               
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            
            
        }

        
    }
}
