using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public Question Get(int id)
        {
            return _appDbContext.Questions
                .Include(q => q.Answers)
                .SingleOrDefault(q => q.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _appDbContext.Questions
                .Include(q => q.Answers)
                .ToList();
        }

        public Question Add(Question newQuestion)
        {
            _appDbContext.Questions.Add(newQuestion);
            _appDbContext.SaveChanges();

            return newQuestion;
        }

        public Question Update(Question updatedQuestion)
        {
            //retrieve the existing question
                var existingItem = this.Get(updatedQuestion.Id);
            if (existingItem == null) return null;

            // copy updated property values into the existing question
            _appDbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedQuestion);

            // loop thru all of the answers in the updated question
            foreach (var updatedAnswer in updatedQuestion.Answers)
            {
                // find the existing answer that corresponds to the updated answer
                var existingAnswer = existingItem.Answers
                .Where(a => a.Id == updatedAnswer.Id)
                .SingleOrDefault();
                // update existing answer from updated answer
                _appDbContext.Entry(existingAnswer)
                    .CurrentValues
                    .SetValues(updatedAnswer);
            }

            // save all the changes
            _appDbContext.Questions.Update(existingItem);
            _appDbContext.SaveChanges();
            return existingItem;
        }

        public void Remove(Question question)
        {
            var quest = _appDbContext.Questions.FirstOrDefault(q => q.Id == question.Id);

            _appDbContext.Questions.Remove(quest);

            _appDbContext.SaveChanges();
        }
    }
}
