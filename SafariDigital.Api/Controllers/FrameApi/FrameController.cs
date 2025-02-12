using Digital.Lib.Net.Authentication.Attributes;
using Digital.Lib.Net.Core.Messages;
using Digital.Lib.Net.Entities.Repositories;
using Digital.Lib.Net.Entities.Services;
using Digital.Lib.Net.Mvc.Controllers.Crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafariDigital.Api.Attributes;
using SafariDigital.Api.Dto.Entities;
using SafariDigital.Core.Application;
using SafariDigital.Data.Models.Frames;

namespace SafariDigital.Api.Controllers.FrameApi;

[ApiController, Route("frame"), Authorize(AuthorizeType.Jwt)]
public class FrameController(
    IRepository<Frame> frameRepository,
    IEntityService<Frame> frameService
) : CrudController<Frame, FrameModel, FramePayload>(frameService)
{
    [HttpPost("{id:guid}/duplicate")]
    public async Task<ActionResult<Result>> PostDuplicate(Guid id)
    {
        var result = new Result();
        var source = await frameRepository.GetByIdAsync(id);
        if (source is null)
            return BadRequest(result.AddError(ApplicationMessageCode.RessourceNotFound));
        var frame = await frameRepository.Get(vf => vf.Name == source.Name).FirstOrDefaultAsync();
        if (frame is not null)
            return BadRequest(result.AddError(ApplicationMessageCode.UniqueViolation));

        // TODO: Implement loop to duplicate with copy prefix
        // Implement duplication method in Digital.Net.Entities

        return Ok(result);
    }
}