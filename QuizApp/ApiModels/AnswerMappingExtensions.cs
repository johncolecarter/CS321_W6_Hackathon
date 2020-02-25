using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.ApiModels;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class AnswerMappingExtensions
	{

		public static AnswerModel ToApiModel(this Answer item)
		{
            // TODO: map domain properties to equivalent ApiModel properties
            return new AnswerModel
			{
                Id = item.Id,
                Content = item.Content,
                IsCorrect = item.IsCorrect,
                QuestionId = item.QuestionId,
			};
		}

		public static Answer ToDomainModel(this AnswerModel item)
		{
            // TODO: map ApiModel properties to equivalen domain properties
			return new Answer
			{
                Id = item.Id,
                Content = item.Content,
                IsCorrect = item.IsCorrect,
                QuestionId = item.QuestionId,
			};
		}

		public static IEnumerable<AnswerModel> ToApiModels(this IEnumerable<Answer> items)
		{
			return items.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Answer> ToDomainModels(this IEnumerable<AnswerModel> items)
		{
			return items.Select(a => a.ToDomainModel());
		}
	}
}
