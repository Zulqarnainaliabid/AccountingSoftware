using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccountingApp.Api.Resources;
using AccountingApp.Api.Validations;
using AccountingApp.Core.Models;
using AccountingApp.Core.Services;

namespace AccountingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanTakerController : BaseController
    {
        private readonly ILoanTakerService _loanTakerService;
        private readonly IMapper _mapper;

        public LoanTakerController(ILoanTakerService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._loanTakerService = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<LoanTakerResource>>> GetAllLoanTaker()
        {
            var loanTakers = await _loanTakerService.GetAllAsync(UserIdGuid);
            var artistResources = _mapper.Map<IEnumerable<LoanTaker>, IEnumerable<LoanTakerResource>>(loanTakers);

            return Ok(artistResources);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Test")]
        public async Task<ActionResult<LoanTakerResource>> GetById(int id)
        {
            var loanTaker = await _loanTakerService.GetByIdAsync(id);
            var artistResource = _mapper.Map<LoanTaker, LoanTakerResource>(loanTaker);

            return Ok(artistResource);
        }

        [HttpPost("")]
        [Authorize("OnlyTest")]
        public async Task<ActionResult<LoanTakerResource>> Create([FromBody] SaveLoanTakerResource saveLoanTakerResource)
        {
            var validator = new SaveLoanTakerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveLoanTakerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var loanTakerToCreate = _mapper.Map<SaveLoanTakerResource, LoanTaker>(saveLoanTakerResource);

            var newLoanTaker = await _loanTakerService.Create(loanTakerToCreate);

            var loanTaker = await _loanTakerService.GetByIdAsync(newLoanTaker.Id);

            var artistResource = _mapper.Map<LoanTaker, LoanTakerResource>(loanTaker);

            return Ok(artistResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SaveLoanTakerResource>> Update(int id, [FromBody] SaveLoanTakerResource saveLoanTakerResource)
        {
            var validator = new SaveLoanTakerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveLoanTakerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var artistToBeUpdated = await _loanTakerService.GetByIdAsync(id);

            if (artistToBeUpdated == null)
                return NotFound();

            var artist = _mapper.Map<SaveLoanTakerResource, LoanTaker>(saveLoanTakerResource);

            await _loanTakerService.Update(artistToBeUpdated, artist);

            var updatedLoanTaker = await _loanTakerService.GetByIdAsync(id);

            var updatedLoanTakerResource = _mapper.Map<LoanTaker, LoanTakerResource>(updatedLoanTaker);

            return Ok(updatedLoanTakerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loanTaker = await _loanTakerService.GetByIdAsync(id);

            await _loanTakerService.Delete(loanTaker);

            return NoContent();
        }
    }
}