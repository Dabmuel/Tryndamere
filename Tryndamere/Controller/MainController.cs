using System;
using System.Collections.Generic;
using System.Text;
using Tryndamere.Front;
using Tryndamere.Back;

namespace Tryndamere.Controller
{
    class MainController
    {
        private MainWindow mainWindow { get; set; }

        private AbstractPageController activePageController { get; set; }

        public MainController(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            init();
        }

        private void init()
        {
            setProfileChooser();
        }

        private void setProfileChooser()
        {
            activePageController = new ProfileChooserController();

            mainWindow.pageContainer.Content = activePageController.getPage;
        }
    }
}
