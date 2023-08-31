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
        // Using a DependencyProperty as the backing store for TitleContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register ("TitleTemplate", typeof (DataTemplate), typeof (DarkWindow), new PropertyMetadata (null));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register ("Title", typeof (object), typeof (DarkWindow), new UIPropertyMetadata (null));
        public DataTemplate TitleTemplate
        {
            get { return (DataTemplate)GetValue (TitleTemplateProperty); }
            set { SetValue (TitleTemplateProperty, value); }
        }
        public new object Title
        {
            get => (object)GetValue (TitleTemplateProperty);
            set => SetValue (TitleTemplateProperty, value);
        }

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
            if (GetTemplateChild ("PART_MinButton") is Button minbtn)
            {
                minbtn.Click += (s, e) => this.WindowState = WindowState.Minimized;
            }
            //if (GetTemplateChild ("PART_MaxButton") is MaximizeButton maxbtn)
            //{
            //    maxbtn.Click += (s, e) =>
            //    {
            //        if (maxbtn.Maximize)
            //        {
            //            this.WindowState = WindowState.Normal;
            //            maxbtn.Maximize = !maxbtn.Maximize;
            //            return;
            //        }
            //        this.WindowState = WindowState.Maximized;
            //        maxbtn.Maximize = !maxbtn.Maximize;
            //    };
            //}
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
