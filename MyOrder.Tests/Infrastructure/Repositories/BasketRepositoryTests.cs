//using Microsoft.Extensions.Logging;
//using Moq;
//using MyOrder.Infrastructure.ApiClients;
//using MyOrder.Infrastructure.Repositories;
//using MyOrder.Shared.Dtos;
//using MyOrder.Shared.Dtos.SharedComponents;
//using System.Collections.Immutable;
//using System.Reflection;

//namespace MyOrder.Tests.Infrastructure.Repositories;

//public class BasketRepositoryTests
//{
//    private readonly Mock<IBasketApiClient> _mockApiClient;
//    private readonly Mock<ILogger<BasketRepository>> _mockLogger;
//    private readonly BasketRepository _repository;

//    public BasketRepositoryTests()
//    {
//        _mockApiClient = new Mock<IBasketApiClient>();
//        _mockLogger = new Mock<ILogger<BasketRepository>>();
//        _repository = new BasketRepository(_mockApiClient.Object, _mockLogger.Object);
//    }
//    #region PostProcedureCallAsync Tests
//    // MemberData for different value types where field.Value is null but value is not
//    public static IEnumerable<object[]> NullFieldValueNonNullValueTestData()
//    {
//        yield return new object[] { new Field<BasketValueDto>(null, null, null, null, null, null, null), new BasketValueDto(null, "Basket123"), "Basket123" };
//        yield return new object[] { new Field<AccountDto>(null, null, null, null, null, null, null), new AccountDto { AccountId = "Account456" }, "Account456" };
//        yield return new object[] { new Field<ContactDto>(null, null, null, null, null, null, null), new ContactDto { ContactId = "Contact789" }, "Contact789" };
//        yield return new object[] { new Field<int?>(null, null, null, null, null, null, null), 123, "123" };
//    }

//    [Theory]
//    [MemberData(nameof(NullFieldValueNonNullValueTestData))]
//    public async Task PostProcedureCallAsync_ShouldForwardValue_WhenFieldValueIsNullAndValueIsNotNull<T>(Field<T> field, T value, string expectedValue)
//    {
//        // Arrange
//        string basketId = "test-basket-id";
//        var procedureCallTemplate = ImmutableList.Create<string?>("Step1", "Step2", "Step3");

//        _mockApiClient.Setup(api => api.PostProcedureCallAsync(It.IsAny<string>(), It.IsAny<ImmutableList<string?>>()))
//            .ReturnsAsync(new ProcedureCallResponseDto());

//        // Act
//        var result = await _repository.PostProcedureCallAsync(field with { ProcedureCall = procedureCallTemplate }, value, basketId);

//        // Assert
//        _mockApiClient.Verify(api => api.PostProcedureCallAsync(basketId, It.Is<ImmutableList<string?>>(pc =>
//            pc.Last() == expectedValue)), Times.Once);
//    }

//    // MemberData for different value types where field.Value is not null but value is null
//    public static IEnumerable<object[]> NonNullFieldValueNullValueTestData()
//    {
//        yield return new object[] { new Field<BasketValueDto>(null, new BasketValueDto(null, "Basket123"), null, null, null, ["Step1", "Step2", "Step3"], null) };
//        yield return new object[] { new Field<AccountDto>(null, new AccountDto { AccountId = "Account456" }, null, null, null, ["Step1", "Step2", "Step3"], null) };
//        yield return new object[] { new Field<ContactDto>(null, new ContactDto { ContactId = "Contact789" }, null, null, null, ["Step1", "Step2", "Step3"], null) };
//        yield return new object[] { new Field<int>(null, 123, null, null, null, ["Step1", "Step2", "Step3"], null) };
//    }

//    [Theory]
//    [MemberData(nameof(NonNullFieldValueNullValueTestData))]
//    public async Task PostProcedureCallAsync_ShouldForwardEmptyString_WhenFieldValueIsNotNullAndValueIsNull(IField field)
//    {
//        // Arrange
//        string basketId = "test-basket-id";

