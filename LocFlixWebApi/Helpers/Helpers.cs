using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace LocFlixWebApi
{
    public class VideoStream
    {
        private readonly string _filename;

        public VideoStream(string filename)
        {
            _filename = @"E:\RAI\" + filename;
        }

        public async void WriteContentToStream(Stream outputStream, HttpContent content, TransportContext transportContext)
        {
            try
            {
                //here set the size of buffer, you can set any size  
                int bufferSize = 1000;
                byte[] buffer = new byte[bufferSize];
                //here we re using FileStream to read file from server//  
                using (var fileStream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    int totalSize = (int)fileStream.Length;
                    /*here we are saying read bytes from file as long as total size of file 

                    is greater then 0*/
                    while (totalSize > 0)
                    {
                        int count = totalSize > bufferSize ? bufferSize : totalSize;
                        //here we are reading the buffer from orginal file  
                        int sizeOfReadedBuffer = fileStream.Read(buffer, 0, count);
                        //here we are writing the readed buffer to output//  
                        await outputStream.WriteAsync(buffer, 0, sizeOfReadedBuffer);
                        //and finally after writing to output stream decrementing it to total size of file.  
                        totalSize -= sizeOfReadedBuffer;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
    }
}
