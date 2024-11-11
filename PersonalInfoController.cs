using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public PersonalInfoController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpGet("GetAllPersonalInfo")]
        public async Task<IActionResult> GetAllPersonalInfo()
        {
            try
            {
                var allPersonalInfo = await _dbContext.PersonalInfos.ToListAsync();
                return Ok(allPersonalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpGet("GetPersonalInfo/{Uid}")]
        public async Task<IActionResult> GetPersonalInfo(int Uid)
        {
            try
            {
                var personalInfo = await _dbContext.PersonalInfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (personalInfo == null)
                    return NotFound("Personal information not found.");

                return Ok(personalInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpPost("InsertPersonalInfo")]
        public async Task<IActionResult> InsertPersonalInfo(PersonalInfo personalInfo)
        {
            try
            {
                _dbContext.PersonalInfos.Add(personalInfo);
                await _dbContext.SaveChangesAsync();
                return Ok("Personal information inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpPut("UpdatePersonalInfo/{Uid}")]
        public async Task<IActionResult> UpdatePersonalInfo(int Uid, [FromBody] PersonalInfo personalInfo)
        {
            try
            {
                var existingPersonalInfo = await _dbContext.PersonalInfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingPersonalInfo == null)
                    return NotFound("Personal information not found.");

                existingPersonalInfo.FirstName = personalInfo.FirstName;
                existingPersonalInfo.LastName = personalInfo.LastName;
                existingPersonalInfo.DateOfBirth = personalInfo.DateOfBirth;
                existingPersonalInfo.Gender = personalInfo.Gender;
                existingPersonalInfo.Nationality = personalInfo.Nationality;
                existingPersonalInfo.MaritalStatus = personalInfo.MaritalStatus;
                existingPersonalInfo.Ssn = personalInfo.Ssn;
                existingPersonalInfo.PassportNumber = personalInfo.PassportNumber;
                existingPersonalInfo.Religion = personalInfo.Religion;
                existingPersonalInfo.Hobbies = personalInfo.Hobbies;

                _dbContext.PersonalInfos.Update(existingPersonalInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Personal information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeletePersonalInfo/{Uid}")]
        public async Task<IActionResult> DeletePersonalInfo(int Uid)
        {
            try
            {
                var existingPersonalInfo = await _dbContext.PersonalInfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingPersonalInfo == null)
                    return NotFound("Personal information not found.");

                _dbContext.PersonalInfos.Remove(existingPersonalInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Personal information deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

