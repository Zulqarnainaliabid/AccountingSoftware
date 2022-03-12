using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perfactcv.Api.Resources;
using Perfactcv.Api.Validations;
using Perfactcv.Core.Models;
using Perfactcv.Core.Services;

namespace Perfactcv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CVBackupController : BaseController
    {
        private readonly ICVBackupService _CVBackupervice;
        private readonly IMapper _mapper;

        public CVBackupController(ICVBackupService CVBackupervice, IMapper mapper)
        {
            this._mapper = mapper;
            this._CVBackupervice = CVBackupervice;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CVBackupResource>>> GetAllCVBackup()
        {
            var CVBackup = await _CVBackupervice.GetAllWithUserId(Guid.Parse(UserId));
            var musicResources = _mapper.Map<IEnumerable<CVBackup>, IEnumerable<CVBackupResource>>(CVBackup);

            return Ok(musicResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CVBackupResource>> GetMusicById(int id)
        {
            var music = await _CVBackupervice.GetById(id);
            var musicResource = _mapper.Map<CVBackup, CVBackupResource>(music);

            return Ok(musicResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CVBackupResource>> CreateCV([FromBody] SaveCVBackupResource savecvBackupResource)
        {
            var validator = new SaveCVBackupResourceValidator();
            var validationResult = await validator.ValidateAsync(savecvBackupResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var cvBackupToCreate = _mapper.Map<SaveCVBackupResource, CVBackup>(savecvBackupResource);
            cvBackupToCreate.UserId = Guid.Parse(UserId);
            var newCV = await _CVBackupervice.Create(cvBackupToCreate);

            var cv = await _CVBackupervice.GetById(newCV.Id);

            var cvResource = _mapper.Map<CVBackup, CVBackupResource>(cv);

            return Ok(cvResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CVBackupResource>> UpdateCV(int id, [FromBody] SaveCVBackupResource saveCVResource)
        {
            var validator = new SaveCVBackupResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCVResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var cvToBeUpdate = await _CVBackupervice.GetById(id);

            if (cvToBeUpdate == null)
                return NotFound();
            var cv = _mapper.Map<SaveCVBackupResource, CVBackup>(saveCVResource);
            cv.UserId = Guid.Parse(UserId);

            await _CVBackupervice.Update(cvToBeUpdate, cv);

            var updatedCV = await _CVBackupervice.GetById(id);
            var updatedCVResource = _mapper.Map<CVBackup, CVBackupResource>(updatedCV);

            return Ok(updatedCVResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCV(int id)
        {
            if (id == 0)
                return BadRequest();

            var music = await _CVBackupervice.GetById(id);

            if (music == null)
                return NotFound();

            await _CVBackupervice.Delete(music);

            return NoContent();
        }
    }
}