using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows;

namespace TheProject.Models
{
    public static class AnimationHelper
    {

        // Método para aplicar una animación de deslizamiento hacia la izquierda
        public static void SlideLeft(UIElement element)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 0,
                To = -300,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        // Método para aplicar una animación de deslizamiento hacia la derecha
        public static void SlideRight(UIElement element)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        // Método para aplicar una animación de deslizamiento hacia arriba
        public static void SlideUp(UIElement element)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 0,
                To = -300,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        // Método para aplicar una animación de deslizamiento hacia abajo
        public static void SlideDown(UIElement element)
        {
            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }






    }
}
