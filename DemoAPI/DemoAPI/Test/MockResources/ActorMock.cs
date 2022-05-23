using System;
using System.Collections.Generic;
using DemoApp.Models;
using DemoApp.Repository;
using Moq;

namespace DemoApp.Test.MockResources
{
    public class ActorMock
    {
        /// <summary>
        /// See how we are using Moq - https://github.com/moq/moq4
        /// </summary>
        public static readonly Mock<IActorRepository> ActorRepoMock = new Mock<IActorRepository>();

        private static readonly IEnumerable<Actor> ListOfActors = new List<Actor>
        {
            new Actor
            {
                Id = 1,
                Name = "Mock Actor 1",
                Bio = "--",
                DOB = DateTime.Now.AddYears(-22)
            },
            new Actor
            {
                Id = 2,
                Name = "Mock Actor 2",
                Bio = "--",
                DOB = DateTime.Now.AddYears(-20)
            }
        };

        public static void MockGetAll()
        {
            ActorRepoMock.Setup(x => x.GetAll()).Returns(ListOfActors);
        }
    }
}