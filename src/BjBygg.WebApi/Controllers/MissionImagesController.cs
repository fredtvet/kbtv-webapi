using BjBygg.Application.Application.Commands.MissionCommands.Images;
using BjBygg.Application.Application.Commands.MissionCommands.Images.Mail;
using BjBygg.Application.Application.Commands.MissionCommands.Images.Upload;
using BjBygg.Application.Application.Common.Dto;
using BjBygg.Application.Application.Queries.DbSyncQueries;
using BjBygg.Application.Application.Queries.DbSyncQueries.Common;
using BjBygg.Application.Common.Exceptions;
using CleanArchitecture.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BjBygg.WebApi.Controllers
{
    public class MissionImagesController : BaseController
    {
        public MissionImagesController() { }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<ActionResult<DbSyncResponse<MissionImageDto>>> Sync(MissionImageSyncQuery request)
        {
            return await Mediator.Send(request);
        }

        [Authorize(Roles = RolePermissions.MissionImageActions.Create)]
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> Upload(string missionId)
        {
            if (Request.Form.Files.Count() == 0)
                throw new BadRequestException("No files received");

            using (var streamList = new DisposableList<BasicFileStream>())
            {
                streamList.AddRange(Request.Form.Files.ToList()
                    .Select(x => new BasicFileStream(x.OpenReadStream(), x.FileName)));

                var request = new UploadMissionImageCommand()
                {
                    Files = streamList,
                    MissionId = missionId
                };

                await Mediator.Send(request);
                return NoContent();
            }

            
        }

        [Authorize(Roles = RolePermissions.MissionImageActions.Delete)]
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> Delete(DeleteMissionImageCommand request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        [Authorize(Roles = RolePermissions.MissionImageActions.Delete)]
        [HttpPost]
        [Route("api/[controller]/DeleteRange")]
        public async Task<ActionResult> DeleteRange([FromBody] DeleteRangeMissionImageCommand request)
        {
            await Mediator.Send(request);
            return NoContent();
        }

        [Authorize(Roles = RolePermissions.MissionImageActions.SendEmail)]
        [HttpPost]
        [Route("api/[controller]/SendImages")]
        public async Task<ActionResult> SendImages([FromBody] MailMissionImagesCommand request)
        {
            await Mediator.Send(request);
            return NoContent();
        }
    }
}
