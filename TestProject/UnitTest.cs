using DateValidationApp;
using FluentAssertions;

namespace TestProject
{
    public class UnitTest
    {
        LibraryDateTests libary = new LibraryDateTests();

        //Позитивный тест кайс
        [Fact]
        public void LibraryDateTests_ValidDate_LowerBoundary()
        {
            var result = libary.ValidDate("01.01.1900");
            result.Should().BeTrue("the date should be accepted as it is within the valid range.");
        }
        [Fact]
        public void LibraryDateTests_ValidDate_MiddleRange()
        {
            var result = libary.ValidDate("01.01.2000");
            result.Should().BeTrue("the date should be accepted as it is within the valid range.");
        }
        [Fact]
        public void LibraryDateTests_ValidDate_CurrentYear()
        {
            var result = libary.ValidDate("31.01.2025");
            result.Should().BeTrue("the date should be accepted as it is within the valid range.");
        }
        [Fact]
        public void LibraryDateTests_ValidDate_LeapYear()
        {
            var result = libary.ValidDate("29.02.2020");
            result.Should().BeTrue("the date should be accepted as it is a valid leap year date.");
        }

        //Негативный тест кайс
        [Fact]
        public void LibraryDateTests_ValidDate_BelowLowerBoundary()
        {
            var result = libary.ValidDate("31.12.1899");
            result.Should().BeFalse("the date should be rejected as it is below the valid range.");
        }
        [Fact]
        public void LibraryDateTests_ValidDate_AboveUpperBoundary()
        {
            var result = libary.ValidDate("01.01.2026");
            result.Should().BeFalse("the date should be rejected as it is above the valid range.");
        }

        [Fact]
        public void Test_ValidDate_AboveCurrentYear()
        {
            var result = libary.ValidDate("01.01.2026");
            result.Should().BeFalse("the date should be rejected as it is above the valid range.");
        }
        [Fact]
        public void Test_ValidDate_MoreThan31Numbers()
        {
            var result = libary.ValidDate("32.01.2020");
            result.Should().BeFalse("the date should be rejected as it is " +
                "an input that has more than 31 days.");
        }
        [Fact]
        public void Test_ValidDate_NonAlphabeticCharacters()
        {
            var result = libary.ValidDate("#R=%^");
            result.Should().BeFalse("the date should be rejected as it is " +
                "an input that has non alphabetic characters.");
        }
        [Fact]
        public void Test_ValidDate_AlphabeticCharacters()
        {
            var result = libary.ValidDate("fxggg");
            result.Should().BeFalse("the date should be rejected as it is " +
                "an input that has alphabetic characters.");
        }
        [Fact]
        public void Test_ValidDate_MoreThan12Months()
        {
            var result = libary.ValidDate("32.67.2020");
            result.Should().BeFalse("the date should be rejected as it is " +
                "an input that has more than 12 months.");
        }
        [Fact]
        public void Test_ValidDate_DateHasMoreThanTwoDots()
        {
            var result = libary.ValidDate("0.3.11.2020");
            result.Should().BeFalse("the date should be rejected as it is " +
                "has more than two DOTS.");
        }
        [Fact]
        public void Test_ValidDate_EmptyDate()
        {
            var result = libary.ValidDate("");
            result.Should().BeFalse("the date should be rejected as " +
                "it is has an empty date input.");
        }
    }
}