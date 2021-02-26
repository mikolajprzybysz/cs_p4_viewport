using System;
using System.Collections.Generic;
using System.Linq;
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

namespace p4_viewport
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void setColor(object sender, MouseButtonEventArgs e)
        {
            
            int width = (int)pallet.ActualWidth;
            int height = (int)pallet.ActualHeight;
            
            int x = (int)Mouse.GetPosition(this).X;
            int y = (int)Mouse.GetPosition(this).Y;

            
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            
            rtb.Render(pallet);
            int stride = width * ((rtb.Format.BitsPerPixel + 7) / 8);
            byte[] pixels = new byte[stride * height];
            BitmapFrame bf = BitmapFrame.Create(rtb);
            bf.CopyPixels(pixels, stride, 0);
            Color newColor = Color.FromRgb(pixels[y * stride + x * stride / width + 2], pixels[y * stride + x * stride / width + 1], pixels[y * stride + x * stride / width]);
            

            Gradient.Color = newColor;
            
        }

    }
}