//        _mockApiClient.Setup(api => api.PostProcedureCallAsync(It.IsAny<string>(), It.IsAny<ImmutableList<string?>>()))
//            .ReturnsAsync(new ProcedureCallResponseDto());

//        // Act
//        var result = await _repository.PostProcedureCallAsync(field, null, basketId);

//        // Assert
//        _mockApiClient.Verify(api => api.PostProcedureCallAsync(basketId, It.Is<ImmutableList<string?>>(pc =>
//            pc.Last() == string.Empty)), Times.Once);
//    }

//    // MemberData for different value types where field.Value and value types match
//    public static IEnumerable<object[]> MatchingTypesTestData()
//    {
//        yield return new object[] { new Field<BasketValueDto>(null, new BasketValueDto(null, "Basket123"), null, null, null, null, null),
//            new BasketValueDto(null, "Basket12345"), "Basket12345" };

//        yield return new object[] { new Field<AccountDto>(null, new AccountDto { AccountId = "Account456" }, null, null, null, null, null),
//            new AccountDto { AccountId = "Account456789" }, "Account456789" };

//        yield return new object[] { new Field<ContactDto>(null, new ContactDto { ContactId = "Contact789" }, null, null, null, null, null),
//            new ContactDto { ContactId = "Contact789123" }, "Contact789123" };

//        yield return new object[] { new Field<int>(null, 123, null, null, null, null, null), 123456, "123456" };
//    }

//    [Theory]
//    [MemberData(nameof(MatchingTypesTestData))]
//    public async Task PostProcedureCallAsync_ShouldForwardConvertedValue_WhenFieldValueAndValueTypesMatch<T>(Field<T> field, T value, string expectedValue)
//    {
//        // Arrange
//        string basketId = "test-basket-id";
//        var procedureCallTemplate = ImmutableList.Create<string?>("Step1", "Step2", "Step3");

//        _mockApiClient.Setup(api => api.PostProcedureCallAsync(It.IsAny<string>(), It.IsAny<ImmutableList<string?>>()))
//            .ReturnsAsync(new ProcedureCallResponseDto());

//        // Act
//        var result = await _repository.PostProcedureCallAsync(field with { ProcedureCall = procedureCallTemplate }, value, basketId);

//        // Assert
//        _mockApiClient.Verify(api => api.PostProcedureCallAsync(basketId, It.Is<ImmutableList<string?>>(pc =>
//            pc.Last() == expectedValue)), Times.Once);
//    }

//    // MemberData for different value types where field.Value and value types do not match
//    public static IEnumerable<object[]> NonMatchingTypesTestData()
//    {
//        yield return new object[] { new Field<BasketValueDto>(null, new BasketValueDto(null, "Basket12345"), null, null, null, ["Step1", "Step2", "Step3"], null),
//            new AccountDto { AccountId = "Account456" }};

//        yield return new object[] { new Field<AccountDto>(null, new AccountDto { AccountId = "Account456" }, null, null, null, ["Step1", "Step2", "Step3"], null),
//            "Account456" };
//        yield return new object[] { new Field<int>(null, 123, null, null, null, ["Step1", "Step2", "Step3"], null),
//            "MismatchingString" };
//    }

//    [Theory]
//    [MemberData(nameof(NonMatchingTypesTestData))]
//    public async Task PostProcedureCallAsync_ShouldThrowInvalidOperationException_WhenFieldValueAndValueTypesDoNotMatch(IField field, object value)
//    {
//        // Arrange
//        string basketId = "test-basket-id";

//        // Act & Assert
//        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
//            _repository.PostProcedureCallAsync(field, value, basketId));

//        // Ensure no API call was made when types do not match
//        _mockApiClient.Verify(api => api.PostProcedureCallAsync(It.IsAny<string>(), It.IsAny<ImmutableList<string?>>()), Times.Never);
//    }
//    #endregion

//    #region ProcedureCallValueToString Tests
//    private static string InvokeProcedureCallValueToString(object? value)
//    {
//        // Get the method info
//        var method = typeof(BasketRepository).GetMethod("ProcedureCallValueToString",
//            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

//        if (method == null)
//            throw new InvalidOperationException("Method not found.");

