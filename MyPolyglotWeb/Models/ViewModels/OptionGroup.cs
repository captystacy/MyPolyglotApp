﻿using MyPolyglotWeb.Models.ViewModels.CustomAttributes;
using System.Collections.Generic;

namespace MyPolyglotWeb.Models.ViewModels
{
    public class OptionGroup
    {
        [RequiredOptions(ErrorMessage ="Зачем ты пытаешься сломать меня?")]
        public List<string> Options { get; set; }
    }
}
