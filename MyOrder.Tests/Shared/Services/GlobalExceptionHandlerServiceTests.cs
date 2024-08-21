using MyOrder.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.Shared.Services;

public class GlobalExceptionHandlerServiceTests
{
    private readonly GlobalExceptionHandlerService _exceptionHandler = new();

    [Fact]
    public void HandleException_ShouldStoreExceptionAndTriggerEvent()
    {
        // Arrange
        var exception = new InvalidOperationException("Test exception");
        bool eventTriggered = false;
        _exceptionHandler.OnExceptionOccurred += () => eventTriggered = true;

        // Act
        _exceptionHandler.HandleException(exception);

        // Assert
        Assert.Equal(exception, _exceptionHandler.GetCurrentException());
        Assert.True(eventTriggered, "OnExceptionOccurred event should have been triggered.");
    }

    [Fact]
    public void HandleException_ShouldLogException()
    {
        // Arrange
        var exception = new InvalidOperationException("Test exception");
        bool eventTriggered = false;
        _exceptionHandler.OnExceptionOccurred += () => eventTriggered = true;

        // Act
        _exceptionHandler.HandleException(exception);

        // Assert
        Assert.Equal(exception, _exceptionHandler.GetCurrentException());
        Assert.True(eventTriggered, "OnExceptionOccurred event should have been triggered.");
    }

    [Fact]
    public void ClearException_ShouldRemoveCurrentExceptionAndTriggerEvent()
    {
        // Arrange
        var exception = new InvalidOperationException("Test exception");
        _exceptionHandler.HandleException(exception);
        bool eventTriggered = false;
        _exceptionHandler.OnExceptionOccurred += () => eventTriggered = true;

        // Act
        _exceptionHandler.ClearException();

        // Assert
        Assert.Null(_exceptionHandler.GetCurrentException());
        Assert.True(eventTriggered, "OnExceptionOccurred event should have been triggered after clearing exception.");
    }

    [Fact]
    public void GetCurrentException_ShouldReturnNull_WhenNoExceptionHandled()
    {
        // Act
        var currentException = _exceptionHandler.GetCurrentException();

        // Assert
        Assert.Null(currentException);
    }

    [Fact]
    public void HandleException_ShouldBeThreadSafe()
    {
        // Arrange
        var exception1 = new InvalidOperationException("Test exception 1");
        var exception2 = new InvalidOperationException("Test exception 2");

        // Act
        Parallel.Invoke(
            () => _exceptionHandler.HandleException(exception1),
            () => _exceptionHandler.HandleException(exception2)
        );

        // Assert
        var currentException = _exceptionHandler.GetCurrentException();
        Assert.True(currentException == exception1 || currentException == exception2,
            "The current exception should be one of the exceptions handled.");
    }
}


