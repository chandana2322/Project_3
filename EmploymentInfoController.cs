using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentInfoController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public EmploymentInfoController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllEmploymentInfo")]
        public async Task<IActionResult> GetAllEmploymentInfo()
        {
            try
            {
                var allEmploymentInfo = await _dbContext.Employmentinfos.ToListAsync();
                return Ok(allEmploymentInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEmploymentInfo/{Uid}")]
        public async Task<IActionResult> GetEmploymentInfo(int Uid)
        {
            try
            {
                var employmentInfo = await _dbContext.Employmentinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (employmentInfo == null)
                    return NotFound("Employment information not found.");

                return Ok(employmentInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("InsertEmploymentInfo")]
        public async Task<IActionResult> InsertEmploymentInfo(Employmentinfo employmentInfo)
        {
            try
            {
                _dbContext.Employmentinfos.Add(employmentInfo);
                await _dbContext.SaveChangesAsync();
                return Ok("Employment information inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateEmploymentInfo/{Uid}")]
        public async Task<IActionResult> UpdateEmploymentInfo(int Uid, Employmentinfo employmentInfo)
        {
            try
            {
                var existingEmploymentInfo = await _dbContext.Employmentinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingEmploymentInfo == null)
                    return NotFound("Employment information not found.");

                existingEmploymentInfo.EmployerName = employmentInfo.EmployerName;
                existingEmploymentInfo.JobTitle = employmentInfo.JobTitle;
                existingEmploymentInfo.StartDate = employmentInfo.StartDate;
                existingEmploymentInfo.EndDate = employmentInfo.EndDate;
                existingEmploymentInfo.JobDescription = employmentInfo.JobDescription;
                existingEmploymentInfo.Salary = employmentInfo.Salary;
                existingEmploymentInfo.SupervisorName = employmentInfo.SupervisorName;
                existingEmploymentInfo.SupervisorPhone = employmentInfo.SupervisorPhone;

                _dbContext.Employmentinfos.Update(existingEmploymentInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Employment information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEmploymentInfo/{Uid}")]
        public async Task<IActionResult> DeleteEmploymentInfo(int Uid, CancellationToken cancellationToken)
        {
            try
            {
                var existingEmploymentInfo = await _dbContext.Employmentinfos.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingEmploymentInfo == null)
                    return NotFound("Employment information not found.");

                _dbContext.Employmentinfos.Remove(existingEmploymentInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Employment information deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

