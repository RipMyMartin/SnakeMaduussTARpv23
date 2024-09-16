using System;
using System.Threading;
using NAudio.Wave;

namespace SnakeMaduussTARpv23
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWavePlayer waveOutDevice = new WaveOutEvent();
            AudioFileReader audioFileReader = new AudioFileReader("../../../song.mp3");

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();

            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            // Создаем проигрыватель для еды
            IWavePlayer eatSoundPlayer = new WaveOutEvent();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    // Воспроизводим звук при поедании еды
                    PlayEatSound();

                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();

            static void WriteGameOver()
            {
                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = ConsoleColor.Green;

                string gameOverText = "   G A M E     O V E R     ";

                for (int i = 0; i < 5; i++)
                {
                    WriteText(gameOverText, xOffset, yOffset + i);
                }
            }

            static void WriteText(string text, int xOffset, int yOffset)
            {
                Console.SetCursorPosition(xOffset, yOffset);
                Console.Write(text);
            }

            static void PlayEatSound()
            {
                var eatSoundPlayer = new WaveOutEvent();
                var eatSoundReader = new AudioFileReader("../../../BadBone.mp3");

                eatSoundPlayer.Init(eatSoundReader);
                eatSoundPlayer.Play();
                Task.Run(() =>
                {
                    while (eatSoundPlayer.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }

                    eatSoundPlayer.Dispose();
                    eatSoundReader.Dispose();
                });
            }
        }+
    }
}
