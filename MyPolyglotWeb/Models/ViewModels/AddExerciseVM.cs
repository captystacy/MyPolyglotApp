using MyPolyglotWeb.Models.ViewModels.CustomAttributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPolyglotWeb.Models.ViewModels
{
    public class AddExerciseVM
    {
        [Required(ErrorMessage = "�� ������ ������� ����!")]
        [Range(1, long.MaxValue, ErrorMessage = "����� �� ��������� ������� ����?")]
        public virtual string LessonId { get; set; }

        [Required(ErrorMessage = "�� ������ ������ ������� �����!")]
        [DisplayName("�� �������")]
        public string RusPhrase { get; set; }

        [Required(ErrorMessage = "�� ������ ������ ���������� �����!")]
        [DisplayName("�� ����������")]
        public string EngPhrase { get; set; }

        [RecognizedWordsByUser(ErrorMessage = "�� ������ ������� ��� �����!")]
        [DisplayName("�������������� �����")]
        public IEnumerable<UnrecognizedWordVM> UnrecognizedWords { get; set; }
    }
}