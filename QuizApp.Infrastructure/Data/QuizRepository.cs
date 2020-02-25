using System;
using System.Collections.Generic;
using QuizApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuizRepository : IQuizRepository

    {
        private readonly AppDbContext _dbContext;
        // TODO: inherit and implement the IQuizRepository interface

        public QuizRepository(AppDbContext dbContext)
        {
            // TODO: inject and store AppDbContext
            _dbContext = dbContext;
        }

        public Quiz Add(Quiz quiz)
        {
            _dbContext.Quizzes.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Quiz Get(int id)
        {
            return _dbContext.Quizzes
                .Include(qq => qq.QuizQuestions)
                .ThenInclude(a => a.Answers)
                .ThenInclude(q => q.Questions)
                .ToList();

        }


        public IEnumerable<Quiz> GetAll()
        {
            return _dbContext.Quizzes
                 .Include(b => b.Questions)
                 .Include(b => b.Answers)
                 .ToList();
        }

        public Quiz Update(Quiz updatedQuiz)
        {
            //throw new NotImplementedException();
            var currentQuiz = _dbContext.Quizzes.Find(updatedQuiz.Id);
            if (currentQuiz == null) return null;

            _dbContext.Entry(currentQuiz)
                .CurrentValues
                .SetValues(updatedQuiz);

            // update the todo and save
            _dbContext.Quizzes.Update(currentQuiz);
            _dbContext.SaveChanges();
            return currentQuiz;
        }

        public void Remove(Quiz removeQuiz)
        {
            //throw new NotImplementedException();
            _dbContext.Quizzes.Remove(removeQuiz);
            _dbContext.SaveChanges();

        }



    }
}
