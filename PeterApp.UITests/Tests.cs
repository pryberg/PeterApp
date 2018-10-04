using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PeterApp.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;


        //static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("MyLabel"). Text("Hello, Xamarin.Forms!");
        //static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("nextButton").Text("Next");
        //static readonly Func<AppQuery, AppQuery> Button = c => c.Marked("MyButton");
        //static readonly Func<AppQuery, AppQuery> DoneMessage = c => c.Marked("MyLabel").Text("Was clicked");

        //static readonly Func<AppQuery, AppQuery> TextMessage = c => c.Marked("textLabel").Text("Font Size: 16");

        static readonly Func<AppQuery, AppQuery> TextMessage = c => c.Marked("textLabel");

        static readonly Func<AppQuery, AppQuery> NextButton = c => c.Marked("nextButton");
        static readonly Func<AppQuery, AppQuery> FontSizeSlider = c => c.Marked("fontSizeSlider").Text("16");


        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            //const string simId = "FAEAE686-4CEA-4C7A-B8E6-3C23ECD66099"; // iPhone 6s (12.0) [FAEAE686-4CEA-4C7A-B8E6-3C23ECD66099] (Simulator)
            //app = ConfigureApp.iOS.DeviceIdentifier(simId).StartApp();
        }



        [Test]
        public void ScreenBeforePressNextButton()
        {
      //     app.Repl();
            AppResult[] results = app.WaitForElement(c => c.Marked("nextButton"));

            app.Screenshot("Screen Before Press the Next Button");

            Assert.AreEqual("Font Size: 16", 
                            app.Query(c => c.Marked("textLabel")).First().Text);


            Assert.AreEqual("You can't blame gravity for falling in love",
                            app.Query(c => c.Marked("fontSizeLabel")).First().Text);
        }


        [Test]
        public void ScreenAfterPressNextButton()
        {
            app.WaitForElement(c => c.Marked("nextButton"));

            // Act
            app.Tap(c => c.Marked("nextButton"));

            // ScreenShot
            app.Screenshot("Screen aften pressed the button");

            // Assert
            Assert.AreNotEqual("You can't blame gravity for falling in love",
                app.Query(c => c.Marked("fontSizeLabel")).First().Text);
        }
    }
}
