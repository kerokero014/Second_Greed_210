using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;


namespace Greed
{
    class Program
    {
        private static int FRAME_RATE = 7;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLUMS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT = 20;


 
        static void Main(string[] args)
        {
            Cast cast = new Cast();
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            Actor robot = new Actor();
            robot.SetText("<^>");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X/2, MAX_Y - 30));
            cast.AddActor("robot", robot);

            Random random = new Random();
            for (int i = 0; i < DEFAULT; i++)
            {
                string text = ((char)(42)).ToString();

                int x = random.Next(1, COLUMS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 1;
                int g = 255;
                int b = 1;
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(1);
                cast.AddActor("artifacts", artifact);
            }

            for (int i = 0; i < DEFAULT; i++)
            {
                string text = ((char)(111)).ToString();
                //string message = messages[i];

                int x = random.Next(1, COLUMS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = 255;
                int g = 1;
                int b = 1;
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(-1);
                cast.AddActor("artifacts", artifact);
            }

            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            WindowService windowService = new WindowService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, windowService);
            director.StartGame(cast); 
        }
    }
}