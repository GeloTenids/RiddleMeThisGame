using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using RiddleMeThisBL;
using RiddleMeThisDL;
using RiddleMeThisModel;

namespace Riddle.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class RiddleMeThisController : Controller
    {
        RiddleProcess _riddleProcess;
        UserServices _userServices;
            public RiddleMeThisController()
            {
                _riddleProcess = new RiddleProcess();
                //_userProcess = new UserProcess();
                _userServices = new UserServices();
            }

            [HttpGet("get-users")]
            public IEnumerable<Riddle.API.Users> GetUsers()
            {
                var activeusers = _userServices.GetUsers();

                List<Riddle.API.Users> users = new List<Users>();

                foreach (var item in activeusers)
                {
                    //int point = item.points.Value;
                    users.Add(new Riddle.API.Users { username = item.username, score = item.score });
                }

                return users;
            }
            [HttpGet("get-riddles")]
            public IEnumerable<Riddle.API.Riddles> GetRiddles()
            {
                var riddle = _riddleProcess.getRiddle();

                List<Riddle.API.Riddles> riddles = new List<Riddles>();

                foreach (var item in riddle)
                {
                    //int point = item.points.Value;
                    riddles.Add(new Riddle.API.Riddles { riddleNumber = item.number, riddleQuestion = item.question, riddleAnswer = item.answer });
                }

                return riddles;
            }

            [HttpPost("add-user")]
            public JsonResult AddUser(Users request)
            {
                //Points point = new Points();
                //point.score = request.score;
                var result = _userServices.AddUser(request.username, request.score);

                return new JsonResult(result);
            }
            [HttpPost("add-riddle")]
            public JsonResult AddRiddle(Riddles riddle)
            {
                var result = _riddleProcess.AddRiddles(riddle.riddleNumber, riddle.riddleQuestion, riddle.riddleAnswer);

                return new JsonResult(result);
            }

            [HttpPatch("update-user")]
            public JsonResult UpdateUser(Users request)
            {
                //Points point = new Points();
                //point.score = request.score;
                var result = _userServices.UpdateScore(request.username, request.score);

                return new JsonResult(result);
            }
            [HttpPatch("update-riddle")]
            public JsonResult UpdateRiddle(Riddles riddle)
            {
                //Points point = new Points();
                //point.score = request.score;
                var result = _riddleProcess.UpdateRiddle(riddle.riddleNumber, riddle.riddleQuestion, riddle.riddleAnswer);

                return new JsonResult(result);
            }
            [HttpDelete("delete-user")]
            public JsonResult DeleteUser(Users request)
            {
                var result = _userServices.DeleteUser(request.username);
                return new JsonResult(result);
            }
            [HttpDelete("delete-riddle")]
            public JsonResult DeleteRiddle(Riddles riddle)
            {
                var result = _riddleProcess.DeleteRiddle(riddle.riddleNumber);
                return new JsonResult(result);
            }

            [HttpPost("upload-profile-photo")]
            public async Task<IActionResult> UploadProfilePhoto(IFormFile ProfilePhoto)
            {
                if (ProfilePhoto == null || ProfilePhoto.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var s3Service = new s3Service();
                var fileUrl = await s3Service.UploadFileToS3(ProfilePhoto);

                if (fileUrl != null)
                {
                    return Ok(new { FileUrl = fileUrl });
                }

                return StatusCode(500, "File upload failed.");
            }

    }
}

