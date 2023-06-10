using ChatIntegrationsHunty.Api.Exceptions;
using Dto.Message;
using Dto.ReceiveMessage;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace ChatIntegrationsHunty.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IExceptionHandler _exceptionHandler;

        public MessageController(IMessageService messageService, IExceptionHandler exceptionHandler)
        {
            _messageService = messageService;
            _exceptionHandler = exceptionHandler;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageDataDtoRequest messageDataDtoRequest)
        {
            try
            {
                var response = await _messageService.Send(messageDataDtoRequest);
                if (response.Data != null)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }

        [HttpGet("ReceiveMessage")]
        public IActionResult ReceiveMessage(
            [FromQuery(Name = "hub.mode")] string hubMode,
            [FromQuery(Name = "hub.challenge")] string hubChallenge,
            [FromQuery(Name = "hub.verify_token")] string hubVerifyToken
            //[FromQuery(Name = "messages")] string messages
            )
        {
            const string yourVerifyToken = "EAAJHagOHBdUBAKeueWvYjJUzDJqruPAM6dFg8aQZAw8kdev5P5S02UhGyRGkeOe7B64Xe4ARoOZC74Pb98PVWYPQtFWQmZCx9LrtgnflOKVPazyYyWYawgU2WUhvOmmkbkzZB3OoRVZBhI8Vb4HgX7OiSZCLuZAOTeyrJMtBsDgtHuA2ZBK8WOOIDkH1byPVHqCuKBUpZBzaWpr0JrRYI0cRe";

            if (hubMode == "subscribe" && hubVerifyToken == yourVerifyToken)
                return Content(hubChallenge);
            return BadRequest();
        }

        [HttpPost("ReceiveMessage")]
        public async Task<IActionResult> ReceiveMessage(Root message)
        {
            try
            {
                var response = await _messageService.Receive(message);
                if (response.Data != null)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }

        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessage()
        {
            try
            {
                var response = await _messageService.GetMessages();
                if (response.Data != null)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }
    }
}