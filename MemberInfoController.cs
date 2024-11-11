using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberInformationController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public MemberInformationController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllMemberInformation")]
        public async Task<IActionResult> GetAllMemberInformation()
        {
            try
            {
                var allMemberInfo = await _dbContext.MemberInformations.ToListAsync();
                return Ok(allMemberInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetMemberInformation/{Uid}")]
        public async Task<IActionResult> GetMemberInformation(int Uid)
        {
            try
            {
                var memberInfo = await _dbContext.MemberInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (memberInfo == null)
                    return NotFound("Member information not found.");

                return Ok(memberInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("InsertMemberInformation")]
        public async Task<IActionResult> InsertMemberInformation(MemberInformation memberInformation)
        {
            try
            {
                _dbContext.MemberInformations.Add(memberInformation);
                await _dbContext.SaveChangesAsync();
                return Ok("Member information inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateMemberInformation/{Uid}")]
        public async Task<IActionResult> UpdateMemberInformation(int Uid, MemberInformation memberInformation)
        {
            try
            {
                var existingMemberInfo = await _dbContext.MemberInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingMemberInfo == null)
                    return NotFound("Member information not found.");

                existingMemberInfo.FirstName = memberInformation.FirstName;
                existingMemberInfo.LastName = memberInformation.LastName;
                existingMemberInfo.Age = memberInformation.Age;

                _dbContext.MemberInformations.Update(existingMemberInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Member information updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteMemberInformation/{Uid}")]
        public async Task<IActionResult> DeleteMemberInformation(int Uid)
        {
            try
            {
                var existingMemberInfo = await _dbContext.MemberInformations.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingMemberInfo == null)
                    return NotFound("Member information not found.");

                _dbContext.MemberInformations.Remove(existingMemberInfo);
                await _dbContext.SaveChangesAsync();

                return Ok("Member information deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
