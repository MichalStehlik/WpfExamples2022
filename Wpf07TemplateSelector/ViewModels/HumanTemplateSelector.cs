using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf07TemplateSelector.ViewModels
{
    internal class HumanTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject dependency)
        {
            if (item is Models.Teacher)
                return TeacherTemplate;
            if (item is Models.Student)
                return StudentTemplate;
            return HumanTemplate;
        }

        public DataTemplate TeacherTemplate { get; set; }
        public DataTemplate HumanTemplate { get; set; }
        public DataTemplate StudentTemplate { get; set; }
    }
}
