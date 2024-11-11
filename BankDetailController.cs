using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project3WithDBFirstAndLinq.Models;

namespace project3WithDBFirstAndLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailController : ControllerBase
    {
        private readonly Projectsql3Context _dbContext;

        public BankDetailController(Projectsql3Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllBankDetail")]
        public async Task<IActionResult> GetAllBankDetail()
        {
            try
            {
                var allBank = await _dbContext.Bankdetails.ToListAsync();
                return Ok(allBank);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("InsertBankDetail")]
        public async Task<IActionResult> InsertBankDetail(Bankdetail bankDetailCommandModel)
        {
            try
            {
                var newBankDetail = new Bankdetail
                {
                    Uid = 3,
                    
                    BankName = bankDetailCommandModel.BankName,
                    AccountNumber = bankDetailCommandModel.AccountNumber,
                    BankBranch = bankDetailCommandModel.AccountNumber,
                    Ifsccode = bankDetailCommandModel.Ifsccode,
                    AccountType = bankDetailCommandModel.AccountType,
                    AccountHolderName = bankDetailCommandModel.AccountHolderName,
                    SwiftCode = bankDetailCommandModel.SwiftCode,
                    BankCountry = bankDetailCommandModel.BankCountry,
                    Currency = bankDetailCommandModel.Currency
                };
                _dbContext.Bankdetails.Add(newBankDetail);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateBankDetail{Uid}")]
        public async Task<IActionResult> UpdateBankDetail(int Uid, Bankdetail bankDetailCommandModel)
        {
            try
            {
                var existingBankDetail = await _dbContext.Bankdetails.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingBankDetail is null)
                    return StatusCode(500, "Bank Detail not found.");

                existingBankDetail.BankName = bankDetailCommandModel.BankName;
                existingBankDetail.AccountNumber = bankDetailCommandModel.AccountNumber;
                existingBankDetail.BankBranch = bankDetailCommandModel.AccountNumber;
                existingBankDetail.Ifsccode = bankDetailCommandModel.Ifsccode;
                existingBankDetail.AccountType = bankDetailCommandModel.AccountType;
                existingBankDetail.AccountHolderName = bankDetailCommandModel.AccountHolderName;
                existingBankDetail.SwiftCode = bankDetailCommandModel.SwiftCode;
                existingBankDetail.BankCountry = bankDetailCommandModel.BankCountry;
                existingBankDetail.Currency = bankDetailCommandModel.Currency;

                _dbContext.Bankdetails.Update(existingBankDetail);
                await _dbContext.SaveChangesAsync();

                return Ok("Changes sucsessfully done.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteBankDetail{Uid}")]
        public async Task<IActionResult> DeleteBankDetail(int Uid)
        {
            try
            {
                var existingBankDetail = await _dbContext.Bankdetails.FirstOrDefaultAsync(x => x.Uid == Uid);
                if (existingBankDetail is null)
                    return StatusCode(500, "Bank Detail not found.");

                _dbContext.Bankdetails.Remove(existingBankDetail);
                await _dbContext.SaveChangesAsync();

                return Ok("Delete sucsessfully done.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
