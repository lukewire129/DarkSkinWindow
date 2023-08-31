using DarkSkinWindow.UI.Units;
using Jamesnet.Wpf.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DarkSkinWindow.UI.Views
{
    public class DarkWindow : JamesWindow
    {
        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
        }

        public override void OnApplyTemplate()
        {
            if (GetTemplateChild ("PART_CloseButton") is Button btn)
            {
                btn.Click += (s, e) => Close ();
            }
            if (GetTemplateChild ("PART_DragBar") is DraggableBar bar)
            {
                bar.MouseDown += WindowDragMove;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed (e);
        }

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                GetWindow (this).DragMove ();
            }
        }
    }
}
