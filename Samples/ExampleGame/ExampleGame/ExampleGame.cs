using System;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wobble;
using Wobble.Audio;
using Wobble.Audio.Samples;
using Wobble.Audio.Tracks;
using Wobble.Input;
using Wobble.Resources;
using Wobble.Screens;
using Wobble.Window;

namespace ExampleGame
{
    public class ExampleGame : WobbleGame
    {
        public Texture2D Spongebob;

        public AudioTrack Song;

        public ExampleGame()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

            MouseManager.ShowCursor();
            Window.AllowUserResizing = true;

            ScreenManager.AddScreen(new SampleScreen());
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Spongebob = ResourceLoader.LoadTexture2D(ResourceStore.spongebob, ImageFormat.Png);

            Song = new AudioTrack(ResourceStore.Valence___Infinite);
            Console.WriteLine(Song.Length);
            Song.Seek(3000);
            Console.WriteLine(Song.Position);
            Song.Play();
            Thread.Sleep(1000);
            Song.Pause();
            Thread.Sleep(2000);
            Song.Seek(15000);
            Song.Play();
            Thread.Sleep(2000);
            Song.Stop();
            Console.WriteLine(Song.IsDisposed);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            Spongebob.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MouseManager.IsUniqueClick(MouseButton.Left))
                WindowManager.ChangeScreenResolution(new Point(1600, 900));
            else if (MouseManager.IsUniqueClick(MouseButton.Right))
                WindowManager.ChangeScreenResolution(new Point(1920, 1080));
            else if (MouseManager.IsUniqueClick(MouseButton.Middle))
                WindowManager.ChangeScreenResolution(new Point(800, 600));
        }

        protected override void Draw(GameTime gameTime) => base.Draw(gameTime);
    }
}