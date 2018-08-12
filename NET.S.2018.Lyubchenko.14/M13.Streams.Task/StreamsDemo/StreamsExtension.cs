using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytes = 0;
            using (var reader = File.OpenRead(sourcePath))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Open))
                {
                    int oneByte = 0;
                    while ((oneByte = reader.ReadByte()) != -1)
                    {
                        writer.WriteByte((byte)oneByte);
                    }

                    bytes = (int)writer.Length - 1;
                }
            }

            return Math.Abs(bytes);
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int lenght;
            using (var reader = new StreamReader(sourcePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(reader.ReadToEnd());
                lenght = 0;

                using (var bynaryContainer = new MemoryStream(info))
                {
                    File.WriteAllBytes(destinationPath, bynaryContainer.ToArray());
                    lenght = info.Length - 1;
                }
            }

            return lenght;

            // Немножко изменил шаги 4-6

            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytes = 0;
            using (var reader = File.OpenRead(sourcePath))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Open))
                {
                    reader.CopyTo(writer);
                    bytes = (int)writer.Length;
                }
            }

            return bytes - 1;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        { 
            InputValidation(sourcePath, destinationPath);

            int lenght;
            using (var reader = new StreamReader(sourcePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(reader.ReadToEnd());
                lenght = 0;

                using (var bynaryContainer = new MemoryStream(info))
                {
                    char[] letters = new UTF8Encoding(true).GetChars(bynaryContainer.ToArray());
                    using (var writer = new StreamWriter(destinationPath))
                    {
                        writer.Write(letters);
                    }

                    lenght = info.Length - 1;
                }
            }

            return lenght;

        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytes = 0;
            using (var reader = new BufferedStream(new FileStream(sourcePath, FileMode.Open)))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Open))
                {
                    reader.CopyTo(writer);
                    bytes = (int)writer.Length;
                }
            }

            return bytes - 1;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int lines = 0;
            using (var reader = new StreamReader(sourcePath))
            {
                using (var writer = new StreamWriter(destinationPath))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                        lines++;
                    }

                    // записывает лишнюю пустую строку, соответственно нужно либо удалить ее, либо заставить цикл 
                    // делать на 1 обход меньше. Я не знаю как. Все остальные методы работают
                }
            }
            return lines;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            using (var input = new StreamReader(sourcePath))
            {
                using (var output = new StreamReader(destinationPath))
                {
                    
                    for (int i = 0; i < 100; i++)
                    {
                        if (input.ReadToEnd() != output.ReadToEnd())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion


        #region Txt file cleaner
        public static void ClearOutputFile(string output)
        {
            using (var file = File.Create(output))
            {

            }
        }
        #endregion
        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException($"Fill sourcePath");
            }

            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"Fill destinationPath");
            }

            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException($"File width soursePath '{sourcePath}' isn't exists");
            }

            if (!File.Exists(destinationPath))
            {
                throw new ArgumentException($"File width soursePath '{destinationPath}' isn't exists");
            }
        }
        #endregion

        #endregion

    }
}
