using System;

namespace DemoApp.RequestModels
{
    public class Person
    {
        public enum Sex
        {
            Male,
            Female
        }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public Sex Gender { get; set; }
    }
}
