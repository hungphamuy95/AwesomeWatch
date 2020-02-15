using System;
using Android.Views;
using Android.Support.Wearable.Watchface;
using Android.Service.Wallpaper;
using Android.Graphics;


namespace AwesomeWatch
{
    class MyWatchFaceService : CanvasWatchFaceService
    {
        
        public override WallpaperService.Engine OnCreateEngine()
        {
            return new MyWatchFaceEngine(this);
        }

        public class MyWatchFaceEngine : CanvasWatchFaceService.Engine
        {
            Paint hoursPaint;
            CanvasWatchFaceService _owner;
            public MyWatchFaceEngine(CanvasWatchFaceService owner):base(owner)
            {
                _owner = owner;
            }

          
            public override void OnCreate(ISurfaceHolder holder)
            {
                base.OnCreate(holder);
                SetWatchFaceStyle(new WatchFaceStyle.Builder(_owner)
                    .Build()
                    );
                hoursPaint = new Paint();
                hoursPaint.Color = Color.White;
                hoursPaint.TextSize = 48f;
            }

            public override void OnDraw(Canvas canvas, Rect frame)
            {
               
                var str = DateTime.Now.ToString("h:mm tt");
                canvas.DrawText(str,
                    frame.Left + 70,
                    frame.Top + 80, hoursPaint);
            }

            public override void OnTimeTick()
            {
                Invalidate();
            }
        }
    }
}