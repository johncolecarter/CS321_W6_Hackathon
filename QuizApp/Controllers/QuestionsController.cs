using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_questionService.GetAll().ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetQuestions", ex.Message);
                return BadRequest(ModelState);
            } 
           
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var quiz = _questionService.Get(id);

                if (quiz == null) return NotFound();

                return Ok(quiz.ToApiModel());

            } catch
            {
                ModelState.AddModelError("GetQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        public IActionResult Add(Question newQuestion)
        {
            try
            {
                var question = _questionService.Add(newQuestion);

                return Ok(question.ToApiModel());
            }catch
            {
                ModelState.AddModelError("AddQuestion", "Not Implemented!");
                return NotFound(ModelState);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            try
            {
                var quiz = _questionService.Update(questionModel.ToDomainModel());

                if (quiz == null) return NotFound();

                return Ok(quiz);

            } catch
            {
                ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _questionService.Remove(id);

                return Ok();
            } catch
            {
                ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
                            return BadRequest(ModelState);
            }
            
        }
    }
}
