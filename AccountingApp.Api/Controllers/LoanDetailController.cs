using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AccountingApp.Api.Resources;
using AccountingApp.Api.Validations;
using AccountingApp.Core.Models;
using AccountingApp.Core.Services;

namespace AccountingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailController : BaseController
    {
        private readonly ILoanDetailService _loanDetailService;
        private readonly IMapper _mapper;

        public LoanDetailController(ILoanDetailService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._loanDetailService = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<LoanDetailResource>>> GetAllLoanDetails()
        {
            var LoanDetails = await _loanDetailService.GetAllLoanDetails(UserIdGuid);
            var LoanDetailResources = _mapper.Map<IEnumerable<LoanDetail>, IEnumerable<LoanDetailResource>>(LoanDetails);

            return Ok(LoanDetailResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDetailResource>> GetLoanDetailById(int id)
        {
            var LoanDetail = await _loanDetailService.GetByIdAsync(id);
            var LoanDetailResource = _mapper.Map<LoanDetail, LoanDetailResource>(LoanDetail);

            return Ok(LoanDetailResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<LoanDetailResource>> CreateLoanDetail([FromBody] SaveLoanDetailResource saveLoanDetailResource)
        {
            var validator = new SaveLoanDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveLoanDetailResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var LoanDetailToCreate = _mapper.Map<SaveLoanDetailResource, LoanDetail>(saveLoanDetailResource);

            var newLoanDetail = await _loanDetailService.Create(LoanDetailToCreate);

            var LoanDetail = await _loanDetailService.GetByIdAsync(newLoanDetail.Id);

            var LoanDetailResource = _mapper.Map<LoanDetail, LoanDetailResource>(LoanDetail);

            return Ok(LoanDetailResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LoanDetailResource>> UpdateLoanDetail(int id, [FromBody] SaveLoanDetailResource saveLoanDetailResource)
        {
            var validator = new SaveLoanDetailResourceValidator();
            var validationResult = await validator.ValidateAsync(saveLoanDetailResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var LoanDetailToBeUpdate = await _loanDetailService.GetByIdAsync(id);

            if (LoanDetailToBeUpdate == null)
                return NotFound();

            var LoanDetail = _mapper.Map<SaveLoanDetailResource, LoanDetail>(saveLoanDetailResource);

            await _loanDetailService.Update(LoanDetailToBeUpdate, LoanDetail);

            var updatedLoanDetail = await _loanDetailService.GetByIdAsync(id);
            var updatedLoanDetailResource = _mapper.Map<LoanDetail, LoanDetailResource>(updatedLoanDetail);

            return Ok(updatedLoanDetailResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanDetail(int id)
        {
            if (id == 0)
                return BadRequest();

            var LoanDetail = await _loanDetailService.GetByIdAsync(id);

            if (LoanDetail == null)
                return NotFound();

            await _loanDetailService.Delete(LoanDetail);

            return NoContent();
        }
    }
}