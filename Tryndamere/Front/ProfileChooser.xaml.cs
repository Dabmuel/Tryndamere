﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tryndamere.Front
{
    /// <summary>
    /// Logique d'interaction pour ProfileChooser.xaml
    /// </summary>
    public partial class ProfileChooser : Page
    {
        public ProfileChooser()
        {
            InitializeComponent();
        }

        private void profileListBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach(Frame frame in ((ListBox)sender).Items)
            {
                frame.Width = ((ListBox)sender).ActualWidth - 14;
            }
        }
    }
}
