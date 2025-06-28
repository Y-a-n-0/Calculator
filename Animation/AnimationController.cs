using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Calculator.Animation
{
    class AnimationController
    {

        public AnimationController() { }

        public void ChangeMargin(UIElement m_this,Thickness newthickness)
        {
            ThicknessAnimation animation = new ThicknessAnimation
            {
                To = newthickness,

                Duration = new Duration(TimeSpan.FromMilliseconds(200)),

                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }

            };
            m_this.BeginAnimation(Button.MarginProperty, animation);
        }

        public void ChangeColorStartPointEndPoint(Brush m_this, Point st_pt, Point end_pt)
        {
            PointAnimation start_point_anime = new PointAnimation
            {
                To = st_pt,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            PointAnimation end_point_anime = new PointAnimation
            {
                To = end_pt,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            m_this.BeginAnimation(LinearGradientBrush.StartPointProperty, start_point_anime);
            m_this.BeginAnimation(LinearGradientBrush.EndPointProperty, end_point_anime);
        }

        public void ChangeColor(Brush m_this,Color color)
        {
            ColorAnimation animation = new ColorAnimation
            {
                To = color,
                Duration = TimeSpan.FromMilliseconds(50),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };


            m_this.BeginAnimation(GradientStop.ColorProperty,animation);
        }
    }
}
