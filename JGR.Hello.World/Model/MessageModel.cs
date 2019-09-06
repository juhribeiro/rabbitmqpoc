using System;
using System.IO;

namespace JGR.Hello.World.Model
{
    public class MessageModel
    {
        public Guid Id => Guid.NewGuid();
        public string ApplicationName { get; set; }
        public string Date => DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public string Message => "Hello World";
    }
}