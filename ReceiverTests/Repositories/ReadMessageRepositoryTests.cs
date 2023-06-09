﻿using Receiver.Repositories;
using ReceiverTests.Mocks;

namespace ReceiverTests.Repositories;

public class ReadMessageRepositoryTests
{
    [Fact]
    public void ShouldReturnMessage()
    {
        var expected = "Hello my name is, Test User";
        var mockConsumer = new MockConsumer();
        var readMessageRepository = new ReadMessageRepository(mockConsumer);

        readMessageRepository.ReadMessage((message) =>
        {
            Assert.Equal(expected, message);
        });
    }
}