//        // Invoke the method
//        var result = method.Invoke(null, new object[] { value });

//        // Handle possible null result
//        return result as string ?? string.Empty;
//    }
//    [Fact]
//    public void ProcedureCallValueToString_ShouldReturnBasketValue_WhenValueIsBasketValueDto()
//    {
//        // Arrange
//        var basketValueDto = new BasketValueDto(Description: null, Value: "Basket123");

//        // Act
//        var result = InvokeProcedureCallValueToString(basketValueDto);

//        // Assert
//        Assert.Equal("Basket123", result);
//    }
//    [Fact]
//    public void ProcedureCallValueToString_ShouldReturnAccountId_WhenValueIsAccountDto()
//    {
//        // Arrange
//        var accountDto = new AccountDto { AccountId = "Account456" };

//        // Act
//        var result = InvokeProcedureCallValueToString(accountDto);

//        // Assert
//        Assert.Equal("Account456", result);
//    }
//    [Fact]
//    public void ProcedureCallValueToString_ShouldReturnContactId_WhenValueIsContactDto()
//    {
//        // Arrange
//        var contactDto = new ContactDto { ContactId = "Contact789" };

//        // Act
//        var result = InvokeProcedureCallValueToString(contactDto);

//        // Assert
//        Assert.Equal("Contact789", result);
//    }

//    [Fact]
//    public void ProcedureCallValueToString_ShouldCallToString_WhenValueIsOtherType()
//    {
//        // Arrange
//        var otherObject = new { Name = "TestObject" };

//        // Act
//        var result = InvokeProcedureCallValueToString(otherObject);

//        // Assert
//        Assert.Equal(otherObject.ToString(), result);
//    }

//    [Fact]
//    public void ProcedureCallValueToString_ShouldReturnEmptyString_WhenValueIsNull()
//    {
//        // Act
//        var result = InvokeProcedureCallValueToString(null);

//        // Assert
//        Assert.Equal(string.Empty, result);
//    }
//    #endregion

//    #region GetProcedureCallTemplate Tests
//    private static ImmutableList<string?> InvokeGetProcedureCallTemplate(IField field)
//    {
//        // Get the method info
//        var method = typeof(BasketRepository).GetMethod("GetProcedureCallTemplate",
//            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

//        if (method == null)
//            throw new InvalidOperationException("Method not found.");

//        // Prepare out parameters
//        object[] parameters = { field, field.GetType(), null, false };

//        // Invoke the method
//        method.Invoke(null, parameters);

//        // Return the template
//        return parameters[2] as ImmutableList<string?>;
//    }
//    public class ProcedureCallTemplateTheoryData : TheoryData<ImmutableList<string?>?>
//    {
//        public ProcedureCallTemplateTheoryData()
//        {
//            Add(null);
//            Add(ImmutableList<string?>.Empty);
//        }
//    }
//    [Theory]
//    [ClassData(typeof(ProcedureCallTemplateTheoryData))]
//    public void GetProcedureCallTemplate_ShouldThrowInvalidOperationException_WhenPcdIsNullOrEmpty(ImmutableList<string?>? pcdCall)
//    {
//        // Arrange
//        var field = new Field<string>(null, "TestValue", null, null, null, pcdCall, null);

//        // Act & Assert
//        var ex = Assert.Throws<TargetInvocationException>(() => InvokeGetProcedureCallTemplate(field));
//        Assert.IsType<InvalidOperationException>(ex.InnerException);
//    }
//    [Fact]
//    public void GetProcedureCallTemplate_ShouldReturnTemplate_WhenProcedureCallTemplateIsValid()
//    {
//        // Arrange
//        var field = new Field<string>(null, "TestValue", null, null, null, ImmutableList.Create<string?>("Step1", "Step2", "Step3"), null);

//        // Act
//        var result = InvokeGetProcedureCallTemplate(field);

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(3, result.Count);
//        Assert.Contains("Step1", result);
//        Assert.Contains("Step2", result);
//        Assert.Contains("Step3", result);
//    }
//    #endregion
//}