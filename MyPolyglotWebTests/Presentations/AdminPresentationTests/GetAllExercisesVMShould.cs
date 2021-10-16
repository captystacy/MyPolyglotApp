﻿using AutoMapper;
using Moq;
using MyPolyglotCore.Interfaces;
using MyPolyglotWeb.Models.DomainModels;
using MyPolyglotWeb.Models.ViewModels;
using MyPolyglotWeb.Presentations;
using MyPolyglotWeb.Repositories.IRepositories;
using System.Linq;
using Xunit;

namespace MyPolyglotWebTests.Presentations.AdminPresentationTests
{
    public class GetAllExercisesVMShould
    {
        private AdminPresentation _adminPresentation;
        private Mock<IMapper> _mapperMock;
        private Mock<ILessonRepository> _lessonRepositoryMock;
        private Mock<IExerciseRepository> _exerciseRepositoryMock;
        private Mock<IUnrecognizedWordRepository> _unrecognizedWordRepositoryMock;
        private Mock<IRecognizer> _recognizerMock;

        public GetAllExercisesVMShould()
        {
            _mapperMock = new Mock<IMapper>();
            _lessonRepositoryMock = new Mock<ILessonRepository>();
            _exerciseRepositoryMock = new Mock<IExerciseRepository>();
            _unrecognizedWordRepositoryMock = new Mock<IUnrecognizedWordRepository>();
            _recognizerMock = new Mock<IRecognizer>();
            _adminPresentation = new AdminPresentation(_mapperMock.Object, _lessonRepositoryMock.Object,
                _exerciseRepositoryMock.Object, _unrecognizedWordRepositoryMock.Object, _recognizerMock.Object);
        }

        [Fact]
        public void ReturnAllMappedWordsFromRepository()
        {
            var exercisesDB = Enumerable.Empty<ExerciseDB>().AsQueryable();
            _exerciseRepositoryMock.Setup(x => x.GetAll()).Returns(exercisesDB);
            var allExercisesVM = new AllExercisesVM();
            _mapperMock.Setup(x => x.Map<AllExercisesVM>(exercisesDB)).Returns(allExercisesVM);

            var result = _adminPresentation.GetAllExercisesVM();

            _exerciseRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            _mapperMock.Verify(x => x.Map<AllExercisesVM>(exercisesDB), Times.Once);
            Assert.Equal(result, allExercisesVM);
        }
    }
}
