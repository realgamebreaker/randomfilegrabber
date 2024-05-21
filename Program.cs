using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Windows;

namespace RandomFileGrabber
{
    internal class Program
    {
        static string path = @"C:\folder"; // e.g. C:\folder
        static string extension = ".png"; // e.g. png would set it to only search png images

        static void Main(string[] args)
        {
            if (Directory.Exists(path))
            {
                // Get all files in the directory
                string[] allFiles = Directory.GetFiles(path);
                Console.WriteLine("Found " + allFiles.Length + " files in the given directory.");

                // Filter files by the specified extension
                string[] filteredFiles = allFiles.Where(file => file.EndsWith(extension, StringComparison.OrdinalIgnoreCase)).ToArray();
                Console.WriteLine("Found " + filteredFiles.Length + " " + extension + " files");
                if (filteredFiles.Length > 0)
                {
                    // Select a random file
                    Random rand = new Random();
                    int randomIndex = rand.Next(filteredFiles.Length);
                    string randomFile = filteredFiles[randomIndex];

                    MessageBox.Show("Random file: " + randomFile);
                }
                else
                {
                    Console.WriteLine("No files with the specified extension were found.");
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }
    }
}