// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using OtripleS.Web.Api.Models.Exams;
using OtripleS.Web.Api.Models.Exams.Exceptions;

namespace OtripleS.Web.Api.Services.Exams
{
    public partial class ExamService
    {
        private void ValidateExamOnAdd(Exam exam)
        {
            ValidateExamIdIsNotNull(exam);
            ValidateExamId(exam.Id);
        }
        private void ValidateExamId(Guid examId)
        {
            if (IsInvalid(examId))
            {
                throw new InvalidExamInputException(
                    parameterName: nameof(Exam.Id),
                    parameterValue: examId);
            }
        }

        private void ValidateStorageExam(Exam storageExam, Guid examId)
        {
            if (storageExam == null)
            {
                throw new NotFoundExamException(examId);
            }
        }

        private void ValidateExamIdIsNotNull(Exam exam)
        {
            if (exam == default)
            {
                throw new NullExamException();
            }
        }

        private static bool IsInvalid(Guid input) => input == default;
    }
}
