using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public ContactInformationController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var allContacts = await _dbContext.ContactInformations.ToListAsync();
                return Ok(allContacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetContact/{Uid}")]
        public async Task<IActionResult> GetContact(int Uid)
        {
            try
            {
                var contact = await _dbContext.ContactInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (contact is null)
                    return NotFound("Contact information not found.");

                return Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("InsertContact")]
        public async Task<IActionResult> InsertContact(ContactInformation contactInformation)
        {
            try
            {
                _dbContext.ContactInformations.Add(contactInformation);
                await _dbContext.SaveChangesAsync();
                return Ok("Contact information inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateContact/{Uid}")]
        public async Task<IActionResult> UpdateContact(int Uid, ContactInformation contactInformation)
        {
            try
            {
                var existingContact = await _dbContext.ContactInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingContact is null)
                    return NotFound("Contact information not found.");

                existingContact.Email = contactInformation.Email;
                existingContact.PhoneNumber = contactInformation.PhoneNumber;
                existingContact.AlternatePhoneNumber = contactInformation.AlternatePhoneNumber;
                existingContact.EmergencyContactName = contactInformation.EmergencyContactName;
                existingContact.EmergencyContactRelation = contactInformation.EmergencyContactRelation;
                existingContact.EmergencyContactPhone = contactInformation.EmergencyContactPhone;
                existingContact.LinkedInProfile = contactInformation.LinkedInProfile;
                existingContact.FacebookProfile = contactInformation.FacebookProfile;
                existingContact.TwitterHandle = contactInformation.TwitterHandle;

                _dbContext.ContactInformations.Update(existingContact);
                await _dbContext.SaveChangesAsync();

                return Ok("Contact information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteContact/{Uid}")]
        public async Task<IActionResult> DeleteContact(int Uid)
        {
            try
            {
                var existingContact = await _dbContext.ContactInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingContact is null)
                    return NotFound("Contact information not found.");

                _dbContext.ContactInformations.Remove(existingContact);
                await _dbContext.SaveChangesAsync();

                return Ok("Contact information deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
