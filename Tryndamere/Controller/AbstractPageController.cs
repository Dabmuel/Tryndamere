using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Tryndamere.Controller
{
    abstract class AbstractPageController
    {

        protected Page page { get; set; }

        public Page getPage { get => page; }
    }
}
