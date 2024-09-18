using System;
using System.Threading;
using NAudio.Wave;

namespace SnakeMaduussTARpv23
{
    public class Program
    {
        static void Main(string[] args)
        {
            //0. Audio
            IWavePlayer waveOutDevice = new WaveOutEvent();
            AudioFileReader audioFileReader = new AudioFileReader("../../../song.mp3");

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();

            FileSaveRead fileSaveRead = new FileSaveRead();

            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Console.ForegroundColor = ConsoleColor.Red;
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    EatSound.PlayEatSound(); // Correctly call the static method

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
            GameOver.WriteGameOver();
            Console.ReadLine();
        }
    }
}
