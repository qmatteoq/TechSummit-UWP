using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsComposition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnApplyEffect(object sender, RoutedEventArgs e)
        {
            Compositor compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            var graphicsEffect = new GaussianBlurEffect
            {
                Name = "Blur",
                Source = new CompositionEffectSourceParameter("Backdrop"),
                BlurAmount = 3.0f,
                BorderMode = EffectBorderMode.Hard
            };

            var blurEffectFactory = compositor.CreateEffectFactory(graphicsEffect,
                new[] { "Blur.BlurAmount" });

            var brush = blurEffectFactory.CreateBrush();

            var destinationBrush = compositor.CreateBackdropBrush();
            brush.SetSourceParameter("Backdrop", destinationBrush);

            var blurSprite = compositor.CreateSpriteVisual();
            blurSprite.Size = new Vector2((float)BackgroundImage.ActualWidth, (float)BackgroundImage.ActualHeight);
            blurSprite.Brush = brush;

            ElementCompositionPreview.SetElementChildVisual(BackgroundImage, blurSprite);
        }
    }
}
