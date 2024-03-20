
using BackendLab01;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/v1/quizzes")]
public class ApiUserQuizController : Controller
{
    private IQuizUserService _userService;

    public ApiUserQuizController(IQuizUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<QuizDTO?> GetQuizById(int id)
    {
        var result = _userService.FindQuizById(id);

        if (result is null)
        {
            return NotFound();
        }

        return QuizDTO.Of(result);
    }

    [HttpPost]
    [Route("{quizId}/items/{itemId}/answers")]
    public IActionResult SaveAnswer(int quizId, int itemId, QuizItemUserAnswearDTO answer)
    {
        _userService.SaveUserAnswerForQuiz(quizId, 1 , itemId, answer.Answear);
        
        return Created();
    }
    
    
    [HttpPost]
    [Route("{quizId}/answers")]
    public ActionResult<Object> CountCorrectAnswers(int quizId)
    {
        int  count = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, 1);

        return new
        {
            ValidAnswears = count,
            QuizId = quizId,
            UserId = 1
        };
    }
}