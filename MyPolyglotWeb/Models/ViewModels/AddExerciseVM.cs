using MyPolyglotWeb.Constants;
using MyPolyglotWeb.Models.ViewModels.CustomAttributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPolyglotWeb.Models.ViewModels
{
    public class AddExerciseVM
    {
        [Required(ErrorMessage = "�� ������ ������� ����!")]
        [Range(1, 31, ErrorMessage = CustomConst.UserTriesToBreakMe)]
        public virtual string LessonId { get; set; }

        [Required(ErrorMessage = "�� ������ ������ ������� �����!")]
        [DisplayName("�� �������")]
        public string RusPhrase { get; set; }

        [Required(ErrorMessage = "�� ������ ������ ���������� �����!")]
        [DisplayName("�� ����������")]
        public string EngPhrase { get; set; }

        [RecognizedWordsByUser(ErrorMessage = "�� ������ ������� ��� �����!")]
        [DisplayName("�������������� �����")]
        public List<UnrecognizedWordVM> UnrecognizedWords { get; set; }
    }
}