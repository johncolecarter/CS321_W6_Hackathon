using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            ModelState.AddModelError("GetQuestions", "Not Implemented!");
            return NotFound(ModelState);
            //var questions = _questionService.GetAll().ToList();
            //return Ok(questions.ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ModelState.AddModelError("GetQuestion", "Not Implemented!");
            return NotFound(ModelState);
            //var question = _questionService.Get(id);
            //return Ok(question.ToApiModel());
        }

        [HttpPost]
        public IActionResult Add([FromBody] QuestionModel questionModel)
        {
            ModelState.AddModelError("AddQuestion", "Not Implemented!");
            return NotFound(ModelState);
            //var savedQuestion = _questionService.Add(questionModel.ToDomainModel());
            //return CreatedAtAction("Get", new { Id = savedQuestion.Id }, savedQuestion.ToApiModel());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            ModelState.AddModelError("UpdateQuestion", "Not Implemented!");            
            return NotFound(ModelState);
            //var updatedQuestion = _questionService.Update(questionModel.ToDomainModel());
            //return Ok(updatedQuestion.ToApiModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
            return NotFound(ModelState);
            //_questionService.Remove(id);
            //return Ok();
        }
    }
}
