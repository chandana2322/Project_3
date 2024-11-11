using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationInfoController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public EducationInfoController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllEducationInfo")]
        public async Task<IActionResult> GetAllEducationInfo()
        {
            try
            {
                var allEducationInfo = await _dbContext.Educationinfos.ToListAsync();
                return Ok(allEducationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEducationInfo/{Uid}")]
        public async Task<IActionResult> GetEducationInfo(int Uid)
        {
            try
            {
                var educationInfo = await _dbContext.Educationinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (educationInfo == null)
                    return NotFound("Education information not found.");

                return Ok(educationInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("InsertEducationInfo")]
        public async Task<IActionResult> InsertEducationInfo(Educationinfo educationInfo)
        {
            try
            {
                _dbContext.Educationinfos.Add(educationInfo);
                await _dbContext.SaveChangesAsync();
                return Ok("Education information inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateEducationInfo/{Uid}")]
        public async Task<IActionResult> UpdateEducationInfo(int Uid, Educationinfo educationInfo)
        {
            try
            {
                var existingEducationInfo = await _dbContext.Educationinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingEducationInfo == null)
                    return NotFound("Education information not found.");

                existingEducationInfo.HighSchoolName = educationInfo.HighSchoolName;
                existingEducationInfo.HighSchoolGraduationYear = educationInfo.HighSchoolGraduationYear;
                existingEducationInfo.UniversityName = educationInfo.UniversityName;
                existingEducationInfo.Degree = educationInfo.Degree;
                existingEducationInfo.Major = educationInfo.Major;
                existingEducationInfo.GraduationYear = educationInfo.GraduationYear;
                existingEducationInfo.Gpa = educationInfo.Gpa;
                existingEducationInfo.Certifications = educationInfo.Certifications;
                existingEducationInfo.Scholarships = educationInfo.Scholarships;

                _dbContext.Educationinfos.Update(existingEducationInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Education information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEducationInfo/{Uid}")]
        public async Task<IActionResult> DeleteEducationInfo(int Uid)
        {
            try
            {
                var existingEducationInfo = await _dbContext.Educationinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingEducationInfo == null)
                    return NotFound("Education information not found.");

                _dbContext.Educationinfos.Remove(existingEducationInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Education information deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

