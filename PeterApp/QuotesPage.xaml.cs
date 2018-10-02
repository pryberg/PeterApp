using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PeterApp
{
    public partial class QuotesPage : ContentPage
    {
        public QuotesPage()
        {
            InitializeComponent();

            string[] texts = new String[] {
                "Lifw ia like riding a bicycle. To keep your balance, you must keep moving.",
                "You can't blame gravity for falling in love",
                "Look deep into nature, and then you will understand everything better."};
            ltext.Text = texts[1];
            lfont.Text = "Font Size: 16";
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            ltext.Text = String.Format("Test is:");
        }

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            lfont.Text = String.Format("Font Size: {0:F0}", e.NewValue); 

        }
    }
}
