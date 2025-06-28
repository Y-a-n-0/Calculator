using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Calculator.Animation;

namespace Calculator
{
    class AnimationButton : Button
    {
        static AnimationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimationButton), new FrameworkPropertyMetadata(typeof(AnimationButton)));
        }

        static MainWindow main_window;
        private List<AnimationButton> button_list = new List<AnimationButton>();

        public AnimationButton(MainWindow main)
        {
            main_window = main;
        }

        private Thickness m_margin = new Thickness();
        private Point m_start_pt;
        private Point m_end_pt;
        private Color m_background_color;
        LinearGradientBrush m_clone_brush;
        AnimationController m_controller;
        


        public AnimationButton()
        {
            this.Loaded += (s, e) =>
            {

                LinearGradientBrush origin_brush;
                if(this.Uid == "func")
                {
                    origin_brush = (LinearGradientBrush)this.FindResource("CalculatorFuncButtonBrush");
                }
                else
                {
                    origin_brush = (LinearGradientBrush)this.FindResource("CalculatorButtonBrush");
                }

                    m_clone_brush = origin_brush.Clone();
                this.Background = m_clone_brush;

                m_start_pt = m_clone_brush.StartPoint;
                m_end_pt = m_clone_brush.EndPoint;


                m_margin = this.Margin;
                
            };
            m_controller = new AnimationController();

            button_list.Add(this);

            this.MouseEnter += AnimationButton_MouseEnter;
            this.MouseLeave += AnimationButton_MouseLeave;
        }

        private void AnimationButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            m_controller.ChangeMargin(this,new Thickness(m_margin.Left - 5, m_margin.Top - 5, m_margin.Right - 5, m_margin.Bottom - 5));
            m_controller.ChangeColorStartPointEndPoint(this.Background,new Point(m_start_pt.X + 1, m_start_pt.Y + 1), m_end_pt);
        }

        private void AnimationButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            m_controller.ChangeMargin(this, m_margin);
            m_controller.ChangeColorStartPointEndPoint(this.Background, m_start_pt, m_end_pt);
        }
    }
}
