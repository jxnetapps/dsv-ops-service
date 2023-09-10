using Dsv.Contracts.PeopleOps;
using Dsv.WebAPI.Controllers.Models;
using HybridModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Dsv.WebAPI.Controllers
{
    [ApiController]
    public class PeopleOpsController : ControllerBase
    {
        readonly IPeopleOps _coreService;
        public PeopleOpsController(IPeopleOps peopleOps)
        {
            _coreService = peopleOps;
        }

        [Route("/v1/people")]
        [HttpPost]
        public async Task<ActionResult<CreatePeople.Response>> CreatePeopleAsync([FromBody] CreatePeople.Request request)
        {
            var response = await _coreService.CreatePeopleAsync(request);

            return Ok(response);
        }

        [Route("/v1/people")]
        [HttpGet]
        public async Task<ActionResult<GetPeoples.Response>> GetPeoplesAsync([FromQuery] GetPeoples.Request request)
        {
            var response = await _coreService.GetPeoplesAsync(request);

            return Ok(response);
        }

        [Route("/v1/people/{id}")]
        [HttpGet]
        public async Task<ActionResult<GetPeoples.Response>> GetPeopleAsync([FromRoute] GetPeople.Request request)
        {
            var response = await _coreService.GetPeopleAsync(request);

            return Ok(response);
        }

        [Route("/v1/people/{id}")]
        [HttpPut]
        public async Task<ActionResult<UpdatePeople.Response>> UpdateAsync([FromHybrid] UpdatePeopleReq req)
        {
            var response = await _coreService.UpdateAsync(req.GetRequest());

            return Ok(response);
        }

        [Route("/v1/people/{id}")]
        [HttpDelete]
        public async Task<ActionResult<DeletePeople.Response>> DeletePeopleAsync([FromRoute] DeletePeople.Request request)
        {
            var response = await _coreService.DeletePeopleAsync(request);

            return Ok(response);
        }
    }
}
