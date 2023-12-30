using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.businessLogic
{
    public class Alarm
    {
        static public void InvokeAlarm()
        {
            // Specify the path to your audio file
            string audioFilePath = @"C:\Users\Admin\source\repos\TaskManagement\Audio\alarm.wav";

            // Check if the file exists
            if (System.IO.File.Exists(audioFilePath))
            {
                // Create a SoundPlayer instance and load the audio file
                using (var player = new SoundPlayer(audioFilePath))
                {
                    //var loop = false;
                    //while (loop)
                    //{
                        // Play the audio file
                        player.Play();
                        
                    //}
                }
            }
            else
            {
                Console.WriteLine("The specified audio file does not exist.");
            }
        }
    }
}
