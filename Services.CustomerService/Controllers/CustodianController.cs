using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CustomerService.Command;
using Services.CustomerService.Services.Interfaces;

namespace Services.CustomerService.Controllers
{
    /// <summary>
    /// CustodianController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustodianController : ControllerBase
    {
        /// <summary>
        /// The i custodian support service
        /// </summary>
        private readonly ICustodianSupportService _ICustodianSupportService;
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;
        /// <summary>
        /// CustodianController
        /// </summary>
        /// <param name="custodianSupportService">The custodian support service.</param>
        /// <param name="mediator">The mediator.</param>
        /// <exception cref="ArgumentNullException">mediator</exception>
        public CustodianController(ICustodianSupportService custodianSupportService, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ICustodianSupportService = custodianSupportService;
        }

        /// <summary>
        /// Get Reject Reason List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/rejectreason/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetRejectReasonList()
        {
            var result = await _ICustodianSupportService.GetRejectReasonList();
            return Ok(result);
        }

        /// <summary>
        /// Get Event Master list based on statusId.
        /// </summary>
        /// <param name="eventMasterStatusId">The event master status identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/geteventmaster/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetEventMaster(int eventMasterStatusId)
        {
            var result = await _ICustodianSupportService.GetEventMaster(eventMasterStatusId);
            return Ok(result);
        }

        /// <summary>
        /// RejectedEventsAction
        /// </summary>
        /// <param name="rejectedEventsActionCommand">The rejected events action command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/rejectedeventsaction/flag/put")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> RejectedEventsAction(RejectedEventsActionCommand rejectedEventsActionCommand)
        {
            if (ModelState.IsValid && (rejectedEventsActionCommand != null))
            {
                var result = await _mediator.Send(rejectedEventsActionCommand);
                return Ok(result);
            }

            return Ok(0);
        }

        /// <summary>
        /// EventDetailsHeader
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventdetailsheader/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> EventDetailsHeader(string eventId)
        {
            var result = await _ICustodianSupportService.EventDetailsHeader(eventId);
            return Ok(result);
        }
        /// <summary>
        /// EventDetails
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventdetails/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> EventDetails(string eventId)
        {
            var result = await _ICustodianSupportService.EventDetails(eventId);
            return Ok(result);
        }
        /// <summary>
        /// EventDetailsAssetList
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/eventdetailsassetlist/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> EventDetailsAssetList(string eventId)
        {
            var result = await _ICustodianSupportService.EventDetailsAssetList(eventId);
            return Ok(result);
        }

        /// <summary>
        /// This API used to get certified uploaded file list.
        /// </summary>
        /// <param name="certificateStatusId">The certificate status.</param>
        /// <returns>Uploaded file list.</returns>
        [HttpGet]
        [Route("~/eventuploadedfiles/list/get")]
        [ProducesResponseType(typeof(FileResult), 200)]
        public async Task<IActionResult> GetUploadFileHistoryList(int certificateStatusId = -1)
        {
            var result = await _ICustodianSupportService.GetUploadFileHistoryList(certificateStatusId);
            return Ok(result);
        }

        /// <summary>
        /// This API used to delete uploaded file.
        /// </summary>
        /// <param name="removeUploadFileFlagCommand">The remove upload file flag command.</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("~/eventuploadedfiles/flag/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteUploadedFile(RemoveUploadFileFlagCommand removeUploadFileFlagCommand)
        {
            var result = await _mediator.Send(removeUploadFileFlagCommand);
            if (result == 1)
            {
                return Ok(result);
            }

            // returning no content if the update is unsuccessful
            return Ok(0);
        }
    }
}